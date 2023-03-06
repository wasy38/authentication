using System.ComponentModel.DataAnnotations;

namespace authentication.back.Models.Entitys
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
