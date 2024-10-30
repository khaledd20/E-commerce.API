using AngEcommerceProject.Dto;
using AngEcommerceProject.Models;
using System.Collections.Generic;

namespace AngEcommerceProject.Repositorys
{
    public interface ICategoryRepository :ICrudRepository<Category>
    {
        public List<CategoryProductDto> CatProduct();
    }
}
