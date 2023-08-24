using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravalAppWebUI.Core.ViewModel
{
    
    public class UserViewModel
    {
        public string? NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserViewModel()
        { 
        }

    }
}
