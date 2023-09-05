using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace WebApi
{
   public class Program
   {
      public static void Main(string[] args)
      {
         WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
         IConfiguration configuration = builder.Configuration;

         builder.Services.AddDbContextDataAccess(configuration);
         builder.Services.AddRouteOptions();
         builder.Services.AddRegisterMappingMaster();
         builder.Services.AddControllers();
         builder.Services.AddEndpointsApiExplorer();
         builder.Services.AddSwaggerGen();

         WebApplication app = builder.Build();

         if (app.Environment.IsDevelopment())
         {
            app.UseSwagger();
            app.UseSwaggerUI();
         }

         app.UseHttpsRedirection();
         app.UseAuthorization();
         app.MapControllers();
         app.Run();
      }
   }
}