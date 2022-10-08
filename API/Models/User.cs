using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
    }
}
