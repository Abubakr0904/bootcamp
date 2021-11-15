using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pizza.Models
{
    public class ReturnedPizza
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string ShortName { get; set; }
        
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public EPizzaStockStatus? Status { get; set; }
        
        [Required]
        public string Ingredients { get; set; }
        
        [Required]
        public Double Price { get; set; }
    }
}