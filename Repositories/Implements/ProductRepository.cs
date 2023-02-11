using BusinessObjects.Model;
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
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO = new ProductDAO();
        public void DeleteProduct(int id)
        {
            productDAO.DeleteProduct(id);
        }

        public ProductDTO GetProductById(int id)
        {
            return Mapper.mapToDTO(productDAO.FindProductById(id));
        }

        public List<ProductDTO> GetProducts()
        {
            return productDAO.GetProducts().Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public List<ProductDTO> GetProductsByCategory(int id)
        {
            return productDAO.FindProductByCategoryId(id).Select(p => Mapper.mapToDTO(p)).ToList();
        }

        public void SaveProduct(ProductDTO p)
        {
            productDAO.SaveProduct(Mapper.mapToEntity(p));
        }

        public void UpdateProduct(ProductDTO p)
        {
            productDAO.UpdateProduct(Mapper.mapToEntity(p));
        }
    }
}
