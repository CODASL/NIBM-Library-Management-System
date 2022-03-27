using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_v1._1.Model
{
    class User
    {
        String token;
        String email;
        String password;
        String userType;
        bool IsLoggedIn;

        public User() { }
        public User(string token, string email, string password, string userType, bool isLoggedIn)
        {
            this.token = token;
            this.email = email;
            this.password = password;
            this.userType = userType;
            IsLoggedIn = isLoggedIn;
        }

        public string Token { get => token; set => token = value; }
        public string Email { get => email; set => email = value; }
        public string Password {set => password = value; }
        public string UserType { get => userType; set => userType = value; }
        public bool IsLoggedIn1 { get => IsLoggedIn; set => IsLoggedIn = value; }
    }
}
