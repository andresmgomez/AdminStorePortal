using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSolution.Web.Models.Products
{
    public class ProductPromo
    {
        [ForeignKey(nameof(ProductLine))]
        public int ProductLineId { get; set; }
        public ProductLine ProductLine { get; set; }

        [Required(ErrorMessage = "You need to type a valid Minimum Price")]
        public float MinimumPrice { get; set; }

        [Required(ErrorMessage = "You need to type a valid Discount Price")]

        public float DiscountPrice { get; set; }

        [Required(ErrorMessage = "You need to type a valid Percentage")]
        [DisplayName("Percent Deal")]
        public int PercentageOff { get; set; }
    }
}
