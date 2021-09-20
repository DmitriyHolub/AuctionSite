using AuctionSite.EfStaff;
using AuctionSite.EfStaff.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AuctionSite.Services;
using AutoMapper.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using AuctionSite.Models;
using AuctionSite.EfStaff.Models;
using AutoMapper;
using DinkToPdf.Contracts;
using DinkToPdf;
using AuctionSite.EfStaff.Repositories.Interfaces;
using AuctionSite.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AuctionSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public const string AuthName = "AuctionAuth";
        public void ConfigureServices(IServiceCollection services)
        {
            var connectString = Configuration.GetValue<string>("LokalDatabaseAuctionSite");
            services.AddDbContext<AuctionSiteDbContext>(x => x.UseSqlServer(connectString));

            services.AddAuthentication(AuthName)
                .AddCookie(AuthName, x =>
                {
                    x.LoginPath = "/user/Login";
                    x.Cookie.Name = "Auction";
                    x.AccessDeniedPath = "/user/denied";

                });
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
       
            services.AddControllersWithViews();

            registerRepositories(services);
            registerIRepositories(services);
            registerServices(services);
            registerIServices(services);
            registerMapper(services);

            //services.RegisterServices<UserService>();
            //services.RegisterServices<EmailService>();
            //services.RegisterServices<LotService>();
            //services.RegisterServices<ExchangeService>();
            //services.RegisterServices<ReportService>();
            //services.RegisterServices<FileService>();

            //services.AddScoped<IUserService>(x => new UserService(
            //    x.GetService<UserRepository>(),
            //    x.GetService<IHttpContextAccessor>()));
            //services.AddScoped<IEmailService>(x => new EmailService());
            //services.AddScoped<ILotService>(x => new LotService(
            //    x.GetService<LotRepository>(),
            //    x.GetService<EmailService>()));
            //services.AddScoped<IExchangeService>(x => new ExchangeService(
            //x.GetService<ExchangeRateRepository>()));
            //services.AddScoped<IReportService>(x => new ReportService(
            //     x.GetService<IConverter>(),
            //    x.GetService<IWebHostEnvironment>()));
            //services.AddScoped<IFileService>(x => new FileService(
            // x.GetService<IWebHostEnvironment>()));

            //services.AddScoped<IUserRepository>(x => new UserRepository(x.GetService<AuctionSiteDbContext>()));
            //services.AddScoped<ITypeLotRepository>(x => new TypeLotRepository(x.GetService<AuctionSiteDbContext>()));
            //services.AddScoped<IExchangeRateRepository>(x => new ExchangeRateRepository(x.GetService<AuctionSiteDbContext>()));
            //services.AddScoped<ILotImageRepository>(x => new LotImageRepository(x.GetService<AuctionSiteDbContext>()));
            //services.AddScoped<ILotRepository>(x => new LotRepository(x.GetService<AuctionSiteDbContext>()));

            services.AddHttpContextAccessor();
        }
        private void registerRepositories(IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(BaseRepository<>));

            var repositories = assembly.GetTypes()
                .Where(x =>
                    x.IsClass
                    && x.BaseType.IsGenericType
                    && x.BaseType.GetGenericTypeDefinition() == typeof(BaseRepository<>));

            foreach (var repositoryType in repositories)
            {
                services.NiceRegister(repositoryType);
            }
        }
        public void registerServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var allNeededservices = types.Where(x => x.ToString().Contains("Service") && x.IsClass);
            foreach (var service in allNeededservices)
            {
                services.NiceRegister(service);
            }
        }
        public void registerIServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var iServices = types.Where(x => x.ToString().Contains("Service") && x.IsInterface);
            foreach (var iService in iServices)
            {
                var neededClass = types.Single(x => x.GetInterfaces().Contains(iService));
                services.AddScoped(iService, serviceProvider => services.Register(serviceProvider, neededClass));
            }
        }
        private void registerIRepositories(IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(IBaseRepository<>));
            var a = assembly.GetTypes();
            var repositories = assembly.GetTypes()
                .Where(x =>
                    x.IsInterface && x.GetInterfaces().
                    Any(x => x.IsGenericType
                    && x.GetGenericTypeDefinition() == typeof(IBaseRepository<>)));

            foreach (var repositoryType in repositories)
            {
                var neededClass = a.Single(x => x.GetInterfaces().Contains(repositoryType));
                services.AddScoped(repositoryType, serviceProvider => services.Register(serviceProvider, neededClass));
            }
        }

        public void registerMapper(IServiceCollection services)
        {
            var provider = new MapperConfigurationExpression();

            provider.CreateMap<SetLotModel, Lot>();
            provider.CreateMap<Lot, ShowLotsModel>().
                ForMember(nameof(ShowLotsModel.BuyoutPrice),
                config => config.MapFrom(x => Math.Max(x.BuyoutPrice, x.StartPrice))).
            ForMember(nameof(ShowLotsModel.UrlImages),
               config => config.MapFrom(x => x.UrlImages.Select(a => a.Url).ToList()));
            provider.CreateMap<Lot,ShowSelectedLotModel>().
                ForMember(nameof(ShowSelectedLotModel.UrlImages), 
                config => config.MapFrom(x=>x.UrlImages.Select(a=>a.Url).ToList()));
           
            var mapperConfiguration = new MapperConfiguration(provider);
            var mapper = new Mapper(mapperConfiguration);

            services.AddScoped<IMapper>(x => mapper);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
