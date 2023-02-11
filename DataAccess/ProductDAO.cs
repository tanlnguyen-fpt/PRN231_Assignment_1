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
    public class ProductDAO
    {

        public List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new AppDbContext())
                {
                    listProducts = context.Products.Include(p => p.Category).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }

        public Product FindProductById(int productId)
        {
            var p = new Product();
            try
            {
                using (var context = new AppDbContext())
                {
                    p = context.Products.Include(p => p.Category).SingleOrDefault(x => x.ProductId == productId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public List<Product> FindProductByCategoryId(int CategoryId)
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new AppDbContext())
                {
                    listProducts = context.Products.Include(p => p.Category).Where(x => x.CategoryId==CategoryId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }

        public void SaveProduct(Product p)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var pDelete = context.Products.SingleOrDefault(x => x.ProductId == id);
                    context.Products.Remove(pDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
