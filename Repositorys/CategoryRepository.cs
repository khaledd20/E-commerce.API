using AngEcommerceProject.Dto;
using AngEcommerceProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngEcommerceProject.Repositorys
{
    public class CategoryRepository :ICategoryRepository
    {
        EcommerceContext Context;
        public CategoryRepository(EcommerceContext context)
        {
            this.Context = context;
        }

        public Category create(Category item)
        {
            try
            {
                Context.Categories.Add(item);
                var result = Context.SaveChanges();
                if (result >  0)
                {
                    return item;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public int delete(Category item)
        {
            Context.Categories.Remove(item);
            return Context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return Context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return Context.Categories.FirstOrDefault(x => x.id == id);
        }

        public Category update(int id , Category item)
        {
            try
            {
                Category Categories = Context.Categories.FirstOrDefault(x => x.id == id);
                if (Categories != null)
                {
                    Categories.name = item.name;
                }
                Context.Categories.Update(Categories);
                var result =  Context.SaveChanges();
                if(result > 0)
                {
                    return Categories;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public List<CategoryProductDto> CatProduct()
        {
           var cat =  Context.Categories.Include(x => x.Products);
            var res = cat.Select(x => new CategoryProductDto
            {
                categoryId = x.id
                ,
                productsNum = x.Products.Count(),
                name = x.name
            }).ToList();
            return res;
        }
    }
}

