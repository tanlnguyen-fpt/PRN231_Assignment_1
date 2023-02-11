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
    public class CategoryRepository : ICategoryRepository
    {
        CategoryDAO categoryDAO = new CategoryDAO();

        public void Add(CategoryDTO categoryDTO)
        {
            categoryDAO.Add(Mapper.mapToEntity(categoryDTO));
        }

        public void Delete(int id)
        {
            categoryDAO.DeleteCategory(id);
        }

        public List<CategoryDTO> GetCategory()
        {
            return categoryDAO.GetCategories().Select(m => Mapper.mapToDTO(m)).ToList();
        }

        public void Update(CategoryDTO categoryDTO)
        {
            categoryDAO.Update(Mapper.mapToEntity(categoryDTO));
        }
    }
}
