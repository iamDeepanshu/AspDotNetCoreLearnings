using Microsoft.AspNetCore.Mvc;
using ModelBindingExample1.Models;

namespace ModelBindingExample1.Controllers
{
    public class HomeController : Controller
    {
        [Route("book/{bookid}/{isloggedin}")]
        public IActionResult Index([FromRoute] int? bookid,[FromRoute] bool? isloggedin, Book book)
        {
            //Book id should be applied
            // HasValue tells you if the variable has a value (returns true) or if it is null (false).
            if (bookid.HasValue== false)
            {
                Response.StatusCode = 400;
                return Content("Book id is not supplied or empty");
            }

            //Book id can't be less than or equal to 0
            if (bookid <=0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be null or empty

                //return new BadRequestResult();
                return BadRequest("Book id cant be less than or equal to 0 "); //short-hand
            }

            //Book id should be between 1 to 1000
 
            if (bookid > 1000)
            {
                //Response.StatusCode = 404;
                //return Content("Book id can't be greater than 1000");

                return NotFound("Book id can't be greater than 1000");
            }

            //isloggedin should be true
            
            if (isloggedin.HasValue == false)
            {
                //Response.StatusCode = 401;
                //return Content("User must be authenticated");
             
                return Unauthorized("User must be authenticated"); //returns only for null value
            }

            return Content($"Book id is : {bookid} and {book}", "text/plain");
        }
    }
}