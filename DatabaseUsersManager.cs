using HolodosServer.Database;

namespace HolodosServer
{
    //Высокоуровневый класс для работы с базой данных пользователей
    //Здесь все функции, с которыми придётся работать другим разрабочикам
    //P.S. бывший Login.cs
    static class DatabaseUsersManager
    {
        public static User UserEnter(string login, string password)
        {
            User user = null;

            string[] lines = DatabaseUsers.GetString();
            bool isLogIn = false;

            if (lines == null) return null;

            for (int i = 0; i < lines.Length; i++)
            {

                string[] tempAr = lines[i].Split(' ');
                if (tempAr[1] == login)
                {
                    if (tempAr[2] == password)
                    {
                        bool isA = (int.Parse(tempAr[3]) == 1) ? true : false;
                        bool isV = (int.Parse(tempAr[4]) == 1) ? true : false;
                        user = new User(tempAr[0], tempAr[1], tempAr[2], isA, isV); //Перенести все данные из базы данных
                    }
                }
            }
            return user;
        }

        public static bool CreateNewUser(string name, string login, string password)
        {
            if (!UserLoginCheck(login))
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
                if (string.IsNullOrWhiteSpace(strings[i])) break;

                string[] temp = strings[i].Split(' ');
                if (temp[1] == login)
                {
                    a = true;
                    break;
                }
            }
            return a;
        }

        public static User GetUser(string login) //функция ищет пользователя с указанным логином и возвращает экземпляр User с данными из базы данных
        {
            string[] lines = DatabaseUsers.GetString();
            User user = null;
            for (int i = 1; i < lines.Length; i++) // с 1 ибо первая строка это названия колонок
            {

                string[] tempAr = lines[i].Split(' ');
                if (tempAr[1] == login)
                {
                    bool isA = (int.Parse(tempAr[3]) == 1) ? true : false;
                    bool isV = (int.Parse(tempAr[4]) == 1) ? true : false;
                    user = new User(tempAr[0], tempAr[1], tempAr[2], isA, isV); //Перенести все данные из базы данных
                }
            }
            return user;
        }
    }
}
