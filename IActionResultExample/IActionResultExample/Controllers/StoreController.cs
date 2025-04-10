using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/book/{id}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32( Request.RouteValues["bookid"]);
            return Content($"<h1>Book Store, BookId is {id}</h1>","text/html");
        }
    }
}
