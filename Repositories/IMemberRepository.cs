using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IMemberRepository
    {
        MemberDTO Login(string email, string password);
        void Add(MemberDTO member);
        void Update(MemberDTO member);
        List<MemberDTO> GetAll();
    }
}
