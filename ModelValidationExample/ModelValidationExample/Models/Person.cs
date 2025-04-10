using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using ModelValidationExample.CustomValidators; //using Custom Validator
namespace ModelValidationExample.Models
{
    public class Person : IValidatableObject
    {
        [Required (ErrorMessage = "{0} can't be empty or null")] //attribute to add validation, not to be null
        [Display(Name = "Person Name")]
        // {0} ->> is the personname automatically concatenated and "Display" attribute chnages the name of the property(PersonName)
        [StringLength(20,MinimumLength =3, ErrorMessage =" {0} should be of length between {2} and {1} ")]
       // [RegularExpression("^[A-Za-z .]*$", ErrorMessage ="{0} should contain only alphabets, space and dots(.)" )] //* is used to accpet more than one character
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "{0} can't be empty or null")]
        [EmailAddress(ErrorMessage ="{0} should be of proper format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Phone(ErrorMessage = "{0} should be of proper format")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = " Please fill the {0} ")]
        public string? Password { get; set; }

        [Required(ErrorMessage = " Please fill the {0} ")]
        [Compare("Password",ErrorMessage ="{1} and {0} must be same")]
        public string? ConfirmPassword { get; set; }

        //[ValidateNever]
       // [BindNever]
        public double? Price { get; set; }

        //[MinimumYearValidator (2000,ErrorMessage = "Minimum Year allowed is {0}")]
        [MinimumYearValidator(2000)] // for default message
        public DateTime? DateOfBirth { get; set; }

        public DateTime? FromDate { get; set; }

        [DateRangeValidator ("FromDate", ErrorMessage ="From Date must be less than TO Date")]
        public DateTime? ToDate { get; set; }

        public int? Age { get; set; }

        //this property will accept the more than one value 
        // example of collcetion binding
       // public List<string?> Tags { get; set; }


        public override string ToString() //predefined method 
        {
            return $"PersonName: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, ConfirmPassword:{ConfirmPassword} Price: {Price}";

        }
         // this is the concept of ValidatableObject
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DateOfBirth.HasValue == false && Age.HasValue == false) 
            {
                // "yield" keyword allows to return multiple values, and all those multiple values automatically got converted into IEnumrable type

                yield return new ValidationResult("Either of DOB or Age must be supplied", new [] { nameof(Age) });
            } 
        }
    }
}
