using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Talabat.Core.Repositories.Contract;
using Talabat.Errors;
using Talabat.Extensions;
using Talabat.Helpers;
using Talabat.Middlwares;
using Talabat.Repository;
using Talabat.Repository.Data;

            var webApplicationBuilder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            #region Configure services
            
            webApplicationBuilder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplicationBuilder.Services.AddSwaggerServices();


            webApplicationBuilder.Services.AddDbContext<StoreContext>(options =>
            options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection"))
            );

            webApplicationBuilder.Services.AddApplicationServices();
            webApplicationBuilder.Services.AddSingleton<IConnectionMultiplexer>((serverProvider) =>
            {
                var connection = webApplicationBuilder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connection);
            });

            #endregion


            var app = webApplicationBuilder.Build();
            
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;   
            var _dbContext = services.GetRequiredService<StoreContext>();
            
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
            	await _dbContext.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(_dbContext);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Erorr has been occured during apply the migration");
            }


// Configure the HTTP request pipeline.
#region Configure Midlwares

             app.UseMiddleware<ExcpetionMiddleware>();


            if (app.Environment.IsDevelopment())
            {
             //app.UseDeveloperExceptionPage();
             app.UseSwaggerMiddlwares();
            }
            
            app.UseStatusCodePagesWithRedirects("/errors/{0}");
            app.UseHttpsRedirection();
            
            app.UseAuthorization();
            
            app.UseStaticFiles();
            app.MapControllers(); 
            #endregion
            
            app.Run();
            