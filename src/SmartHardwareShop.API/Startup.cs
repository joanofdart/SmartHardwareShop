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
using static SmartHardwareShop.Persistence.Implementations.LiteDbContext;

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
            services.Configure<LiteDbOptions>(Configuration.GetSection("LiteDbOptions"));
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
            InitializeContainer();
        }

        public void InitializeContainer()
        {
            container.RegisterPersistence();

            /// Cart Use Cases
            container.Register<IGetCart, GetCart>();
            container.Register<IOpenCart, OpenCart>();
            container.Register<ICloseCart, CloseCart>();
            container.Register<IAddToCart, AddToCart>();
            container.Register<IDeleteFromCart, DeleteFromCart>();
            container.Register<ICreateCart, CreateCart>();
            container.Register<IGetAllCarts, GetAllCarts>();

            /// Product Use Cases
            container.Register<IGetProduct, GetProduct>();
            container.Register<ISearchProduct, SearchProduct>();
            container.Register<IGetProducts, GetProducts>();
            container.Register<IAddProduct, AddProduct>();
            container.Register<IUpdateProduct, UpdateProduct>();
            container.Register<IDeleteProduct, DeleteProduct>();
            container.Register<IDeleteAllProducts, DeleteAllProducts>();
            container.Register<IGenerateInitialProducts, GenerateInitialProducts>();

            /// News Use Cases
            container.Register<IGetNews, GetNews>();
            container.Register<IGetAllNews, GetAllNews>();
            container.Register<IAddNews, AddNews>();
            container.Register<IUpdateNews, UpdateNews>();
            container.Register<IDeleteNews, DeleteNews>();
            container.Register<IDeleteAllNews, DeleteAllNews>();

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
