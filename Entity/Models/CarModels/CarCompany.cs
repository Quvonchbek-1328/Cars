using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.CarModels
{
    [Table("CarCompanyNames", Schema = "FullCars")]
    public class CarCompany
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Column("company_name")]
        [StringLength(25)]
        public string CompanyName { get; set; }
    }
}
