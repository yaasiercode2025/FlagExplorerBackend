using FlagExplorer.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlagExplorer.Testing.IntegrationsTests
{
    public class RepositoryTest(DatabaseFixture db) : IClassFixture<DatabaseFixture>
    {
        [Fact]
        public async Task Get_All_Countries()
        {
            //Arrange 
            var repository = db.Services.GetRequiredService<ICountryRepository>();
            
            //Act
            var data = await repository.GetAllCountries();
            
            //Assert
            Assert.NotNull(data);
            Assert.NotEmpty(data);
        }

        [Fact]
        public async Task Belguim_Exists_As_A_Country()
        {
            //Arrange 
            var repository = db.Services.GetRequiredService<ICountryRepository>();

            //Act
            var country = await repository.GetCountryByName("Belgium");

            //Assert
            Assert.Equal("Belgium", country.Name);
        }

        [Fact]
        public async Task Population_Of_Italy_IsCorrect()
        {
            //Arrange 
            var repository = db.Services.GetRequiredService<ICountryRepository>();
            
            //Act
            var italy = await repository.GetCountryByName("Italy");

            //Assert
            Assert.False(italy.Population > 59554023);
        }

        [Fact]
        public async Task South_Africa_Population_InCorrect()
        {
            //Arrange 
            var repository = db.Services.GetRequiredService<ICountryRepository>();

            //Act
            var southafrica = await repository.GetCountryByName("South Africa");

            //Assert
            Assert.False(southafrica.Population < 1000);
        }

    }
}
