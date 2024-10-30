﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AngEcommerceProject.Models
{
    public class WishProducts
    {
        [ForeignKey("WishList")]
        public int WishListId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; }
        [JsonIgnore]
        public virtual WishList WishList { get; set; }


    }
}
