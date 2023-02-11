using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using StoreClient.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace StoreClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient client = null;
        private string MemberApiUrl = "";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "https://localhost:7277/api/Member";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberDTO p)
        {
            MemberDTO newProduct = new MemberDTO
            {
                Email = p.Email,
                Password = p.Password,
            };
            HttpResponseMessage response = await client.PostAsJsonAsync(MemberApiUrl+ "/login", newProduct);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        private async Task<MemberDTO> getLoggedUser()
        {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            HttpResponseMessage proRes = await client.GetAsync(MemberApiUrl + "/loggedMember");
            string proData = await proRes.Content.ReadAsStringAsync();
            MemberDTO member = JsonSerializer.Deserialize<MemberDTO>(proData, options);

            return member;
        }
    }
}