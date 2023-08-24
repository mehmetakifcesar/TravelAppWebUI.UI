using Microsoft.AspNetCore.Http;
using TravalAppWebUI.Core.DTO;
using TravelAppWebUI.Helper.Session;
using TravalAppWebUI.Core.ViewModel;



namespace TravelAppWebUI.Helper.Session
{

    public class SessionManager
    {

        public static LoginDTO? LoggedUser
        {
            get => HttpContextHelper.Current.Session.GetObject<LoginDTO>("LoginDTO");
            set => HttpContextHelper.Current.Session.SetObject("LoginDTO", value);
        }


    }
}
