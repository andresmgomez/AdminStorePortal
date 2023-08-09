using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreSolution.Web.Models.Products
{
    public class ProductPromo
    {

        [Key]
        public int Id { get; set; }

        public int RetailProductNo { get; set; }
        public ProductLine RetailProduct { get; set; }

        [Required(ErrorMessage = "You need to type a valid Minimum Price")]
        public decimal MinimumPrice { get; set; }

        [Required(ErrorMessage = "You need to type a valid Discount Price")]
        public decimal DiscountPrice { get; set; }

        [Required(ErrorMessage = "You need to type a valid Percentage")]
        [DisplayName("Percent Deal")]
        public int PercentageOff { get; set; }
    }
}
