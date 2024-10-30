using AngEcommerceProject.Models;
using System.Collections.Generic;

namespace AngEcommerceProject.Repositorys
{
    public class WishProductRepository : IwishProductRepository
    {
        EcommerceContext Context;
        public WishProductRepository(EcommerceContext context)
        {
            this.Context = context;
        }
        public WishProducts create(WishProducts item)
        {
            throw new System.NotImplementedException();
        }

        public int delete(WishProducts item)
        {
            throw new System.NotImplementedException();
        }

        public List<WishProducts> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public WishProducts GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public WishProducts update(int id, WishProducts item)
        {
            throw new System.NotImplementedException();
        }
    }
}
