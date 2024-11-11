using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.CarModels
{
    [Table("CarCondition", Schema = "FullCars")]
    public class CarCondition
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("condition")]
        public string Condition { get; set; }
    }
}
