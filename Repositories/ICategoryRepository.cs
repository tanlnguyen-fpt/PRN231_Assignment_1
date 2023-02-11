using BusinessObjects.Model;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> GetCategory();
        void Add(CategoryDTO categoryDTO);
        void Update(CategoryDTO categoryDTO);
        void Delete(int id);
    }
}
