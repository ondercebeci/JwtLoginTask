using CostumerSupport.Dto.MenagerContactDtos;
using CostumerSupport.Dto.MenagerDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace TaskCostummerSupport.WebUI.Controllers
{
	[Authorize(Roles = "Menager")]
	public class MenagerContactController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public MenagerContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7264/api/MenagerContact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetMenagerContactDto>>(JsonData);
                return View(values);

            }

            return View();
        }

      

       public async Task<IActionResult> RemoveMenagerContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7264/api/MenagerContact/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","MenagerContact");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMenagerContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7264/api/MenagerContact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateMenagerContactDto>(JsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMenagerContact(UpdateMenagerContactDto updateMenagerContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(updateMenagerContactDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7264/api/MenagerContact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","MenagerContact");
            }
            return View();
        }

		
	}
}
