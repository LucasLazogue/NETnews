using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NETnews.Models {
    public class User : Person {
        [Required]
        public string username;
        public List<Comment> comments;
    }
}
