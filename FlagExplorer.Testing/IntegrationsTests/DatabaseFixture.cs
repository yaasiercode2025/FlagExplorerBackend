using DotNet.Testcontainers.Builders;
using FlagExplorer.Api;
using FlagExplorer.Application.Interfaces;
using FlagExplorer.Infrastructre.Data;
using FlagExplorer.Infrastructre.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MsSql;

namespace FlagExplorer.Testing.IntegrationsTests
{
    public class DatabaseFixture : IAsyncLifetime
    { 
        public IServiceProvider Services;
        private readonly MsSqlContainer _container;

        public DatabaseFixture() 
        {
            _container = new MsSqlBuilder().Build();

            var services = new ServiceCollection();

            services.AddDbContext<FlagExplorerContext>(options => options.UseSqlServer(_container.GetConnectionString()));
            services.AddTransient<ICountryRepository, CountryRepository>();

            Services = services.BuildServiceProvider();

        }

        public async Task InitializeAsync()
        {
            await _container.StartAsync();
            var context = Services.GetRequiredService<FlagExplorerContext>();
            await context.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await _container.StopAsync();
        }
    }
}

