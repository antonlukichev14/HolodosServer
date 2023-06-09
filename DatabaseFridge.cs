using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HolodosServer
{
    static class DatabaseFridge
    {
        static string filePath = Path.Combine(Environment.CurrentDirectory, "data/FridgeData.txt");

        public static string GetFridge()
        {
            string a = "";
            string[] b = null;
            if (File.Exists(filePath)) b = File.ReadAllLines(filePath);

            if (b == null) return a;

            for (int i = 0; i < b.Length; i++)
            {
                a += b[i];
                if (i < b.Length - 1) a += "___";
            }

            return a;
        }
    }
}
