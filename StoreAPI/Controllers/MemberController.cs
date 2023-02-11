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
    public class MemberController : ControllerBase
    {

        private readonly IMemberRepository memberRepository = new MemberRepository();


        [HttpPost("login")]
        public IActionResult Login(MemberDTO memberDTO)
        {
            try
            {
                MemberDTO member = memberRepository.Login(memberDTO.Email, memberDTO.Password);

                LoggedUser.Instance.User = member;

                return Ok(LoggedUser.Instance.User);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("changePassword")]
        public IActionResult changePass(string email, string password, string newPassword, string confirmNewPassword)
        {
            try
            {
                MemberDTO member = memberRepository.Login(email, password);

                if (!confirmNewPassword.Equals(newPassword)) throw new Exception("Confirm not match");

                member.Password = newPassword;

                memberRepository.Update(member);

                LoggedUser.Instance.User = member;

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("logout")]
        public IActionResult logout()
        {
            try
            {
                LoggedUser.Instance.User = null;

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("loggedMember")]
        public IActionResult loggedUser()
        {
            try
            {
                return Ok(LoggedUser.Instance.User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                List<MemberDTO> memberDTOs = memberRepository.GetAll();
                return Ok(memberDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult register(MemberDTO memberDTO)
        {
            try
            {

                memberDTO.Role = Role.USER.ToString();
                memberRepository.Add(memberDTO);

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("edit")]
        public IActionResult edit(
            string newCompany,
            string newCity,
            string newCountry
        )
        {
            try
            {
                MemberDTO member = LoggedUser.Instance.User;

                member.City = newCity;
                member.Country = newCountry;
                member.CompanyName = newCompany;

                memberRepository.Update(member);

                LoggedUser.Instance.User = member;

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
