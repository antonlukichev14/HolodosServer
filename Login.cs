using System;
using System.IO;

namespace HolodosServer
{
    class Login
    {


        Database database = new Database(Path.Combine(Environment.CurrentDirectory, @"C:\Users\Roman\Desktop\HolodosServer\UserData.txt"));
        public bool LogInProfile(string login, string password)
        {
            bool isLogIn = false;
            for (int i = 0; i < database.lines.Length; i++)
            {

                string[] tempAr = database.lines[i].Split(' ');
                if (tempAr[2] == login)
                {
                    if (tempAr[3] == password)
                    {
                        isLogIn = true;
                    }
                }
            }
            return isLogIn;
        }

        public bool CreateNewUser(User user)
        {
            bool isCreated = false;
            if (!LogInProfile(user.Login, user.Password))
            {
                string writeString = $"{user.Id} {user.Name} {user.Login} {user.Password} {user.IsVip} {user.IsAdmin}";
                using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.CurrentDirectory, @"C:\Users\Roman\Desktop\HolodosServer\UserData.txt"), true))
                {
                    writer.WriteLine(writeString);
                    isCreated = true;
                }
            }
            return isCreated;
        }
    }
}
