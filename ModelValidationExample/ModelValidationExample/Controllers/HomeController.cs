using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBinders;
using ModelValidationExample.Models; //using Models



namespace ModelValidationExample.Controllers
{
    public class HomeController : Controller

    {
        //[ModelBinder(BinderType =typeof(PersonModelBinder))] // used to invoke Custom Model Binder, in the index parameter

        //[FromHeader(Name = "User-Agent")] string UserAgent) //Value From Request Headers(FromHeader)  

        [Route("register")]
        public IActionResult Index([FromBody] [ModelBinder(BinderType =typeof(PersonModelBinder))] Person person, [FromHeader(Name ="User-Agent")]string UserAgent)
        {
            //checking for the validations and status of validation using MODEL STATE

            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n",ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));

                return BadRequest(errors);
                
            }

            return Content($"{person}, {UserAgent}") ;
        }
    }
}
