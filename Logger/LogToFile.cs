using System;
using System.IO;

namespace Logger
{
    public static class LogToFile
    {
        public static void Info(string message)
        {
            using var file = new StreamWriter("info.log", append: true);
            file.WriteLine($"{DateTime.Now:G}: {message}");
        }
    }
}