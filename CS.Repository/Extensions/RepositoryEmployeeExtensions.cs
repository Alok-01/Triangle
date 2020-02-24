﻿using CS.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using CS.Repository.Extensions.Utility;

namespace CS.Repository.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> employees, uint minAge, uint maxAge)
            => employees.Where(e => e.Age >= minAge && e.Age <= maxAge);
        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return employees;
            }

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return employees.Where(e => e.Name.Contains(lowerCaseTerm));
        }

        public static IQueryable<Employee> Sort(this IQueryable<Employee> employees, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return employees.OrderBy(e => e.Name);
            }

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Employee>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return employees.OrderBy(e => e.Name);
            }
            return employees.OrderBy(orderQuery);
        }

        //public static IQueryable<Employee> Sort(this IQueryable<Employee> employees, string orderByQueryString)
        //{
        //    if (string.IsNullOrWhiteSpace(orderByQueryString))
        //    {
        //        return employees.OrderBy(e => e.Name);
        //    }

        //    var orderParams = orderByQueryString.Trim().ToLower().Split(',');
        //    var propertyInfos = typeof(Employee).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    var orderQueryBuilder = new StringBuilder();
        //    foreach (var param in orderParams)
        //    {
        //        if (string.IsNullOrEmpty(param)) continue;


        //        var propertyFromQueryName = param.Split(" ")[0];
        //        var objectProperty = propertyInfos.FirstOrDefault(pi =>
        //            pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
        //        if (objectProperty == null) continue;
        //        var direction = param.EndsWith(" desc") ? "descending" : "ascending";
        //        orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
        //    }

        //    var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        //    if (string.IsNullOrWhiteSpace(orderQuery))
        //    {
        //        return employees.OrderBy(e => e.Name);
        //    }

        //    return employees.OrderBy(orderQuery); // System.Linq.Dynamic.Core;
        //}
    }
}
