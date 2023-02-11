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
    public class MemberRepository : IMemberRepository
    {
        MemberDAO memberDAO = new MemberDAO();
        public void Add(MemberDTO member)
        {
            memberDAO.SaveMember(Mapper.mapToEntity(member));
        }

        public List<MemberDTO> GetAll()
        {
            return memberDAO.FindAll().Select(m => Mapper.mapToDTO(m)).ToList();
        }

        public MemberDTO Login(string email, string password)
        {
            return Mapper.mapToDTO(memberDAO.FindMemberByEmailPassword(email, password));
        }

        public void Update(MemberDTO member)
        {
            memberDAO.UpdateMember(Mapper.mapToEntity(member));
        }
    }
}
