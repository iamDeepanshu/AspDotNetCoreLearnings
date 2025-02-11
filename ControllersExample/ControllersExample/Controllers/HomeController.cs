// [Route("index")], this is attribute routing, bcz with in the attribute [] we are writing the route template,
// we will supply route template as an argument like ("index")
// with the given template the route will be configured for this action method ie "Home"

// for json result, we created a class in models folder which contains all the properties to ease the writing of data in json format

using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

using ControllersExample.Models;
namespace ControllersExample.Controllers

{
    public class HomeController : Controller
    {
        [Route("index")]
        [Route("/")]            // mutiple action methods
        public ContentResult Home()
        {
            //return new ContentResult() { Content = "Hello this is Home of the Controller", ContentType = "text/plain" };

                                //using Content Result 
            return Content("Hello this is Home part of the Controller", "text/plain"); // shortcut mehtod
        }

        [Route("about")]
        public ContentResult About()
        {
            return  Content("<h1>Hello this is About part</h1><h2>of the Controller</h2>", "text/html");
        }

                                    // Json Result
        [Route("person")]
        public JsonResult Person() {

        // creating object of Person class of models folder andd passing the value to properties
        Person person = new Person() { Id = Guid.NewGuid(), FirstName="Avi", LastName = "Saini", Age = 25 };

            // return new JsonResult(person);

           return Json(person); // shortcut

           // return "{\"key\":\"value\"}";  //old and confusing method, return type string
        }

                                //  FILE RESULT()
        [Route("virtual-file-download")]
        public VirtualFileResult VirtualFileDownload()
        {
            // return new VirtualFileResult("/dummy.pdf","application/pdf");
            return  File("/dummy.pdf", "application/pdf"); //shorthand
        }

        [Route("physical-file-download")]
        public PhysicalFileResult PhysicalFileDownload()
        {
            // return new PhysicalFileResult(@"C:\Users\DeepanshuSaini\source\repos\ControllersExample\dummy.pdf", "application/pdf
            return  PhysicalFile(@"C:\Users\DeepanshuSaini\source\repos\ControllersExample\dummy.pdf", "application/pdf");
        }

        [Route("file-content-download")]
        public FileContentResult FileContentDownload()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\DeepanshuSaini\source\repos\ControllersExample\dummy.pdf");
            // return new FileContentResult(bytes, "application/pdf");
            return  File(bytes, "application/pdf");
        }





        [Route("contact-us/{mob:regex(^//d{{10}}$)}")]
        public string Contact()
        {
            
            return "Hello this is Contact part of the Controller";
        }
    }
}
