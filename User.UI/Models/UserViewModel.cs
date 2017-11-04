using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User.UI.Models
{
    public class UserViewModel
    {
    }

    public class UserVewModel
    {
        public UserVewModel()
        {
            Roles = new List<string>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<string> Roles { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}