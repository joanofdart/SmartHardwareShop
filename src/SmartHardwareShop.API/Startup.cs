using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartHardwareShop.Persistence;
using SimpleInjector;
using SmartHardwareShop.Interfaces.UseCases;
using SmartHardwareShop.Implementations;
using SmartHardwareShop.API.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace SmartHardwareShop
{
    public class Startup
    {
        private readonly Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddScoped<IUserService, UserService>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ADMIN", policy => policy.RequireClaim(ClaimTypes.Role, "ADMIN"));
                options.AddPolicy("CUSTOMER", policy => policy.RequireClaim(ClaimTypes.Role, "CUSTOMER"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartHardwareShop", Version = "v1" });
            });
            services.AddSimpleInjector(container, options => {
                options.AddAspNetCore()
                .AddControllerActivation()
                .AddViewComponentActivation();

                options.AddLogging();
            });

            services.AddMemoryCache();

            InitializeContainer();
        }

        public void InitializeContainer()
        {
            container.RegisterPersistence();
            /// Register use cases
            container.Register<IGetCart, GetCart>();
            container.Register<ICreateCart, CreateCart>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(container);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartHardwareShop v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
