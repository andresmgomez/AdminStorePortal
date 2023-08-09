using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreSolution.Web.Models.Products
{
    public class ProductMeasurement
    {

        [Key]
        public int Id { get; set; }

        public int StoreProductNo { get; set; }
        public ProductFactory StoreProduct { get; set; }

        [DisplayName("Chest Length")]
        public float ChestMeasurement { get; set; }
        
        [DisplayName("Shoulder Width")]
        public float ShoulderMeasurement { get; set; }

        [DisplayName("Sleeve Length")]
        public float SleeveMeasurement { get; set; }
    }
}
