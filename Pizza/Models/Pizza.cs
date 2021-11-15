using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pizza.Models
{
    public class Pizza
    {   
        [Required]
        [MaxLength(255, ErrorMessage = "Title length should be less than 255")]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(3, ErrorMessage = "ShortName should be uniquely defined string with length 3")]
        [MinLength(3, ErrorMessage = "ShortName should be uniquely defined string with length 3")]
        public string ShortName { get; set; }
        
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public EPizzaStockStatus? Status { get; set; }
        
        [Required]
        [MaxLength(1024, ErrorMessage = "Maximum length of ingredients string should be 1024")]
        public string Ingredients { get; set; }
        
        [Required]
        [Range(0, 1000, ErrorMessage = "Price should be in range 0 - 1000")]
        public Double Price { get; set; }       
    }
}