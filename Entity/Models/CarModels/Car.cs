using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.CarModels
{
    [Table("Cars", Schema = "NewCar")]
    public class Car
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("year")]
        public string Year { get; set; }
        [Required]
        [Column("type")]
        public string Type { get; set; }
        [Required]
        [Column("company_name")]
        public string CompanyName { get; set; }
        [Required]
        [Column("model")]
        public string Model { get; set; }
        [Required]
        [Column("price")]
        public string Price { get; set; }
        [Required]
        [Column("condition")]
        public string Condition { get; set; }
        //[Required]
        //[Column("image_url")]
        //public string CarImageURL { get; set; }
    }
}
