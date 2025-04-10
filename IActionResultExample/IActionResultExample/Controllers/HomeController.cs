using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore")]
        public IActionResult Index()
        {
            //Book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return Content("Book id is not supplied");
            }

            //Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be null or empty

                //return new BadRequestResult();
                return  BadRequest("Book id can't be null or empty"); //short-hand
            }

            //Book id should be between 1 to 1000
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {
                Response.StatusCode = 400;
                return Content("Book id can't be less than or equal to zero");
            }
            if (bookId > 1000)
            {
                //Response.StatusCode = 404;
                //return Content("Book id can't be greater than 1000");

                return NotFound("Book id can't be greater than 1000");
            }

            //isloggedin should be true
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                //Response.StatusCode = 401;
                //return Content("User must be authenticated");

                return Unauthorized("User must be authenticated");


            }

            //return File("/dummy.pdf", "application/pdf");

            //            Redirecting, for this create a new controller with new URL and action method

                                                //302- Found

            // return new RedirectToActionResult("Books", "Store", new { }); 
            //return  RedirectToAction("Books", "Store", new { id = bookid }); //302- Found ShortHand


                                                //301 - Permanently Moved

            //return new RedirectToActionResult("Books", "Store", new { }, permanent: true); 
            // return RedirectToActionPermanent("Books", "Store", new { id = bookId}); //301 - Permanently Moved ShortHand


                                            //302- Found , LocalRedirect

            // return new LocalRedirectResult($"store/book/{bookId}");
            //return LocalRedirect($"store/book/{bookId}"); // Short Hand

                                            //301- Moved Permanently , LocalRedirect
                
            // return new LocalRedirectResult($"store/book/{bookId},permanent:true");
            return LocalRedirectPermanent($"store/book/{bookId}"); // Short Hand


        }
    }
}
