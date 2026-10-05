using System;
using System.Collections.Generic;
using WebApplication8.Models;

namespace WebApplication8.Data
{
    public static class AppData
    {
        public static List<RepairRequest> Requests { get; set; }

        private static int _nextId = 1;

        static AppData()
        {
            Requests = new List<RepairRequest>();
            Seed();
        }

        public static int NextId() => _nextId++;

        private static void Seed()
        {
            Requests.Add(new RepairRequest
            {
                Id = NextId(),
                ClientName = "Иванов Иван Иванович",
                Device = "Ноутбук Poco lenovo x18 plus",
                Problem = "Не включается.",
                CreatedAt = DateTime.Now.AddDays(-7),
                Status = RequestStatus.New
            });

            Requests.Add(new RepairRequest
            {
                Id = NextId(),
                ClientName = "Петрова Анна Петровна",
                Device = "Смартфон Samsung Galaxy Iphone Poco 18 pro max",
                Problem = "Разбит экран",
                CreatedAt = DateTime.Now.AddDays(-5),
                Status = RequestStatus.InProgress
            });

            Requests.Add(new RepairRequest
            {
                Id = NextId(),
                ClientName = "Алексеев Алексей Алексеевич",
                Device = "Принтер HP",
                Problem = "съел бумагу",
                CreatedAt = DateTime.Now.AddDays(-3),
                Status = RequestStatus.Completed
            });

            Requests.Add(new RepairRequest
            {
                Id = NextId(),
                ClientName = "Маринова Марина Мартовна",
                Device = "ПланшетAir",
                Problem = "не заряжается.",
                CreatedAt = DateTime.Now.AddDays(-2),
                Status = RequestStatus.New
            });

            Requests.Add(new RepairRequest
            {
                Id = NextId(),
                ClientName = "Викторов Виктор Викторович",
                Device = "Монитор pro kruto nazvanie",
                Problem = "не хочет работать",
                CreatedAt = DateTime.Now.AddDays(-1),
                Status = RequestStatus.Cancelled
            });
        }
    }
}