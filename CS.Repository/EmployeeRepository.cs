using CS.Contracts;
using CS.Entities;
using CS.Entities.Models;
using CS.Entities.RequestFeatures;
using CS.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges, EmployeeParameters employeeParameters)
        {
            var employeeList = await FindByCondition(e =>
            e.CompanyId.Equals(companyId), trackChanges)
                .FilterEmployees(employeeParameters.MinAge,employeeParameters.MaxAge)
                .Search(employeeParameters.SearchTerm)
                //.OrderBy(e => e.Name)
                .Sort(employeeParameters.OrderBy)
                .ToListAsync();

            return PagedList<Employee>.ToPagedList(
                employeeList, employeeParameters.PageNumber, employeeParameters.PageSize
                );
        }

        //public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges, EmployeeParameters employeeParameters)
        //{
        //    var employeeList = await FindByCondition(e =>
        //    e.CompanyId.Equals(companyId) && e.Age >= employeeParameters.MinAge && e.Age <= employeeParameters.MaxAge, trackChanges)
        //        .OrderBy(e => e.Name)
        //        .ToListAsync();

        //    return PagedList<Employee>.ToPagedList(
        //        employeeList, employeeParameters.PageNumber, employeeParameters.PageSize
        //        );
        //}

        //public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges, EmployeeParameters employeeParameters) =>
        //    await FindByCondition(e =>
        //    e.CompanyId.Equals(companyId), trackChanges)
        //    .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
        //    .Take(employeeParameters.PageSize)
        //    .OrderBy(e => e.Name)
        //    .ToListAsync();

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) => await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
    }
}
