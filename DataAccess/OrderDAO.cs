using BusinessObjects.Data;
using BusinessObjects.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {

        public IEnumerable<Order> GetList()
        {
            List<Order> orders;
            try
            {
                var db = new AppDbContext();
                orders = db.Orders.Include(o => o.OrderDetail).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

        public IEnumerable<Order> SearchByUserId(int id)
        {
            List<Order> orders;
            try
            {
                var db = new AppDbContext();
                orders = db.Orders.ToList().FindAll(c => c.MemberId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

        public Order GetById(int id)
        {
            Order order = null;
            try
            {
                var db = new AppDbContext();
                order = db.Orders.SingleOrDefault(c => c.OrderId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }

        public void Add(Order order)
        {
            try
            {
                var db = new AppDbContext();
                db.Orders.Add(order);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Order order)
        {
            try
            {
                Order _order = GetById(order.OrderId);
                if (_order != null)
                {
                    var db = new AppDbContext();
                    //db.Entry<Order>(order).State = EntityState.Modified;
                    db.Orders.Update(order);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find Order");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                Order _order = GetById(id);
                if (_order != null)
                {
                    var db = new AppDbContext();
                    db.Orders.Remove(_order);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Order does not exist!!!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
