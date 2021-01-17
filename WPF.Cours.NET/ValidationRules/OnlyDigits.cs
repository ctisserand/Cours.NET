using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Cours.NET.ValidationRules
{
    public class OnlyDigitsValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var validationResult = new ValidationResult(true, null);

            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString()))
                {
                    var new_value = value.ToString().Replace(".", ",");
                    var regex = new Regex("^-?[0-9]+(.[0-9]+)?$"); //regex that matches disallowed text
                    var parsingOk = regex.IsMatch(new_value);
                    if (!parsingOk)
                    {
                        validationResult = new ValidationResult(false, "Illegal Characters, Please Enter Numeric Value");
                    }
                }
            }

            return validationResult;
        }
    }
}
