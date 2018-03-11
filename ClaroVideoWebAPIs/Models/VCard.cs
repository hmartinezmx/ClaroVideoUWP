using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaroVideoWebAPIs.Models
{
    public class VCard
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string TitleOriginal { get; set; }
        [Required]
        public string Description { get; set; }
        public string DescriptionLarge { get; set; }
        [Required]
        public string URLImageH { get; set; }
        public string URLImageV { get; set; }
        public string Duration { get; set; }
        public int Year { get; set; }
        public byte VotesAverage { get; set; }

        public string Actors { get; set; }
        public string Directors { get; set; }

        public int RatingCodeId { get; set; }
        public RatingCode RatingCode { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}