using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSolution.Web.Models.Products
{
    public class ProductLine
    {
        [ForeignKey(nameof(ProductFactory))]
        public int ProductFactoryId { get; set; }
        public ProductFactory ProductFactory { get; set; }

        [ForeignKey(nameof(ProductPromo))]
        public int ProductPromoId { get; set; }
        public ProductPromo ProductPromo { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Type")]
        public string Type { get; set; }
        
        public string? Color { get; set; }
        
        [Required(ErrorMessage = "You need to type a valid Product Size")]
        public string Size { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Price")]
        public float Price { get; set; }
    }
}
