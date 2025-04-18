﻿using System.ComponentModel.DataAnnotations;

namespace CitiesManager.WebAPI.Models
{
    public class City
    {
        [Key]
        public Guid CityID { get; set; }
        
        
        [Required(ErrorMessage="City name can not be left blank")]
        public string? CityName { get; set; }    
    }
}
