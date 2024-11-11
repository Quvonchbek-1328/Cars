using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.CarModels
{
    [Table("CarModel", Schema = "FullCars")]
    public class CarModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("model")]
        public string Model { get; set; }
    }
}
