using System.IO;

namespace HolodosServer
{
    class Database
    {
        string filePath;
        public string[] lines;
        public Database(string filePath)
        {
            this.filePath = filePath;
            lines = File.ReadAllLines(filePath);
        }
    }
}
