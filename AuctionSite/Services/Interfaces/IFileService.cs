using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.Services.Interfaces
{
    public interface IFileService
    {
        public string GetPathForImage();

        public string GetfolderPath();

        public string GetImageUrl(long Id);

        public Image resizeImage(Image image, int new_height, int new_width); 

    }
}
