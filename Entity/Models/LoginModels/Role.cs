using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.LoginModels
{
    [Table("role", Schema = "auth")]
    public class Role
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [MaxLength(12)]
        [Column("name")]
        public string Name { get; set; }
    }
}
