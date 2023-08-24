using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TravalAppWebUI.Core.DTO;
using TravalAppWebUI.Core.Result;
using TravelAppWebUI.Helper.Session;

namespace TravelAppWebUI.UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DestinationController : Controller
    {
        [HttpGet("/Admin/Destination")]
        public async Task<IActionResult> Index()
        {
            var url = "http://localhost:5138/Destination";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<DestinationDTO>>>(restResponse.Content);

            var destinations = responseObject.Data;

            return View(destinations);
        }

        [HttpPost("/Admin/AddDestination")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDestination(DestinationDTO Destination)
        {
            var url = "http://localhost:5138/AddDestination";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            var body = JsonConvert.SerializeObject(Destination);
            request.AddBody(body, "application/json");
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<DestinationDTO>>(restResponse.Content);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                return Json(new { success = true, data = responseObject.Data });
            }
            else if (restResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                return Json(new { success = false, ErrorInfo = responseObject.ErrorInfo });
            }
            else
            {
                return Json(new { success = false, ErrorInfo = responseObject.ErrorInfo });
            }

        }

        [HttpGet("/Admin/Destination/{destinationGUID}")]
        public async Task<IActionResult> GetDestination(Guid destinationGUID)
        {
            var url = "http://localhost:5138/Destination/" + destinationGUID;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<DestinationDTO>>(restResponse.Content);

            var destinations = responseObject.Data;

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                return Json(new { success = true, data = responseObject.Data });
            }
            else if (restResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                return Json(new { success = false, ErrorInfo = responseObject.ErrorInfo });
            }
            else
            {
                return Json(new { success = false, ErrorInfo = responseObject.ErrorInfo });
            }
        }

        [HttpPost("/Admin/UpdateDestination")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateDestination(DestinationDTO destination)
        {
            var url = "http://localhost:5138/UpdateDestination";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            var body = JsonConvert.SerializeObject(destination);
            request.AddBody(body, "application/json");
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<DestinationDTO>>(restResponse.Content);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                return Json(new { success = true, data = responseObject.Data });
            }
            else if (restResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                return Json(new { success = false, ErrorInfo = responseObject.ErrorInfo });
            }
            else
            {
                return Json(new { success = false, ErrorInfo = responseObject.ErrorInfo });
            }
        }


        [HttpPost("/Admin/RemoveDestination/{destinationGUID}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveDestination(Guid destinationGUID)
        {
            var url = "http://localhost:5138/RemoveDestination/" + destinationGUID;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<bool>>(restResponse.Content);

            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                return Json(new { success = true, data = responseObject.Data });
            }
            else if (restResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                return Json(new { success = false, ErrorInfo = responseObject.ErrorInfo });
            }
            else
            {
                return Json(new { success = false, ErrorInfo = responseObject.ErrorInfo });
            }
        }
    }
}
