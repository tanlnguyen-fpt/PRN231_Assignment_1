using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class OrderRepository : IOrderRepository
    {
        OrderDAO orderDAO = new OrderDAO();
        public void Add(OrderDTO order)
        {
            orderDAO.Add(Mapper.mapToEntity(order));
        }

        public void Delete(int id)
        {
            orderDAO.Delete(id);
        }

        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return orderDAO.GetList().Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public IEnumerable<OrderDTO> GetAllOrdersByUserId(int id)
        {
            return orderDAO.SearchByUserId(id).Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public OrderDTO GetOrderById(int id)
        {
            return Mapper.mapToDTO(orderDAO.GetById(id));
        }

        public void Update(OrderDTO order)
        {
            orderDAO.Update(Mapper.mapToEntity(order));
        }
    }
}
