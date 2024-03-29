
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using API.Helpers;
using API.MiddleWare;
using API.Extensions;

namespace API
{
    public class Startup
    {

        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
            // Configuration = configuration;
        }

        // public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            services.AddDbContext<StoreContext>(x => x.UseSqlite(_config.GetConnectionString("DefaultConnection")));

            services.AddApplicationServices();
            services.AddSwaggerDocumentation();
            services.AddCors(opt => 
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().WithOrigins("http://localhost:4200");
                   
                });
                opt.AddPolicy("CorsPolicy2", policy =>
                {
                    policy.AllowAnyMethod().WithOrigins("https://localhost:4200");
                   
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleWare>();
            // if (env.IsDevelopment())
            // {
            // app.UseDeveloperExceptionPage();
            app.UseSwaggerDocumentation();
            // }
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");
            app.UseCors("CorsPolicy2");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
