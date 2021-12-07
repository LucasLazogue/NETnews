using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NETnews.Models {
    public class User : Person {

        [Required(ErrorMessage = "username is Required")]
        public string username { get; set; }
        public List<Comment> comments { get; set; } 
    }
}
