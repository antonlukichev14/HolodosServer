using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HolodosServer
{
    public class User
    {
        public string Name;
        public string Login;
        public string Password;
        public bool IsAdmin;
        public bool IsVip;
        public User() { }

        public User(string _Name, string _Login, string _Password)
        {
            Login = _Login;
            Password = _Password;
            Name = _Name;
        }
        public User(string _Name, string _Login, string _Password, bool _IsAdmin, bool _IsVip)
        {
            Name = _Name;
            Login = _Login;
            Password = _Password;
            IsAdmin = _IsAdmin;
            IsVip = _IsVip;
        }
        
    }
}
