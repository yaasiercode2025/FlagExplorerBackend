using FlagExplorer.Application.Interfaces;
using FlagExplorer.Application.Services;
using FlagExplorer.Infrastructre.Data;
using FlagExplorer.Infrastructre.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorer.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FlagExplorerContext>(options => options.UseSqlServer(configuration.GetConnectionString("FEConnection"))); ;
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICountryRepository, CountryRepository>();

            return services;
        }
    }
}
