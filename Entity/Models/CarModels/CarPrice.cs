using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.CarModels
{
    [Table("CarPrice", Schema = "FullCars")]
    public class CarPrice
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("price")]
        public string Price { get; set; }
    }
}
