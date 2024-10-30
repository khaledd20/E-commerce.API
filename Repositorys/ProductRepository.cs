using AngEcommerceProject.Dto;
using AngEcommerceProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngEcommerceProject.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        EcommerceContext Context;
        public ProductRepository(EcommerceContext context)
        {
            this.Context = context;
        }
        public Product create(Product item)
        {
            try
            {
                Context.Products.Add(item);
                var result = Context.SaveChanges();
                if (result > 0)
                {
                    return item;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int delete(Product item)
        {
            Context.Products.Remove(item);
            return Context.SaveChanges();
        }

        public List<Product> Filter(FilteredProduct product)
        {
            var result = GetAll();
            result = result.Skip(product.page * product.size).Take(product.size).ToList();
            if (product.filter != null)
            {
             result = result.FindAll(x => (x.name.Any(i => product.filter.Contains(i)))).ToList();
            }
            if(product.order != "asc")
            {
               result.Reverse();
            }
            
            return result;
        }

        public List<Product> GetAll()
        {
            return Context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return Context.Products.FirstOrDefault(x => x.id == id);
        }
        public List<Product> GetProductByCategoryID(int CategoryId)
        {
            var res = Context.Products.Where(x => (CategoryId > 0)?x.categoryId == CategoryId:true).ToList();
            return res; 
        }

        public Product newUpdate(int id, ProductDto product)
        {
            try
            {
                var product1 = GetById(id);
                if (product1 != null)
                {
                    product1.categoryId = product.CategoryId;
                    product1.price = product.Price;
                    product1.quantity = product.Quentity;
                    product1.name = product.Name;
                    product1.imagePath = product.imagePath;
                    int re = Context.SaveChanges();
                    if(re > 0)
                        return product1;
                    return null;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
            }

            public Product update(int id, Product item)
            {
            try
            {
                var pro = this.GetById(id);
                pro.categoryId = item.categoryId;
                pro.name = item.name;
                pro.quantity = item.quantity;
                pro.price =item.price;
                Context.Products.Update(pro);
                Context.SaveChanges();
                return pro;
            }
            catch(Exception ex)
            {
                return null;
            }
            }

    }
}
