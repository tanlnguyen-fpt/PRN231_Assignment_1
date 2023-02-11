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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        OrderDetailDAO detailDAO = new OrderDetailDAO();
        public void Add(OrderDetailDTO orderDetail)
        {
            detailDAO.Add(Mapper.mapToEntity(orderDetail));
        }

        public void Delete(int id)
        {
            detailDAO.Delete(id);
        }

        public OrderDetailDTO GetOrderDetailByOrderID(int orderID)
        {
            return Mapper.mapToDTO(detailDAO.GetById(orderID));
        }

        public void Update(OrderDetailDTO orderDetail)
        {
            detailDAO.Update(Mapper.mapToEntity(orderDetail));
        }
    }
}
