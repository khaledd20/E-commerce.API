using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AngEcommerceProject.Models
{
    public class OrderProducts
    {

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductTotalPrice { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }

    }
}
