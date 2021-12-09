using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NETnews.Models {
    public class User : IdentityUser {

        [Required(ErrorMessage = "name is Required")]
        public string name { get; set; }

        public List<Comment> comments { get; set; } 
    }
}
