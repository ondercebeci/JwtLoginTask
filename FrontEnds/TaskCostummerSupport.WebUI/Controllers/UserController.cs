using CostumerSupport.Dto.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace TaskCostummerSupport.WebUI.Controllers
{
	[Authorize(Roles = "Menager")]
	public class UserController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


		[HttpGet]
		public  async Task<IActionResult> Index()
		{
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7264/api/UserList");
            if(responseMessage.IsSuccessStatusCode)
            {
                var JsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetUserDto>>(JsonData);
                return View(values);

            }

			return View();
		}

		[HttpGet]
        public async Task< IActionResult> CreateUser()
        {


            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData=JsonConvert.SerializeObject(createUserDto);
            createUserDto.AppRoleId = 3;
            StringContent stringContent = new StringContent(JsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7264/api/UserList/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User");
            }

            return View();
        }

     public async Task <IActionResult>RemoveUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7264/api/UserList/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7264/api/UserList/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateUserDto>(JsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>UpdateUser(UpdateUserDto updateUserDto)
        {
            var client=_httpClientFactory.CreateClient();
            var JsonData=JsonConvert.SerializeObject(updateUserDto);
            StringContent stringContent= new StringContent(JsonData,Encoding.UTF8,"application/json");
            var responseMessage=await client.PutAsync("https://localhost:7264/api/UserList",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }



    }
}




















