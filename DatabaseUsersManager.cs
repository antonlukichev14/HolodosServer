using HolodosServer.Database;

namespace HolodosServer
{
    //Высокоуровневый класс для работы с базой данных пользователей
    //Здесь все функции, с которыми придётся работать другим разрабочикам
    //P.S. бывший Login.cs
    static class DatabaseUsersManager
    {
        public static bool UserEnter(string login, string password)
        {
            string[] lines = DatabaseUsers.GetString();
            bool isLogIn = false;
            for (int i = 0; i < lines.Length; i++)
            {

                string[] tempAr = lines[i].Split(' ');
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

        public static bool CreateNewUser(string name, string login, string password)
        {
            if (UserLoginCheck(login))
            {
                DatabaseUsers.Add(name, login, password);
                return true;
            }
            return false;
        }

        public static bool UserLoginCheck(string login) // тут функция которая сопоставляет логин c базой данных
        {
            bool a = false;
            string[] strings = DatabaseUsers.GetString();

            for (int i = 1; i < strings.Length; i++)
            {
                string[] temp = strings[i].Split(' ');
                if (temp[2] == login)
                {
                    a = true;
                    break;
                }
            }
            return a;
        }
    }
}
