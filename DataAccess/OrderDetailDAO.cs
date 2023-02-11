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
    public class OrderDetailDAO
    {

        public IEnumerable<OrderDetail> GetList()
        {
            List<OrderDetail> orderDetails;
            try
            {
                var db = new AppDbContext();
                orderDetails = db.OrderDetails.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetails;
        }

        public OrderDetail GetById(int? id)
        {
            OrderDetail orderDetail = null;
            try
            {
                var db = new AppDbContext();
                orderDetail = db.OrderDetails.Include(c => c.Product).SingleOrDefault(c => c.OrderId == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetail;
        }

        public void Add(OrderDetail orderDetail)
        {
            try
            {
                var db = new AppDbContext();
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetById((int)orderDetail.OrderId);
                if (_orderDetail != null)
                {
                    var db = new AppDbContext();
                    //db.Entry<OrderDetail>(orderDetail).State = EntityState.Modified;
                    db.OrderDetails.Update(orderDetail);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Cannot find Order detail");
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
                OrderDetail _orderDetail = GetById(id);
                if (_orderDetail != null)
                {
                    var db = new AppDbContext();
                    db.OrderDetails.Remove(_orderDetail);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Order detail does not exist!!!");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
