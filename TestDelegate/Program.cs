using System;
using DataBaseLib;
using Logger;

namespace TestDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            LogToFile.Info("Программа запущена");
            
            var db = new DataBase();
            db.Info = LogToFile.Info;
            db.Info += Console.WriteLine;
            
            db.Init();

            LogToFile.Info("Получение списка продуктов");
            var products = db.GetProducts();

            LogToFile.Info("Вывод списка продуктов");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}: {product.Name}, {product.Price}");
            }
            
            LogToFile.Info("Программа завершена");
        }
    }
}