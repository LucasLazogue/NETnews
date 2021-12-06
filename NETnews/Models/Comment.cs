using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETnews.Models {
    public class Comment {
        [Key, Column(Order=1)]
        public int id { get; set; } 
        [Key, Column(Order=2)]
        public int userId { get; set; }
        [ForeignKey("userId")]
        public User user { get; set; }
        public string text { get; set; }
        [Required]
        public int idNews { get; set; }
        [ForeignKey("idNews")]
        public News news { get; set; }

    }
}
