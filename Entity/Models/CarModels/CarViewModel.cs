using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.CarModels
{
    public class CarViewModel
    {
        public string year { get; set; }
        public List<string> car_type { get; set; }
        public List<string> companyName { get; set; }
        public List<string> model { get; set; }
        public List<string> price { get; set; }
        public List<string> car_condition { get; set; }
        public List<string> car_image_url { get; set; }
    }
}
