using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HolodosServer
{
    //Класс для получения информации о городах и местах
    static class DatabaseCity
    {
        static string filePath = Path.Combine(Environment.CurrentDirectory, "data/CityData.txt");
        static string placePath = Path.Combine(Environment.CurrentDirectory, "data/places/");

        public static string GetCities()
        {
            string a = "";
            string[] b = null;
            if (File.Exists(filePath)) b = File.ReadAllLines(filePath);

            if (b == null) return a;

            for(int i = 0; i < b.Length; i++)
            {
                a += b[i];
                if (i < b.Length - 1) a += " ";
            }

            return a;
        }

        public static string GetPlaces(int CityID)
        {
            string a = "";
            string[] b = null;

            string _filePath = placePath + CityID + ".txt";
            if (File.Exists(_filePath)) b = File.ReadAllLines(_filePath);

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
