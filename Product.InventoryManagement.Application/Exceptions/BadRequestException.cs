﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]> ValidationErrors { get; set; }
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
        }
    }
}
