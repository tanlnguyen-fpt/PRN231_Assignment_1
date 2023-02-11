using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Implements;
using StoreAPI.Storage;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository = new OrderRepository();
        private readonly IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        private readonly IProductRepository productRepository = new ProductRepository();

        [HttpGet("GetAllOrder")]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrders();
                foreach (OrderDTO order in orderList)
                {
                    order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                }
                return Ok(orderList);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetOrder/{id}")]
        public IActionResult GetId(int id)
        {

            try
            {
                OrderDTO order = orderRepository.GetOrderById(id);
                order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                return Ok(order);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAllMemberOrder/{userid}")]
        public IActionResult GetAll(int userid)
        {
            try
            {
                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrdersByUserId(userid);
                foreach (OrderDTO order in orderList)
                {
                    order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                    order.OrderDetail.CategoryId = productRepository.GetProductById((int)order.OrderDetail.ProductId).CategoryId;
                }
                return Ok(orderList);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("AddOrder")]
        public IActionResult Add(
            OrderDTO newOrder
        )
        {

            try
            {
                ProductDTO orderProduct = productRepository.GetProductById((int)newOrder.OrderDetail.ProductId);

                if(orderProduct.UnitsInStock < newOrder.OrderDetail.Quantity)
                {
                    throw new Exception("Units in stock of " + orderProduct.ProductName + " not enough");
                }

                newOrder.OrderDate = DateTime.Now;
                newOrder.OrderDetail.ProductName = orderProduct.ProductName;
                newOrder.OrderDetail.UnitPrice = orderProduct.UnitPrice;

                orderProduct.UnitsInStock -= (int)newOrder.OrderDetail.Quantity;

                productRepository.UpdateProduct(orderProduct);
                orderRepository.Add(newOrder);

                return Ok("SUCCESS");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                orderDetailRepository.Delete(id);
                orderRepository.Delete(id);
                return Ok("SUCCESS");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
