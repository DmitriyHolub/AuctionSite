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
            // ���������� ����� ������
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
            registerMapper(services);

            services.RegisterServices<UserService>();

            services.RegisterServices<EmailService>();
            services.RegisterServices<LotService>();
            services.RegisterServices<ExchangeService>();
            services.RegisterServices<ReportService>();
            


            services.RegisterServices<FileService>();// &&&&&&&&&

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


        public void registerMapper(IServiceCollection services)
        {
            var provider = new MapperConfigurationExpression();

            provider.CreateMap<SetLotModel, Lot>();
            provider.CreateMap<Lot, ShowLotsModel>().
                ForMember(nameof(ShowLotsModel.BuyoutPrice),
                config => config.MapFrom(x => Math.Max(x.BuyoutPrice, x.StartPrice))).
            ForMember(nameof(ShowLotsModel.UrlImages),
               config => config.MapFrom(x => x.UrlImages.Select(a => a.Url).ToList()));

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
