using Microsoft.AspNetCore.Mvc;
using TravalAppWebUI.Core.ViewModel;
using TravelAppWebUI.Helper.Session;

namespace TravelAppWebUI.UI.Areas.AdminPanel.Controllers
{


    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("/Admin/Anasayfa")]
        public IActionResult Index()
        {

            UserViewModel user = new UserViewModel()
            {
                NameSurname = SessionManager.LoggedUser.NameSurname,
                Email = SessionManager.LoggedUser.Email,
                Password = SessionManager.LoggedUser.Password,
              
            };


            return View(user);

        }
    }
}
