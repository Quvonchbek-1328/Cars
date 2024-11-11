using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.LoginModels
{
    [Table("login",Schema ="auth")]
    public class Login
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(12)]
        [Column("username")]
        public string username { get; set; }
        [Column("password")]
        [DataType(DataType.Password)]
        [MaxLength(18)]
        [Required]
        public string password { get; set; }
        [EmailAddress]
        [Email]
        [Column("email")]
        [Required]
        public string email { get; set; }
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("nickname")]
        public string NickName { get; set; }
        [Column("role_id")]
        [Required]
        public int roleId { get; set; }
    }
}
