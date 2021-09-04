using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace DataBaseLib
{
    public class DataBase
    {
        private MySqlConnection _db;
        private MySqlCommand _command;

        public Message Info;

        public DataBase() { }

        public void Init()
        {
            ConnectionString.Info = Info;
            var connectionString = ConnectionString.Init(@"db_connect.ini");
            _db = new MySqlConnection(connectionString);
            _command = new MySqlCommand { Connection = _db };
            
            Info?.Invoke("[DataBase] Создание экземпляра класса DataBase");
        }

        private void Open()
        {
            Info?.Invoke("[DataBase] Открытие БД");
            _db.Open();
        }

        private void Close()
        {
            Info?.Invoke("[DataBase] Закрытие БД");
            _db.Close();
        }
        
        public List<Product> GetProducts()
        {
            Open();
            var list = new List<Product>();
            
            const string SQL = "SELECT id, name, price FROM tab_products;";
            _command.CommandText = SQL;
            var res = _command.ExecuteReader();
            
            Info?.Invoke("[DataBase] Получение данных из БД");

            if (!res.HasRows)
            {
                Info?.Invoke("[DataBase] Данные отсутствуют");
                return null;
            }

            while (res.Read())
            {
                var id = res.GetUInt32("id");
                var name = res.GetString("name");
                var price = res.GetUInt32("price");
                list.Add(new Product {Id = id, Name = name, Price = price});
            }

            Info?.Invoke("[DataBase] Данные получены");
            
            Close();
            return list;
        }
    }
}