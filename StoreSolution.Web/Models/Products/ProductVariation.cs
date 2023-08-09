using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreSolution.Web.Models.Products
{
    public class ProductVariation
    {
        [Key]
        public int Id { get; set; }

        public int StoreProductNo { get; set; }
        public ProductFactory StoreProduct { get; set; }

        [DefaultValue("Male")]
        public string Gender { get; set; } = "Male";

        [DefaultValue("Winter")]
        public string Season { get; set; } = "Winter";

        [Required(ErrorMessage = "You need to type a valid Product Category")]
        public string Category { get; set; }
    }
}
