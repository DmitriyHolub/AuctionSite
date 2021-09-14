using AuctionSite.EfStaff.Enum;
using AuctionSite.EfStaff.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services
{
    public class ReportService : IReportService
    {
        public readonly IConverter _converter;
        private IWebHostEnvironment _webHostEnvironment { get; set; }
        private const string pathToFile = "C:/Users/HP/source/repos/AuctionSite/AuctionSite";

        public ReportService(IConverter iConvertor, IWebHostEnvironment webHostEnvironment)
        {
            _converter = iConvertor;
            _webHostEnvironment = webHostEnvironment;
        }

        public byte[] GeneratePdfReport(Lot lot, CurrencyEnum currency)
        {
            var html = $@"
            <!DOCTYPE html>
            <html>
            <head>
            HEard of document
            </head >
            < body>
            <div >
            <h1> {lot.LotName} </h1>
             <pre> {lot.ProductDescription} </pre >
            <img src={_webHostEnvironment.WebRootPath}{lot.UrlImages[0].Url} />
            </ div >
            <div>
             {lot.BuyoutPrice} {currency} 
            </ div >
            </body>
            </html>
            ";

            GlobalSettings globalSettings = new GlobalSettings();
            globalSettings.ColorMode = ColorMode.Color;
            globalSettings.Orientation = Orientation.Portrait;
            globalSettings.PaperSize = PaperKind.A4;
            globalSettings.Margins = new MarginSettings { Top = 25, Bottom = 25 };
            ObjectSettings objectSettings = new ObjectSettings();
            objectSettings.PagesCount = true;
            objectSettings.HtmlContent = html;
            WebSettings webSettings = new WebSettings();
            webSettings.DefaultEncoding = "utf-8";
            HeaderSettings headerSettings = new HeaderSettings();
            headerSettings.FontSize = 15;
            headerSettings.FontName = "Ariel";
            headerSettings.Right = "Page [page] of [toPage]";
            headerSettings.Line = true;
            //FooterSettings footerSettings = new FooterSettings();
            //footerSettings.FontSize = 12;
            //footerSettings.FontName = "Ariel";
            //footerSettings.Center = "This is for demonstration purposes only.";
            //footerSettings.Line = true;
            objectSettings.HeaderSettings = headerSettings;
            //objectSettings.FooterSettings = footerSettings;
            objectSettings.WebSettings = webSettings;
            HtmlToPdfDocument htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings },
            };
            new CustomAssemblyLoadContext().LoadUnmanagedLibrary($"{pathToFile}/libwkhtmltox.dll");
            return _converter.Convert(htmlToPdfDocument);
        }
    }    
}
