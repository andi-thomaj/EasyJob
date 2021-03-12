using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace EasyJob.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var validationResultError in validationResult.Errors)
            {
                ValidationErrors.Add(validationResultError.ErrorMessage);
            }
        }
    }
}