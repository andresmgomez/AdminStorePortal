using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSolution.Web.Models.Products
{
    public class ProductVariation
    {
        [ForeignKey(nameof(ProductFactory))]
        public int ProductFactoryId { get; set; }
        public ProductFactory ProductFactory { get; set; }

        [DefaultValue("Male")]
        public string Gender { get; set; }
        [DefaultValue("Winter")]
        public string Season { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Category")]
        public string Category { get; set; }
    }
}
