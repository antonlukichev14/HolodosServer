namespace HolodosServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            LogIn logIn = new LogIn();
            User user = new User(14, "Ivan", "12345", "ivangay", false, false);
            logIn.CreateNewUser(user);



        }
    }
}
