
using AngEcommerceProject.Models;
using AngEcommerceProject.Dto;
using System.Collections.Generic;

namespace AngEcommerceProject.Repositorys
{
    public interface IOrderProductRepository:ICrudRepository<OrderProducts>
    {
        public List<ProductsCartDto> getOrderDetails(int OrderId);
    }
}
