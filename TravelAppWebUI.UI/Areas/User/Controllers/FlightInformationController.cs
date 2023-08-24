using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using TravalAppWebUI.Core.DTO;
using TravalAppWebUI.Core.Result;
using TravelAppWebUI.Helper.Session;

namespace TravelAppWebUI.UI.Areas.User.Controllers
{
    [Area("User")]
    public class FlightInformationController : Controller
    {
        [HttpGet("/User/FlightInformation")]
        public async Task<IActionResult> Index()
        {
            var url = "http://localhost:5138/FlightInformation";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<FlightInformationDTO>>>(restResponse.Content);

            var flightInformations = responseObject.Data;

            return View(flightInformations);
        }
        [HttpGet("/User/FlightInformation/{flightInformationGUID}")]
        public async Task<IActionResult> GetFlightInformation(Guid flightInformationGUID)
        {
            var url = "http://localhost:5138/FlightInformation/" + flightInformationGUID;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + SessionManager.LoggedUser.Token);
            RestResponse restResponse = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<FlightInformationDTO>>(restResponse.Content);

            var flightInformations = responseObject.Data;

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
