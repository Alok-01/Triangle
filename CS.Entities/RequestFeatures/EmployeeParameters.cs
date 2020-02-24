﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Entities.RequestFeatures
{
    public class EmployeeParameters :RequestParameters
    {
        public uint MinAge { get; set; }
        
        public uint MaxAge { get; set; } = int.MaxValue; 
        
        public bool ValidAgeRange => MaxAge > MinAge;
    }
}