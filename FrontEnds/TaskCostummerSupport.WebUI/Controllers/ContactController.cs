using CostumerSupport.Dto.ContactDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace TaskCostummerSupport.WebUI.Controllers
{
	[Authorize(Roles ="Member")]
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateContactDto createContactDto)
		{
			var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
			if (token != null)
			{
				var client = _httpClientFactory.CreateClient();
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				createContactDto.SendDate = DateTime.Now;

				var JsonData = JsonConvert.SerializeObject(createContactDto);
				StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("https://localhost:7264/api/Contact", stringContent);
				if (responseMessage != null)
				{
					return RedirectToAction("Index", "Contact");
				}
			}
			return View();
		}
	}
}
