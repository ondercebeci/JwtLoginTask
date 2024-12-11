using CostumerSupport.Dto.MenagerDtos;
using CostumerSupport.Dto.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace TaskCostummerSupport.WebUI.Controllers
{
	[Authorize(Roles = "Menager")]
	public class MenagerController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public MenagerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7264/api/Menager");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetMenagerDto>>(JsonData);
                return View(values);

            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateMenager()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenager(CreateMenagerDto createMenagerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createMenagerDto);
            createMenagerDto.AppRoleId = 3;
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7264/api/Menager/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Menager");
            }

            return View();
        }

        public async Task<IActionResult> RemoveMenager(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7264/api/Menager/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Menager");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMenager(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7264/api/Menager/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMenagerDto>(JsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMenager(UpdateMenagerDto updateMenagerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(updateMenagerDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7264/api/Menager", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Menager");
            }
            return View();
        }
    }
}
