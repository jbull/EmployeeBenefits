﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefits.Data.Models
{
    public class Dependent: BasePersonEntity
    {
        public DependentType DependentType { get; set; }

    }
}