using BusinessObjects.Model;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Util
{
    public class Mapper
    {
        public static MemberDTO mapToDTO(Member member)
        {
            if (member != null)
            {
                MemberDTO memberDTO = new MemberDTO
                {
                    MemberId = member.MemberId,
                    Email = member.Email,
                    Country = member.Country,
                    CompanyName = member.CompanyName,
                    City = member.City,
                    Password = member.Password,
                    Role = member.Role
                };
                return memberDTO;
            }
            else
            {
                return null;
            }

        }

        public static OrderDTO mapToDTO(Order order)
        {
            OrderDTO orderDTO = new OrderDTO
            {
                MemberId = order.MemberId,
                OrderDate = order.OrderDate,
                OrderId = order.OrderId,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                Freight = order.Freight,
            };
            return orderDTO;
        }

        public static OrderDetailDTO mapToDTO(OrderDetail orderDetail)
        {
            OrderDetailDTO orderDetailDTO = orderDetail == null ? null : new OrderDetailDTO
            {
                Discount = (double)orderDetail.Discount,
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                ProductName = orderDetail.Product.ProductName,
                Quantity = orderDetail.Quantity,
                UnitPrice = orderDetail.UnitPrice,
                TotalPrice = (double)orderDetail.UnitPrice * (double)orderDetail.Quantity * (1d - (double)orderDetail.Discount)
            };

            return orderDetailDTO;
        }

        public static ProductDTO mapToDTO(Product product)
        {
            ProductDTO productDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitInStock,
                Weight = product.Weight,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName
            };
            return productDTO;
        }

        public static CategoryDTO mapToDTO(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return categoryDTO;
        }

        public static Member mapToEntity(MemberDTO memberDTO)
        {
            Member member = new Member
            {
                MemberId = memberDTO.MemberId,
                Email = memberDTO.Email,
                Country = memberDTO.Country,
                CompanyName = memberDTO.CompanyName,
                City = memberDTO.City,
                Password = memberDTO.Password,
                Role = memberDTO.Role.ToString()
            };

            return member;
        }

        public static Order mapToEntity(OrderDTO orderDTO)
        {
            Order order = new Order
            {
                MemberId = orderDTO.MemberId,
                OrderDate = orderDTO.OrderDate,
                OrderId = orderDTO.OrderId,
                RequiredDate = orderDTO.RequiredDate,
                ShippedDate = orderDTO.ShippedDate,
                Freight = orderDTO.Freight,
                OrderDetail = mapToEntity(orderDTO.OrderDetail)
            };
            return order;
        }

        public static OrderDetail mapToEntity(OrderDetailDTO orderDetailDTO)
        {
            OrderDetail orderDetail = new OrderDetail
            {
                Discount = (float?)orderDetailDTO.Discount,
                OrderId = orderDetailDTO.OrderId,
                ProductId = orderDetailDTO.ProductId,
                Quantity = orderDetailDTO.Quantity,
                UnitPrice = orderDetailDTO.UnitPrice
            };

            return orderDetail;
        }

        public static Product mapToEntity(ProductDTO productDTO)
        {
            Product product = new Product
            {
                ProductId = productDTO.ProductId,
                ProductName = productDTO.ProductName,
                UnitPrice = productDTO.UnitPrice,
                UnitInStock = productDTO.UnitsInStock,
                Weight = productDTO.Weight,
                CategoryId = productDTO.CategoryId
            };
            return product;
        }

        public static Category mapToEntity(CategoryDTO categoryDTO)
        {
            Category category = new Category
            {
                CategoryId = categoryDTO.CategoryId,
                CategoryName = categoryDTO.CategoryName
            };
            return category;
        }
    }
}
