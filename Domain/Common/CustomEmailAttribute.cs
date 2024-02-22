using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Common
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field | 
     AttributeTargets.Method | AttributeTargets.Parameter,
     AllowMultiple = false)]
    public class CustomEmailValidation:ValidationAttribute
    {
        private static readonly Regex EmailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        public override bool IsValid(object? value)
        {
            string email=value.ToString();
            if (EmailRegex.IsMatch(email)) 
            { return true; 
            }
            else 
            { return false; 
            }
           

        }

    }
}
