using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab5.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [UIHint("Stars")]
        public string Rating { get; set; }
        [UIHint("Frame")]
        [UIHint("Link")]
        public string TrailerLink { get; set; }
        [UIHint("LongText")]
        public string Description { get; set; }

    }
}