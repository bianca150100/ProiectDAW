using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models.CustomValidation
{
    public class DataValidation  : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            string format = "yyyy-MM-dd";
            string dataS = value.ToString();
            DateTime dateTime;
            if (DateTime.TryParseExact(dataS, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                if (dateTime > DateTime.Now)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

    }
}