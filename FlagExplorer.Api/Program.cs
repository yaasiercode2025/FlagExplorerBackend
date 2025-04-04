
using AutoMapper;
using FlagExplorer.Application;
using FlagExplorer.Application.DTO;
using FlagExplorer.Application.Interfaces;
using FlagExplorer.Application.Mapper;
using FlagExplorer.Application.Services;
using FlagExplorer.Application.Validators;
using FlagExplorer.Infrastructre.Data;
using FlagExplorer.Infrastructre.Repositories;
using FlagExplorer.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace FlagExplorer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("FlagExplorerPolicy", policy =>
                {
                    var validOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
                    policy.WithOrigins(validOrigins!)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

           
            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            //app.UseAuthorization();

            app.UseCors("FlagExplorerPolicy");
            app.MapControllers();

            app.Run();
        }
    }
}

