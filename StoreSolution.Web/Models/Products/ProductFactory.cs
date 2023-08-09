using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreSolution.Web.Models.Products
{
    public class ProductFactory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; } = String.Empty;

        [Required(ErrorMessage = "You need to type a valid Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Material")]
        public string Material { get; set; }

        [DefaultValue("Regular")]
        public string Length { get; set; } = "Regular";

        [DefaultValue("Casual")]
        public string Style { get; set; } = "Causual";
    }
}
