using NETnews.Models;
using System.Collections.Generic;

namespace NETnews.Data.ViewData {
    public class UserCommentsVD {
        public string userId { get; set; }
        public string name { get; set; }
        public List<Comment> comments { get; set; }
    }
}
