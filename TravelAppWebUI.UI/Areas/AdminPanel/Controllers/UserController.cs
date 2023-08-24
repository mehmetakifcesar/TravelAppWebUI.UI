using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using TravalAppWebUI.Core.DTO;
using TravalAppWebUI.Core.Result;
using TravelAppWebUI.Helper.Session;

namespace TravelAppWebUI.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        [HttpGet("/Admin/User")]
        public async Task<IActionResult> Index()
        {
            var url = "http://localhost:5138/User";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<UserDTO>>>(restResponse.Content);
            
            var users = responseObject.Data;
            return View(users);
        }
        [HttpGet("/Admin/User/{userGUID}")]
        public async Task<IActionResult> GetUsers(Guid userGUID)
        {
            var url = "http://localhost:5138/User"+ userGUID;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<UserDTO>>(restResponse.Content);

            var users = responseObject.Data;
            return View(users);
        }

        [HttpPost("/Admin/RemoveUser/{userGuid}")]
        public async Task<IActionResult> RemoveUser(Guid userGuid)
        {
            var url = "http://localhost:5138/RemoveUser/" + userGuid;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<UserDTO>>(restResponse.Content);

            var users = responseObject.Data;
            return View(users);
        }

    }
}
