using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaroVideoWebAPIs.Models
{
    //Modelo para categorias de peliculas
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}