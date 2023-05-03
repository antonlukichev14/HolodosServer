namespace HolodosServer
{
    public class User
    {
        public uint Id { get; }
        public string Name;
        public string Password;
        public string Login;
        public bool IsAdmin;
        public bool IsVip;
        public User() { }
        public User(uint _Id, string _Name, string _Password, string _Login, bool _IsAdmin, bool _IsVip)
        {
            Id = _Id;
            Name = _Name;
            Password = _Password;
            Login = _Login;
            IsAdmin = _IsAdmin;
            IsVip = _IsVip;
        }
    }
}
