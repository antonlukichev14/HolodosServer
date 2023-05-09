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
        public uint Id { get; }
        public string Login;
        public string Password;
        public string Name;
        public bool IsAdmin;
        public bool IsVip;
        public User() { }
        public User(uint _Id, string _Login, string _Password, string _Name, bool _IsAdmin, bool _IsVip)
        {
            Id = _Id;
            Name = _Name;
            Login = _Login;
            Password = _Password;
            IsAdmin = _IsAdmin;
            IsVip = _IsVip;
        }
    }
}
