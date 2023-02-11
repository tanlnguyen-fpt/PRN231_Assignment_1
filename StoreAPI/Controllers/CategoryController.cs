using BusinessObjects.Models;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository = new CategoryRepository();
        private readonly IOrderRepository orderRepository = new OrderRepository();
        private readonly IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(categoryRepository.GetCategory());
        }

        [HttpPost("Add")]
        public IActionResult Add(CategoryDTO category)
        {
            try
            {
                categoryRepository.Add(category);

                return Ok("Success");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(CategoryDTO category)
        {
            try
            {
                categoryRepository.Update(category);

                return Ok("Success");
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

                categoryRepository.Delete(id);

                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrders();
                foreach (OrderDTO order in orderList)
                {
                    order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                    if (order.OrderDetail == null)
                    {
                        orderRepository.Delete(order.OrderId);
                    }
                }
                return Ok("SUCCESS");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
