using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaroVideoWebAPIs.Models
{
    public class VCardDetailDTO : VCardDTO
    {
        public string Actors { get; set; }
        public string Directors { get; set; }
        public string Duration { get; set; }
        public int Year { get; set; }
        public byte VotesAverage { get; set; }
        public string Category { get; set; }
        public string RatingCode { get; set; }
        public string TitleOriginal { get; set; }
        public string Description { get; set; }
        public string DescriptionLarge { get; set; }
    }
}