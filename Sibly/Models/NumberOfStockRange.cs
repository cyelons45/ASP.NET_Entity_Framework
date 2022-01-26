using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;   

namespace Sibly.Models
{
    public class NumberOfStockRange:ValidationAttribute    
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.NumberInStock>0 && movie.NumberInStock<101)
                return ValidationResult.Success;

            return new ValidationResult("The field Number in Stock must be between 1 and 100.");
        }
    }
}