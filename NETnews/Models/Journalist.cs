using System.ComponentModel.DataAnnotations;

namespace NETnews.Models {
    public class Journalist {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
    }
}
