using AngEcommerceProject.Dto;
using AngEcommerceProject.Models;
using System.Collections.Generic;

namespace AngEcommerceProject.Repositorys
{
    public interface IProductRepository :ICrudRepository<Product>
    {
        public List<Product> GetProductByCategoryID(int CategoryId);
        public List<Product> Filter(FilteredProduct product);

        public Product newUpdate(int id , ProductDto product);

    }
}
