﻿using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceShop.Application;
using ECommerceShop.Infrastructure;
using Moq;
using Microsoft.AspNetCore.Hosting;
using ECommerceShop.Infrastructure.Persistence;
using Respawn;

namespace ECommerceApplication.Tests
{
    [SetUpFixture]
    public class Testing
    {

        private static IConfiguration _config;
        private static IServiceScopeFactory _scopeFactory;
        private static Respawner _spawner;
        [OneTimeSetUp]
        public async Task RunBeforeAnyTests()
        {
            var builder = WebApplication.CreateBuilder(new string[] { });

            builder.Services.AddControllers();
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices(builder.Configuration);
            builder.Services.AddCors();

            builder.Services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
            w.ApplicationName == "ECommerceShop.API" &&
            w.EnvironmentName == "Development"));

            _config = builder.Configuration;
            _scopeFactory = builder.Services.BuildServiceProvider().GetService<IServiceScopeFactory>()!;

            _spawner = await Respawner.CreateAsync(builder.Configuration.GetConnectionString("ECommerceConnectionString")!, new RespawnerOptions
            {
                TablesToIgnore = new Respawn.Graph.Table[] {
                    "__EFMigrationsHistory"
                }
            });
        }

        public static async Task ResetState()
        {
            await _spawner.ResetAsync(_config.GetConnectionString("ECommerceConnectionString")!);
        }


        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ECommerceShopDbContext>();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();
            var sender = scope.ServiceProvider.GetRequiredService<ISender>();
            return await sender.Send(request);
        }
    }
}