using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using Renting.DAL.Entities;

namespace Renting.DAL
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
                MarketPrice = 1000.00m,
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
                MarketPrice = 750,
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
                MarketPrice = 550,
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
                MarketPrice = 650,
                Length = 1000,
                BreakdownFee = 15,
                CountryOfOrigin = сountryOfOrigin3,
                Warehouse = warehouse1,
                Category = category3,
            };



            var discount1 = new Discount() { Value = 15, ActualFrom = new DateTime(2023, 03, 12), ActualTo = new DateTime(2023, 12, 30)};
            var discount2 = new Discount() { Value = 30, ActualFrom = new DateTime(2023, 03, 12), ActualTo = new DateTime(2023, 12, 30) };
            var discount3 = new Discount() { Value = 50, ActualFrom = new DateTime(2023, 03, 12), ActualTo = new DateTime(2023, 12, 30) };



            var customer1 = new Customer() 
            { 
                Name = "Иван",
                Surname = "Петров",
                Age = 20, 
                Height = 180, 
                ShoeSizeRu = 45,
                Discounts = new List<Discount>() { discount1, discount2}
            };

            var customer2 = new Customer() 
            { 
                Name = "Мария",
                Surname = "Петрова",
                Age = 25, 
                Height = 170, 
                ShoeSizeRu = 40,
                Discounts = new List<Discount>() { discount3 }
            };

            var customer3 = new Customer() 
            { 
                Name = "Петр",
                Surname = "Иванов",
                Age = 30, 
                Height = 175, 
                ShoeSizeRu = 42 
            };

            var account = new Account()
            {
                //EmailAddress = "account1@yandex.ru",
                //Password = "account1",
                Inn = "1234567890"
            };

            var seller1 = new Seller()
            {
                Name = "Джон",
                Surname = "Доу"
            };

            var seller2 = new Seller()
            {
                Name = "Джейн",
                Surname = "Хоу"
            };

            var rent1 = new Rent() 
            {
                Account = account,
                StartDate = new DateTime(2023, 03, 12), 
                ExpectedEndDate = new DateTime(2023, 03, 20), 
                Customer = customer1, 
                Item = item1,
                Seller = seller1,
            };

            var rent2 = new Rent()
            {
                Account = account,
                StartDate = new DateTime(2023, 03, 12),
                ExpectedEndDate = new DateTime(2023, 03, 20),
                Customer = customer1,
                Item = item2,
                Seller = seller1,
            };

            var rent3 = new Rent()
            {
                Account = account,
                StartDate = new DateTime(2023, 03, 20),
                ExpectedEndDate = new DateTime(2023, 03, 30),
                Seller = seller2,
                Customer = customer2,
                Item = item3,
            };

            var rent4 = new Rent()
            {
                Account = account,
                StartDate = new DateTime(2023, 03, 20),
                ExpectedEndDate = new DateTime(2023, 03, 30),
                Seller = seller2,
                Customer = customer2,
                Item = item4,
            };

            var rent5 = new Rent()
            {
                Account = account,
                StartDate = new DateTime(2023, 03, 13),
                ExpectedEndDate = new DateTime(2023, 03, 21),
                Seller = seller2,
                Customer = customer3,
                Item = item4
            };

            await db.Rents.AddRangeAsync(rent1, rent2, rent3, rent4, rent5);


            var penaltyType1 = new PenaltyType()
            {
                Name = "Полная поломка снаряжения",
                Description = "Полная поломка снаряжения",
                HarmLevel = HarmLevel.High
            };
            var penaltyType2 = new PenaltyType()
            {
                Name = "Частичнвая поломка снаряжения",
                Description = "Частичнвая поломка снаряжени",
                HarmLevel = HarmLevel.Medium
            };
            var penaltyType3 = new PenaltyType()
            {
                Name = "Наличие незначительных повреждений",
                Description = "Наличие незначительных повреждений",
                HarmLevel = HarmLevel.Low
            };

            var penalty1 = new Penalty() { Value = 10000, Rent = rent1, PenaltyType = penaltyType1 };
            var penalty2 = new Penalty() { Value = 100, Rent = rent2, PenaltyType = penaltyType2 };
            var penalty3 = new Penalty() { Value = 10, Rent = rent3, PenaltyType = penaltyType3 };

            await db.Penalties.AddRangeAsync(penalty1, penalty2, penalty3);
            await db.SaveChangesAsync();
        }
    }
}