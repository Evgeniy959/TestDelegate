using System.IO;

namespace DataBaseLib
{
    public static class ConnectionString
    {
        private static string _server;
        private static string _db;
        private static string _user;
        private static string _password;

        public static Message Info;

        public static string Init(string path)
        {
            if (Info != null) Info("Начало чтения конфигурационного файла с данными по подключению к БД");
            
            using var file = new StreamReader(path);
            var temp = file.ReadLine();

            var config = temp.Split('|');
            _server = config[0];
            _db = config[1];
            _user = config[2];
            _password = config[3];
            
            Info?.Invoke("Конец чтения конфигурационного файла с данными по подключению к БД");
            
            return $"Server={_server};Database={_db};Uid={_user};Pwd={_password}";
        }
    }
}