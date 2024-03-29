﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }

        IEmployeeRepository Employee { get; }

        Task SaveAsync();
    }
}
