using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models.CustomValidation
{
    public class OraValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string oraS = value.ToString();
            int ora = Int16.Parse(oraS);
            if (ora >= 8 && ora <= 19)
            {
                return true;
            }
            return false;
        }

    }
}