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

            var account = new Account("test@yandex.ru", "Test123!");

            var category1 = new Category() { Account = account, Name = "����", Note = "����", Description = "����" };
            var category2 = new Category() { Account = account, Name = "������", Note = "������", Description = "������" };
            var category3 = new Category() { Account = account, Name = "������", Note = "������", Description = "������" };



            var �ountryOfOrigin1 = new CountryOfOrigin() { Account = account, Name = "�����", ApprovalRating = 8 };
            var �ountryOfOrigin2 = new CountryOfOrigin() { Account = account, Name = "������", ApprovalRating = 7 };
            var �ountryOfOrigin3 = new CountryOfOrigin() { Account = account, Name = "��������", ApprovalRating = 6 };



            var warehouse1 = new Warehouse() { Account = account, Name = "������ �����", Address = "�� �������" };
            var warehouse2 = new Warehouse() { Account = account, Name = "������ �����", Address = "�� ��������" };



            var item1 = new Item()
            {
                Account = account,
                Name = "����",
                RentalPrice = 100.00m,
                MarketPrice = 1000.00m,
                Length = 150,
                Width = 50,
                BreakdownFee = 1000,
                CountryOfOrigin = �ountryOfOrigin1,
                Warehouse = warehouse1,
                Category = category1
            };

            var item2 = new Item()
            {
                Account = account,
                Name = "�����",
                RentalPrice = 75.00m,
                MarketPrice = 750,
                Length = 100,
                BreakdownFee = 100,
                CountryOfOrigin = �ountryOfOrigin2,
                Warehouse = warehouse2,
                Category = category3,
            };

            var item3 = new Item()
            {
                Account = account,
                Name = "�������",
                RentalPrice = 55.00m,
                MarketPrice = 550,
                Length = 10,
                BreakdownFee = 10,
                CountryOfOrigin = �ountryOfOrigin3,
                Warehouse = warehouse1,
                Category = category3,
            };

            var item4 = new Item()
            {
                Account = account,
                Name = "����",
                RentalPrice = 65.00m,
                MarketPrice = 650,
                Length = 1000,
                BreakdownFee = 15,
                CountryOfOrigin = �ountryOfOrigin3,
                Warehouse = warehouse1,
                Category = category3,
            };



            var discount1 = new Discount() { Value = 15, ActualFrom = new DateTime(2023, 03, 12), ActualTo = new DateTime(2023, 12, 30) };
            var discount2 = new Discount() { Value = 30, ActualFrom = new DateTime(2023, 03, 12), ActualTo = new DateTime(2023, 12, 30) };
            var discount3 = new Discount() { Value = 50, ActualFrom = new DateTime(2023, 03, 12), ActualTo = new DateTime(2023, 12, 30) };



            var customer1 = new Customer()
            {
                Account = account,
                Name = "����",
                Surname = "������",
                Age = 20,
                Height = 180,
                ShoeSizeRu = 45,
                Discounts = new List<Discount>() { discount1, discount2 }
            };

            var customer2 = new Customer()
            {
                Account = account,
                Name = "�����",
                Surname = "�������",
                Age = 25,
                Height = 170,
                ShoeSizeRu = 40,
                Discounts = new List<Discount>() { discount3 }
            };

            var customer3 = new Customer()
            {
                Account = account,
                Name = "����",
                Surname = "������",
                Age = 30,
                Height = 175,
                ShoeSizeRu = 42
            };


            var seller1 = new Seller()
            {
                Account = account,
                Name = "����",
                Surname = "���"
            };

            var seller2 = new Seller()
            {
                Account = account,
                Name = "�����",
                Surname = "���"
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
                Name = "������ ������� ����������",
                Description = "������ ������� ����������",
                HarmLevel = HarmLevel.High
            };
            var penaltyType2 = new PenaltyType()
            {
                Name = "���������� ������� ����������",
                Description = "���������� ������� ���������",
                HarmLevel = HarmLevel.Medium
            };
            var penaltyType3 = new PenaltyType()
            {
                Name = "������� �������������� �����������",
                Description = "������� �������������� �����������",
                HarmLevel = HarmLevel.Low
            };

            var penalty1 = new Penalty() { Name = "�������", Value = 10000, Rent = rent1, PenaltyType = penaltyType1 };
            var penalty2 = new Penalty() { Name = "�������", Value = 100, Rent = rent2, PenaltyType = penaltyType2 };
            var penalty3 = new Penalty() { Name = "�������", Value = 10, Rent = rent3, PenaltyType = penaltyType3 };

            await db.Penalties.AddRangeAsync(penalty1, penalty2, penalty3);
            await db.SaveChangesAsync();
        }
    }
}