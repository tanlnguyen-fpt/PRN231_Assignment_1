using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDTO> GetAllOrders();
        IEnumerable<OrderDTO> GetAllOrdersByUserId(int id);
        OrderDTO GetOrderById(int id);
        void Add(OrderDTO order);
        void Update(OrderDTO order);
        void Delete(int id);
    }
}
