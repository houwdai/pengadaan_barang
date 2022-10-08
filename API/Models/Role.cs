using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
