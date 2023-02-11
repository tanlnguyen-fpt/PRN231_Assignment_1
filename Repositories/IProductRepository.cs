using BusinessObjects.Model;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        void SaveProduct(ProductDTO p);
        List<ProductDTO> GetProducts();
        List<ProductDTO> GetProductsByCategory(int id);
        ProductDTO GetProductById(int id);
        void UpdateProduct(ProductDTO p);
        void DeleteProduct(int id);
    }
}
