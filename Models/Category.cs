using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AngEcommerceProject.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }

    }
}
