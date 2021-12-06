using System.ComponentModel.DataAnnotations;

namespace NETnews.Models {
    public class Person {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
