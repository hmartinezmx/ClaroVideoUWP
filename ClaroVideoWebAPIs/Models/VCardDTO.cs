using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaroVideoWebAPIs.Models
{
    public class VCardDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public UrlImages UrlImages { get; set; }
        
    }

    public class UrlImages
    {
        public string Vertical { get; set; }
        public string Horizontal { get; set; }
    }


    public interface IImage
    {
        UrlImages GetImages(string imagev, string imageh);
    }

    public class URLsImages : IImage
    {
        protected IImage images;
        public URLsImages(IImage _images)
        {
            this.images = _images;
        }

        public UrlImages GetImages(string imagev, string imageh)
        {
            return this.images.GetImages(imagev, imageh);
        }
    }

    public class GeneralImages : IImage
    {
        public UrlImages GetImages(string imagev, string imageh)
        {
            return new UrlImages()
            {
                Horizontal = imageh + "?size=290x163",
                Vertical = imagev + "?size=200x300"
            };
        }
    }

    public class DetailImages : IImage
    {
        public UrlImages GetImages(string imagev, string imageh)
        {
            return new UrlImages()
            {
                Horizontal = imageh + "?size=675x380",
                Vertical = imagev + "?size=200x300"
            };
        }
    }

}