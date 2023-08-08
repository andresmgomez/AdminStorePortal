using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSolution.Web.Models.Products
{
    public class ProductMeasurement
    {
        [ForeignKey(nameof(ProductFactory))]
        public int ProductFactoryId { get; set; }
        public ProductFactory ProductFactory { get; set; }

        [DisplayName("Chest Length")]
        public float ChestMeasurement { get; set; }
        [DisplayName("Shoulder Width")]
        public float ShoulderMeasurement { get; set; }
        [DisplayName("Sleeve Length")]
        public float SleeveMeasurement { get; set; }
    }
}
