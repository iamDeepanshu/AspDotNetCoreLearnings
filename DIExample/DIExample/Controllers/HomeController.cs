﻿using System.Security.Cryptography.X509Certificates;
using Services;
using Microsoft.AspNetCore.Mvc;


namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly CitiesService _citiesService;
        public HomeController()
        {
            _citiesService = new CitiesService();
        }
        [Route("/")]
        public IActionResult Index()
        {
           List<string> cities= _citiesService.GetCities();
            return View(cities);
        }
    }
}
