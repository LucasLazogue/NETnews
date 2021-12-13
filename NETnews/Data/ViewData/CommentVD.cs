using System.ComponentModel.DataAnnotations;

namespace NETnews.Data.ViewData {
    public class CommentVD {
        [Required]
        public int idNews { get; set; }
        [Required]
        public string idUser { get; set; }
        [Required]
        public string text { get; set; }
    }
}
