using System.ComponentModel.DataAnnotations;

namespace NETnews.Data.ViewData {
    public class UserVD {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
    }
}
