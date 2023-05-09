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
        public User(uint _Id, string _Name, string _Login, string _Password, bool _IsVip, bool _IsAdmin)
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
