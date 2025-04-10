using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ModelValidationExample.CustomValidators
{

            //  this is  the concept of Custom validation
           
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        // for Parameters in Custom Validations, created this ( MinimumYear)property and the cunstructors
        public int MinimumYear { get; set; } = 2000; //this is default value if we dont pass any value
        public string DefaultErrorMessage { get; set; } = "Please Enter the year less than {0}";
     
        public MinimumYearValidatorAttribute()
        {
        }

        public MinimumYearValidatorAttribute(int minYear)//receiving the values passed in the attribute
        {
            MinimumYear = minYear;
        }

        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {           // here "value" represents the value of the property to which the attribute is applied
            if (value != null)
            {
                // DateTime dateTime = Convert.ToDateTime(value);
                    DateTime dateTime = (DateTime)value;

                // to remove the hard coding we used the parameterized custom validation
                // if (dateTime.Year > 2000)

                if (dateTime.Year > MinimumYear)

                {
                   // return new ValidationResult("any_message,used when we have not passed the Error message in the Attribute");
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage,MinimumYear));
                }
                else
                {
                    return ValidationResult.Success;

                }
            }
            return null;
        }

        }
}
