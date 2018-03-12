using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaroVideoWebAPIs.Models
{
    //Modelo Data Transfer Objects para las colecciones de VCards
    public class VCardDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public UrlImages UrlImages { get; set; }
        
    }

}