using Microsoft.EntityFrameworkCore;

using Moq;

using Renting.DAL.Entities;
using Renting.DAL;
using Renting.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

namespace TestProject
{
    public class ItemsServiceTests
    {
        private readonly DbContextOptions<RentingDbContext> _options;

        public ItemsServiceTests()
        {
            _options = new DbContextOptionsBuilder<RentingDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Fact]
        public async Task GetItem_WithValidId_ReturnsItem()
        {
            // Arrange
            int itemId = 1;
            var item = new Item { Id = itemId, Name = "Test Item" };

            using (var context = new RentingDbContext(_options))
            {
                context.Items.Add(item);
                await context.SaveChangesAsync();
            }

            using (var context = new RentingDbContext(_options))
            {
                var service = new ItemsService(context);

                // Act
                var result = await service.GetItem(itemId, CancellationToken.None);

                // Assert
                Assert.Equal(itemId, result.Id);
                Assert.Equal("Test Item", result.Name);
            }
        }

        [Fact]
        public async Task GetItems_ReturnsAllItems()
        {
            // Arrange
            var items = new List<Item>
        {
            new Item { Id = 1, Name = "Item 1" },
            new Item { Id = 2, Name = "Item 2" },
            new Item { Id = 3, Name = "Item 3" }
        };

            using (var context = new RentingDbContext(_options))
            {
                context.Items.AddRange(items);
                await context.SaveChangesAsync();
            }

            using (var context = new RentingDbContext(_options))
            {
                var service = new ItemsService(context);

                // Act
                var result = await service.GetItems(CancellationToken.None);

                // Assert
                Assert.Equal(items.Count, result.Count);
                Assert.Equal(items.Select(i => i.Id), result.Select(i => i.Id));
            }
        }

        [Fact]
        public async Task CreateItem_ReturnsCreatedItem()
        {
            // Arrange
            var item = new Item { Name = "New Item" };

            using (var context = new RentingDbContext(_options))
            {
                var service = new ItemsService(context);

                // Act
                var result = await service.CreateItem(item, CancellationToken.None);

                // Assert
                Assert.NotNull(result);
                Assert.NotEqual(0, result.Id);
                Assert.Equal("New Item", result.Name);
            }
        }
    }
}
