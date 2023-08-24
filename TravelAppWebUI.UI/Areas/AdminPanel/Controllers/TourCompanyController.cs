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
    public class TourCompanyController : Controller
    {
        [HttpGet("/Admin/TourCompany")]
        public async Task<IActionResult> Index()
        {
            var url = "http://localhost:5138/TourCompany";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<TourCompanyDTO>>>(restResponse.Content);

            var tourCompanies = responseObject.Data;

            return View(tourCompanies);
        }

        [HttpPost("/Admin/AddTourCompany")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTourCompany(TourCompanyDTO tourCompany)
        {
            var url = "http://localhost:5138/AddTourCompany";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            var body = JsonConvert.SerializeObject(tourCompany);
            request.AddBody(body, "application/json");
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<TourCompanyDTO>>(restResponse.Content);

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

        [HttpGet("/Admin/TourCompany/{tourCompanyGUID}")]
        public async Task<IActionResult> GetTourCompany(Guid tourCompanyGUID)
        {
            var url = "http://localhost:5138/TourCompany/" + tourCompanyGUID;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<TourCompanyDTO>>(restResponse.Content);

            var tourCompany = responseObject.Data;

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

        [HttpPost("/Admin/UpdateTourCompany")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTourCompany(TourCompanyDTO tourCompany)
        {
            var url = "http://localhost:5138/UpdateTourCompany";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            var body = JsonConvert.SerializeObject(tourCompany);
            request.AddBody(body, "application/json");
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<TourCompanyDTO>>(restResponse.Content);

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


        [HttpPost("/Admin/RemoveTourCompany/{tourCompanyGUID}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveTourCompany(Guid tourCompanyGUID)
        {
            var url = "http://localhost:5138/RemoveTourCompany/" + tourCompanyGUID;
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
