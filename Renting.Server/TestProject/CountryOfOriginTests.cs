using Microsoft.EntityFrameworkCore;

using Renting.DAL;
using Renting.DAL.Entities;
using Renting.Services;

namespace TestProject
{
    public class CountryOfOriginTests
    {
        private DbContextOptions<RentingDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<RentingDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        private async Task SeedDataAsync(RentingDbContext context)
        {
            // Add test data to the in-memory database
            var countries = new[]
            {
                new CountryOfOrigin { Name = "Country 1", Location = "Location 1", ApprovalRating = 4.5m },
                new CountryOfOrigin { Name = "Country 2", Location = "Location 2", ApprovalRating = 3.2m },
                new CountryOfOrigin { Name = "Country 3", Location = "Location 3", ApprovalRating = 4.0m }
            };

            await context.CountriesOfOrigin.AddRangeAsync(countries);
            await context.SaveChangesAsync();
        }


        [Fact]
        public async Task CanGetCountryOfOriginByIdAsync()
        {
            // Arrange
            using (var context = new RentingDbContext(GetDbContextOptions()))
            {
                await SeedDataAsync(context);
                var countryService = new CountryOfOriginService(context);

                // Act
                var country = await countryService.GetCountryOfOriginByIdAsync(2);

                // Assert
                Assert.NotNull(country);
                Assert.Equal("Country 2", country.Name);
                Assert.Equal("Location 2", country.Location);
                Assert.Equal(3.2m, country.ApprovalRating);
            }
        }

        [Fact]
        public async Task CanAddCountryOfOriginAsync()
        {
            // Arrange
            using (var context = new RentingDbContext(GetDbContextOptions()))
            {
                var countryService = new CountryOfOriginService(context);

                var countryOfOrigin = new CountryOfOrigin
                {
                    Name = "New Country",
                    Location = "New Location",
                    ApprovalRating = 4.7m
                };

                // Act
                await countryService.AddCountryOfOriginAsync(countryOfOrigin);

                // Assert
                var addedCountry = await context.CountriesOfOrigin.FirstOrDefaultAsync(c => c.Name == "New Country");
                Assert.NotNull(addedCountry);
                Assert.Equal("New Location", addedCountry.Location);
                Assert.Equal(4.7m, addedCountry.ApprovalRating);
            }
        }

        [Fact]
        public async Task CanRemoveCountryOfOriginAsync()
        {
            // Arrange
            using (var context = new RentingDbContext(GetDbContextOptions()))
            {
                await SeedDataAsync(context);
                var countryService = new CountryOfOriginService(context);

                var countryToRemove = await context.CountriesOfOrigin.FirstOrDefaultAsync();

                // Act
                await countryService.RemoveCountryOfOriginAsync(countryToRemove.Id);

                // Assert
                var removedCountry = await context.CountriesOfOrigin.FirstOrDefaultAsync(c => c.Id == countryToRemove.Id);
                Assert.Null(removedCountry);
            }
        }
    }
}