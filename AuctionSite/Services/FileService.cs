using AuctionSite.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services
{
    public class FileService: IFileService
    {
        private IWebHostEnvironment _webHostEnvironment { get; set; }

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string GetPathForImage()
        {
            return Path.Combine(GetfolderPath(), "LotImages");
        }
        public string GetfolderPath()
        {
            return _webHostEnvironment.WebRootPath;
        }
        public string GetImageUrl(long Id)
        {
            return $"/LotImages/{Id}.jpg";
        }
        public Image resizeImage(Image image, int new_height, int new_width) // test
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }
    }
}
