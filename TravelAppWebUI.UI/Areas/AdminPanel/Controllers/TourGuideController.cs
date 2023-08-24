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
    public class TourGuideController : Controller
    {
        [HttpGet("/Admin/TourGuide")]
        public async Task<IActionResult> Index()
        {
            var url = "http://localhost:5138/TourGuide";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
           request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<TourGuideDTO>>>(restResponse.Content);

            var tourGuides = responseObject.Data;

            return View(tourGuides);
        }

        [HttpPost("/Admin/AddTourGuide")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTourGuide(TourGuideDTO tourGuide)
        {
            var url = "http://localhost:5138/AddTourGuide";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            var body = JsonConvert.SerializeObject(tourGuide);
            request.AddBody(body, "application/json");
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<TourGuideDTO>>(restResponse.Content);

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

        [HttpGet("/Admin/TourGuide/{tourGuideGUID}")]
        public async Task<IActionResult> GetTourGuide(Guid tourGuideGUID)
        {
            var url = "http://localhost:5138/TourGuide/" + tourGuideGUID;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<TourGuideDTO>>(restResponse.Content);

            var tourGuide = responseObject.Data;

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

        [HttpPost("/Admin/UpdateTourGuide")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTourGuide(TourGuideDTO tourGuide)
        {
            var url = "http://localhost:5138/UpdateTourGuide";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            var body = JsonConvert.SerializeObject(tourGuide);
            request.AddBody(body, "application/json");
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<TourGuideDTO>>(restResponse.Content);

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


        [HttpPost("/Admin/RemoveTourGuide/{tourGuideGUID}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveTourGuide(Guid tourGuideGUID)
        {
            var url = "http://localhost:5138/RemoveTourGuide/" + tourGuideGUID;
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
