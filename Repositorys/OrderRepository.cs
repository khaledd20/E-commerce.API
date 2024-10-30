using AngEcommerceProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngEcommerceProject.Repositorys
{
    public class OrderRepository : IOrderRepository
    {
        public UserManager<User> _userManger;
        public EcommerceContext _context;
        public OrderRepository(UserManager<User> userManager,EcommerceContext context)
        {
            _context = context;
            _userManger = userManager;
        }
        public Order create(Order item)
        {
            try{    _context.Orders.Add(item);
            _context.SaveChanges();
            return item;
        }
            catch(Exception ex)
            {
                return null;
            }

        }

        public int delete(Order item)
        {
            try
            {
                _context.Orders.Remove(item);
               return _context.SaveChanges();
               
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            try
            {
           var old =  _context.Orders.FirstOrDefault(x=>x.Id == id);
                return old;
                
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public Order update(int id, Order item)
        {
            try
            {
                var order = this.GetById(id);
                order.IsCash= true;
                order.TotalPrice = item.TotalPrice;
                this._context.Update(order);
                this._context.SaveChanges();
                return order;
            }
            catch(Exception ex)
            {
                return null;
            }

        }
    }
}
