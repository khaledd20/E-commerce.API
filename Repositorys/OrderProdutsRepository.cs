using AngEcommerceProject.Dto;
using AngEcommerceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngEcommerceProject.Repositorys
{
    public class OrderProdutsRepository : IOrderProductRepository
    {

        
        EcommerceContext Context;
        IProductRepository productRepository;
        IOrderRepository OrderRepository;
        public OrderProdutsRepository(EcommerceContext context, IProductRepository productRepository
            ,IOrderRepository OrderRepository)
        {
            Context = context;
            this.productRepository = productRepository;
            this.OrderRepository = OrderRepository;
        }
        public OrderProducts create(OrderProducts item)
        {
            try
            {
                var availableQuantity = Context.Products.Where(x => x.id == item.ProductId).Select(x => x.quantity).First();
                if (availableQuantity >= item.ProductQuantity)
                {
                    var pro = this.productRepository.GetById(item.ProductId);
                    pro.quantity -= item.ProductQuantity;
                    this.productRepository.update(item.ProductId, pro);
                    this.Context.OrderProducts.Add(item);
                    var order = this.OrderRepository.GetById(item.OrderId);
                    order.TotalPrice += item.ProductTotalPrice;
                    this.OrderRepository.update(item.OrderId, order);
                    var re = Context.SaveChanges();
                    if (re > 0)
                        return item;
                    return null;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public int delete(OrderProducts item)
        {
            try
            {
                var product = productRepository.GetById(item.ProductId);
                product.quantity += item.ProductQuantity;
                productRepository.update(item.ProductId, product);
                var order = this.OrderRepository.GetById(item.OrderId);
                order.TotalPrice -= item.ProductTotalPrice;
                this.OrderRepository.update(item.OrderId,order);
                Context.OrderProducts.Remove(item);
                return Context.SaveChanges();
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public List<OrderProducts> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderProducts GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductsCartDto> getOrderDetails(int OrderId)
        {
            try
            {
                var result =
                        (from OrderP in Context.OrderProducts
                         join Pro in Context.Products on OrderP.ProductId equals Pro.id
                         select new ProductsCartDto
                         {
                             iD = Pro.id,
                             name = Pro.name,
                             img = Pro.imagePath,
                             price = Pro.price,
                             quantity = OrderP.ProductQuantity,
                         }).ToList();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }

            }

        public OrderProducts update(int id, OrderProducts item)
        {
            try
            {
                var old = Context.OrderProducts.FirstOrDefault(x => x.OrderId == item.OrderId && x.ProductId == item.ProductId);
                if (old != null)
                {
                    Context.OrderProducts.Remove(old);
                    var availableQuantity = Context.Products.Where(x => x.id == old.ProductId).Select(x => x.quantity).First();
                    if (availableQuantity >= item.ProductQuantity)
                    {
                        var product = productRepository.GetById(item.ProductId);
                        product.quantity -= item.ProductQuantity;
                        productRepository.update(item.ProductId, product);
                        old.ProductQuantity = item.ProductQuantity;
                        var order = this.OrderRepository.GetById(item.OrderId);
                        order.TotalPrice -= old.ProductTotalPrice;
                        old.ProductTotalPrice = item.ProductQuantity * product.price;
                        order.TotalPrice += old.ProductTotalPrice;
                        this.OrderRepository.update(item.OrderId, order);
                        Context.SaveChanges();
                        return old;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
