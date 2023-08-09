using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StoreSolution.Web.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product No")]
        [StringLength(8, ErrorMessage = "Product No, needs to start with PRD, hyphen, followed by 4 digit numbers")]
        public string ProductNo { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Name")]
        [StringLength(40, MinimumLength = 20, ErrorMessage = "Product Name needs to be at least 20 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Style")]
        [StringLength(14, MinimumLength = 4, ErrorMessage = "Product Style needs to be at least 4 characters")] 
        public string Style { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Category")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Product Category needs to be at least 5 characters")]
        public string Category { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Size")]
        [StringLength(3, ErrorMessage = "Product Size, needs to start with size S, until XXL")]
        public string Size { get; set; }

        [Required(ErrorMessage = "You need to type a valid Product Price")]
        [Range(30.0, 500.00)]
        public decimal Price { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.UtcNow;





    }
}
