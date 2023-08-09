using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreSolution.Web.Models.Products
{
    public class ProductLine
    {
        [Key]
        public int Id { get; set; }
        public int StoreProductNo { get; set; }
        public ProductFactory StoreProduct { get; set; }

        public int DealProductNo { get; set; }
        public ProductPromo DealProduct { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Type")]
        public string Type { get; set; }
        
        public string Color { get; set; } = String.Empty;
        
        [Required(ErrorMessage = "You need to type a valid Product Size")]
        public string Size { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Price")]
        public decimal Price { get; set; }
    }
}
