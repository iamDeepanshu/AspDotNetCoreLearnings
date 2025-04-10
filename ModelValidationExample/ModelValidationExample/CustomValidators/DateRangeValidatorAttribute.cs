using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationExample.CustomValidators
{

    // this is  the concept of Custom Validation with Multiple properties

    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherPropertyName {  get; set; }
        public DateRangeValidatorAttribute(string otherPropertyValue)
        {
            OtherPropertyName = otherPropertyValue;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) 
            { 
                //get to_date
                DateTime to_date = (DateTime)value;
                
                // getting the refernce of FromDate
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if (otherProperty != null)
                {
                    // get, fro_date
                    DateTime from_date = (DateTime)otherProperty.GetValue(validationContext.ObjectInstance);

                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });

                    }
                    else
                    {
                        return ValidationResult.Success;

                    }
                }
                return null;
            
            }
            return null;
        }
    }
}
