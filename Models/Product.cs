using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AngEcommerceProject.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [Range(0.0, Int64.MaxValue, ErrorMessage = "Quentity must be greater than 0.")]
        public int quantity { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double price { get; set; }
        [Required]
        public string  imagePath { get; set; }
        [Required]
        [ForeignKey("category")]
        public int categoryId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public Category category { get; set; }
    }
}
