
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
          var host=  CreateHostBuilder(args).Build();
          using (var scope = host.Services.CreateScope())
          {
            var Services= scope.ServiceProvider;
            var loggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try{
                var context = Services.GetRequiredService<StoreContext>();
                await StoreContextSeed.SeedAsync(context, loggerFactory);
                await context.Database.MigrateAsync();
            }
            catch(Exception ex){
                var logger= loggerFactory.CreateLogger<Program>();
                logger.LogError(ex,"An error occured during migration");
            }
          }
          host.Run();
        }
  public static IHostBuilder CreateHostBuilder(string[] args)=>
        Host.CreateDefaultBuilder(args).
        ConfigureWebHostDefaults(WebBuilder=>
        {
            WebBuilder.UseStartup<Startup>();
        });
    }
}