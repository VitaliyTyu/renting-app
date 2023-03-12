using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using Renting.DAL.Entities;

namespace Lab9.App.DAL
{
    public class RentingDbContextSeed
    {
        public static async Task InitializeDb(RentingDbContext db)
        {
            if (db.Items.Any())
                return;


            var category1 = new Category() { Name = "Лыжи", Note = "Лыжи", Description = "Лыжи" };
            var category2 = new Category() { Name = "Одежда", Note = "Одежда", Description = "Одежда" };
            var category3 = new Category() { Name = "Другое", Note = "Другое", Description = "Другое" };



            var сountryOfOrigin1 = new CountryOfOrigin() { Name = "Китай", ApprovalRating = 8 };
            var сountryOfOrigin2 = new CountryOfOrigin() { Name = "Россия", ApprovalRating = 7 };
            var сountryOfOrigin3 = new CountryOfOrigin() { Name = "Норвегия", ApprovalRating = 6 };



            var warehouse1 = new Warehouse() { Name = "Первый склад", Address = "ул Пушкина" };
            var warehouse2 = new Warehouse() { Name = "Второй склад", Address = "ул Пермская" };



            var item1 = new Item() 
            { 
                Name = "Лыжи", 
                RentalPrice = 100.00m, 
                Length = 150, 
                Width = 50,
                BreakdownFee = 1000,
                CountryOfOrigin = сountryOfOrigin1,
                Warehouse = warehouse1,
                Category = category1
            };

            var item2 = new Item() 
            { 
                Name = "Санки", 
                RentalPrice = 75.00m, 
                Length = 100,
                BreakdownFee = 100,
                CountryOfOrigin = сountryOfOrigin2,
                Warehouse = warehouse2,
                Category = category3,
            };

            var item3 = new Item() 
            { 
                Name = "Карабин",
                RentalPrice = 55.00m,
                Length = 10,
                BreakdownFee = 10,
                CountryOfOrigin = сountryOfOrigin3,
                Warehouse = warehouse1,
                Category = category3,
            };

            var item4 = new Item() 
            { 
                Name = "Трос",
                RentalPrice = 65.00m,
                Length = 1000,
                BreakdownFee = 15,
                CountryOfOrigin = сountryOfOrigin3,
                Warehouse = warehouse1,
                Category = category3,
            };



            var penaltyType1 = new PenaltyType() { Name = "Полная поломка снаряжения", Description = "Полная поломка снаряжения", HarmLevel = HarmLevel.High };
            var penaltyType2 = new PenaltyType() { Name = "Частичнвая поломка снаряжения", Description = "Частичнвая поломка снаряжени", HarmLevel = HarmLevel.Medium };
            var penaltyType3 = new PenaltyType() { Name = "Наличие незначительных повреждений", Description = "Наличие незначительных повреждений", HarmLevel = HarmLevel.Low };



            var penalty1 = new Penalty()
            {
                Value = 1000,
                PenaltyTypes = new List<PenaltyType>() { penaltyType1, penaltyType2 }
            };
            var penalty2 = new Penalty()
            {
                Value = 100,
                PenaltyTypes = new List<PenaltyType>() { penaltyType3 }
            };



            var discount1 = new Discount() { Value = 15, ActualFrom = new DateTime(2023, 03, 12), ActualTo = new DateTime(2023, 12, 30)};
            var discount2 = new Discount() { Value = 30, ActualFrom = new DateTime(2023, 03, 12), ActualTo = new DateTime(2023, 12, 30) };
            var discount3 = new Discount() { Value = 50, ActualFrom = new DateTime(2023, 03, 12), ActualTo = new DateTime(2023, 12, 30) };



            var customer1 = new Customer() 
            { 
                Name = "Иван", 
                Age = 20, 
                Height = 180, 
                ShoeSizeRu = 45,
                Discounts = new List<Discount>() { discount1, discount2}
            };

            var customer2 = new Customer() 
            { 
                Name = "Мария", 
                Age = 25, 
                Height = 170, 
                ShoeSizeRu = 40,
                Discounts = new List<Discount>() { discount3 }
            };

            var customer3 = new Customer() 
            { 
                Name = "Петр", 
                Age = 30, 
                Height = 175, 
                ShoeSizeRu = 42 
            };


            var rent1 = new Rent() 
            { 
                StartDate = new DateTime(2023, 03, 12), 
                ExpectedEndDate = new DateTime(2023, 03, 20), 
                Customer = customer1, 
                Items = new List<Item>() { item1, item2},
                Penalties = new List<Penalty>() { penalty1 },
            };

            var rent2 = new Rent()
            {
                StartDate = new DateTime(2023, 03, 20),
                ExpectedEndDate = new DateTime(2023, 03, 30),
                Customer = customer2,
                Items = new List<Item>() { item3, item4 },
                Penalties = new List<Penalty>() { penalty2 },
            };

            var rent3 = new Rent()
            {
                StartDate = new DateTime(2023, 03, 13),
                ExpectedEndDate = new DateTime(2023, 03, 21),
                Customer = customer3,
                Items = new List<Item>() { item1, item4 },
            };

            var user = new User() 
            { 
                EmailAddress = "test@yandex.ru", 
                Password = "root",
                Name = "user",
                Rents = new List<Rent>() { rent1, rent2, rent3}
            };

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }
    }
}