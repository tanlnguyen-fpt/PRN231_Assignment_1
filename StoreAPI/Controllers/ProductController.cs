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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository = new ProductRepository();
        private readonly IOrderRepository orderRepository = new OrderRepository();
        private readonly IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(productRepository.GetProducts());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                return Ok(productRepository.GetProductById(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByCategory/{id}")]
        public IActionResult GetCategoryId(int id)
        {
            try
            {
                return Ok(productRepository.GetProductsByCategory(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add(ProductDTO product)
        {
            try
            {
                productRepository.SaveProduct(product);

                return Ok("SUCCESS");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(ProductDTO product)
        {
            try
            {
                productRepository.UpdateProduct(product);
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
                productRepository.DeleteProduct(id);

                IEnumerable<OrderDTO> orderList = orderRepository.GetAllOrders();

                foreach (OrderDTO order in orderList)
                {
                    order.OrderDetail = orderDetailRepository.GetOrderDetailByOrderID(order.OrderId);
                    if(order.OrderDetail == null)
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
