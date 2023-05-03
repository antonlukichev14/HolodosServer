using System;

namespace HolodosServer
{

    class LogIn
    {
        Database database = new Database();

        public bool LogInProfile(string login, string password)
        {
            bool correctData = false;
            int i = 1;
            for (; i < 100; i++)
            {
                if (login == Convert.ToString(database.ws.Cells[i, 3].Value2))
                {

                    correctData = true;
                    break;
                }
            }
            correctData &= (password == Convert.ToString(database.ws.Cells[i, 4].Value2));
            return correctData;

        }

        public bool CreateNewUser(User user)
        {

            bool userInCreate = false;
            int i = 1;
            for (; i < 100; i++)
            {
                if (Convert.ToString(database.ws.Cells[i, 1].Value2) == null)
                {
                    database.WriteCell(i, 1, Convert.ToString(user.Id));
                    database.WriteCell(i, 2, Convert.ToString(user.Name));
                    database.WriteCell(i, 3, Convert.ToString(user.Login));
                    database.WriteCell(i, 4, Convert.ToString(user.Password));
                    userInCreate = true;
                    break;

                }
            }
            return userInCreate;

        }
    }
}
