﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CS.API.CompanyEmployees.CustomActionFilters;
using CS.API.CompanyEmployees.Utility;
using CS.Contracts;
using CS.Entities.DataTransferObjects;
using CS.Entities.Models;
using CS.Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CS.API.CompanyEmployees.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        //private readonly IDataShaper<EmployeeDto> _dataShaper;
        private readonly EmployeeLinks _employeeLinks;

        public EmployeesController(ILoggerManager loggerManager, IRepositoryManager repositoryManager, IMapper mapper,
            //IDataShaper<EmployeeDto> dataShaper, 
            EmployeeLinks employeeLinks)

        {
            _repository = repositoryManager;
            _logger = loggerManager;
            _mapper = mapper;
            // _dataShaper = dataShaper;
            _employeeLinks = employeeLinks;
        }

        //https://localhost:5001/api/companies/C9D4C053-49B6-410C-BC78-2D54A9991870/employees?pageNumber=1&pageSize=4&minAge=26&maxAge=32&searchTerm=A&orderBy=name asc&fields=name,age
        [HttpGet]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId, [FromQuery] EmployeeParameters employeeParameters)
        {
            if (!employeeParameters.ValidAgeRange)
            {
                return BadRequest("Max age can't be less than min age.");
            }

            var company = _repository.Company.GetCompanyAsync(companyId, trackChanges: false);

            if (company == null)
            {
                _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound();
            }

            var employeesFromDb = await _repository.Employee.GetEmployeesAsync(companyId, trackChanges: false, employeeParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(employeesFromDb.MetaData));

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            var links = _employeeLinks.TryGenerateLinks(employeesDto, employeeParameters.Fields, companyId, HttpContext);
            return links.HasLinks ? Ok(links.LinkedEntities) : Ok(links.ShapedEntities);
            //return Ok(_dataShaper.ShapeData(employeesDto, employeeParameters.Fields));
            //return Ok(employeesDto);
        }

        [HttpGet("{id}", Name = "GetEmployeeForCompany")]
        public async Task<IActionResult> GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database."); return NotFound();
            }

            var employeeDb = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges: false);

            if (employeeDb == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database."); return NotFound();
            }
            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return Ok(employee);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            //if (employee == null)
            //{
            //    _logger.LogError("EmployeeForCreationDto object sent from client is null.");
            //    return BadRequest("EmployeeForCreationDto object is null");
            //}

            //if (!ModelState.IsValid)
            //{
            //    _logger.LogError("Invalid model state for the EmployeeForUpdateDto object");
            //    return UnprocessableEntity(ModelState);
            //}

            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
                return NotFound();
            }

            var employeeEntity = _mapper.Map<Employee>(employee);

            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            await _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateEmployeeForCompanyExistsAttribute))]
        public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            //var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges: false);
            //if (company == null)
            //{
            //    _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
            //    return NotFound();
            //}
            //var employeeForCompany = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges: false);
            //if (employeeForCompany == null)
            //{
            //    _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
            //    return NotFound();
            //}
            var employeeForCompany = HttpContext.Items["employee"] as Employee;
            _repository.Employee.DeleteEmployee(employeeForCompany);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateEmployeeForCompanyExistsAttribute))]
        public async Task<IActionResult> UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
        {
            //if (employee == null)
            //{
            //    _logger.LogError("EmployeeForUpdateDto object sent from client is null.");
            //    return BadRequest("EmployeeForUpdateDto object is null");
            //}

            //if (!ModelState.IsValid)
            //{
            //    _logger.LogError("Invalid model state for the EmployeeForUpdateDto object");
            //    return UnprocessableEntity(ModelState);
            //}

            //var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges: false);
            //if (company == null)
            //{
            //    _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
            //    return NotFound();
            //}
            //var employeeEntity = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges: true);
            //The trackChanges parameter is set to true for the employeeEntity. That’s because we want EF Core to track changes on this entity. 
            //This means that as soon as we change any property in this entity, EF Core will set the state of that entity to Modified

            var employeeEntity = HttpContext.Items["employee"] as Employee;

            if (employeeEntity == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _mapper.Map(employee, employeeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidateEmployeeForCompanyExistsAttribute))]
        public async Task<IActionResult> PartiallyUpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchEmployee)
        {
            if (patchEmployee == null)
            {
                {
                    _logger.LogError("PartiallyUpdateEmployee object sent from client is null.");
                    return BadRequest("PartiallyUpdateEmployee object is null");
                }
            }

            //var company = _repository.Company.GetCompanyAsync(companyId, trackChanges: false);
            //if (company == null)
            //{
            //    _logger.LogInfo($"Company with id: {companyId} doesn't exist in the database.");
            //    return NotFound();
            //}

            //var employeeEntity = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges: true);

            //if (employeeEntity == null)
            //{
            //    _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
            //    return NotFound();
            //}
            var employeeEntity = HttpContext.Items["employee"] as Employee;
            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);
            patchEmployee.ApplyTo(employeeToPatch, ModelState);
            TryValidateModel(employeeToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(employeeToPatch, employeeEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}