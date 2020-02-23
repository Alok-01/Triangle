using CS.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS.API.CompanyEmployees.CustomActionFilters
{
    public class ValidateCompanyExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ValidateCompanyExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var isTrackChange = method.Equals("PUT") ? true : false;
            var id = (Guid)context.ActionArguments["id"];
            var company = await _repository.Company.GetCompanyAsync(id, isTrackChange);
            if (company == null)
            {
                _logger.LogInfo($"Company with id: {id} doesn't exist in the database."); 
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("company", company);
                await next();
            }
        }

    }
}
