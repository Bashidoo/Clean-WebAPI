﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Dtos
{
    public class CustomerDto 
    {

        public string Name { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

    }
}
