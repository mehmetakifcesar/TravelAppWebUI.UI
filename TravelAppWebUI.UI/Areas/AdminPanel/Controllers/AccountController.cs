using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Security.AccessControl;
using TravalAppWebUI.Core.DTO;
using TravalAppWebUI.Core.Result;
using TravalAppWebUI.Core.ViewModel;
using TravelAppWebUI.Helper.Session;
using System.Diagnostics.Eventing.Reader;


namespace TravelAppWebUI.UI.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        [HttpGet("/Admin/Login")]
        public IActionResult Index()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [HttpPost("/Account/Admin/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogin(LoginDTO loginDTO)
        {
            var url = "http://localhost:5138/Login";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(loginDTO);
            request.AddJsonBody(body, "application/json");
            RestResponse restResponse = await client.ExecuteAsync(request);
           
            var responseObject = JsonConvert.DeserializeObject<ApiResult<LoginDTO>>(restResponse.Content);
          
            if (restResponse.StatusCode == HttpStatusCode.NotFound && responseObject?.Data == null)
            {
                ViewBag.LoginError = "Buraya Bir Data Geliyor";
                ViewData["LoginError"] = "Kullanıcı Adı Veya Şifre Yanlış";
                TempData["LoginError"] = "Buraya Başka Bir Data Geliyor";
                return View("Index");
            }
            else if (restResponse.StatusCode != HttpStatusCode.OK)
            {
                ViewData["LoginError"] = "Hata Oluştu";
                return View("Login");
            }

           
            SessionManager.LoggedUser = responseObject.Data;

            return RedirectToAction("Index", "Home");
        }
    }
}
