using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETnews.Models {
    public class News {
        [Key]
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        public string img { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string source { get; set; }
        public DateTime date { get; set; }
        public List<Comment> comments { get; set; }

        public int journalistId { get; set; }
        [ForeignKey("journalistId")]
        public Journalist journalist { get; set; }
    }
}
