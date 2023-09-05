using Mapster;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.DTOs;
using Models.Entities;
using System.Configuration;

namespace Models
{
   public static class Extensions
   {
      public static IServiceCollection AddRegisterMappingMaster(this IServiceCollection services)
      {
         TypeAdapterConfig<PeopleDto, People>.ForType();
         TypeAdapterConfig<PeopleDto, People>.NewConfig()
            .Map(c => c.Id, c => c.Id)
            .Map(c => c.Name, c => c.Name);
         return services;
      }

      public static IServiceCollection AddDbContextDataAccess(this IServiceCollection services, IConfiguration configuration)
      {         
         services.AddDbContext<DataAccess>(c => 
            c.UseSqlite(configuration.GetConnectionString("DatabaseDefault"), options =>
            {
               options.MigrationsAssembly("WebApi");
            })            
         );
         return services;
      }

      public static IServiceCollection AddRouteOptions(this IServiceCollection services)
      {
         services.Configure<RouteOptions>(configuration =>
         {
            configuration.LowercaseQueryStrings = true;
            configuration.LowercaseUrls = true;
         });
         return services;
      }
   }
}
