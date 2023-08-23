using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminStorePortal.Entities;

[Table("LineProducts")]
public class LineProduct
{
    [Key]
    public int Id { get; set; }

    [DisplayName("Product No")]
    [Required(ErrorMessage = "You need to type a valid Product No")]
    [StringLength(10, MinimumLength = 8, ErrorMessage = "Number needs to be followed by 4 digit numbers")]
    public string LineProductNo { get; set; }

    [DisplayName("Product Name")]
    [Required(ErrorMessage = "You need to type a valid Product Name")]
    [StringLength(40, MinimumLength = 20, ErrorMessage = "Name cannot be less than 20 characters")]
    public string Name { get; set; }

    [DisplayName("Product Season")]
    [Required(ErrorMessage = "You need to type a valid Product Season")]
    [StringLength(10, MinimumLength = 6, ErrorMessage = "Season cannot be less than 20 characters")]
    public string Season { get; set; }

    [DisplayName("Product Size")]
    [Required(ErrorMessage = "You need to type a valid Product Size")]
    [StringLength(3, MinimumLength = 1)]
    public string Size { get; set; }

    [DisplayName("Product Color")]
    [Required(ErrorMessage = "You need to type a valid Product Color")]
    [StringLength(15, MinimumLength = 5, ErrorMessage = "Color cannot be less than 5 characters")]
    public string Color { get; set; }

    [DisplayName("Product Type")]
    [Required(ErrorMessage = "You need to type a valid Product Type")]
    [StringLength(10, MinimumLength = 6, ErrorMessage = "Type cannot be less than 6 characters")]
    public string Type { get; set; }

    [DisplayName("Product Price")]
    [Required(ErrorMessage = "You need to type a valid Product Price")]
    [Range(12.99, 100.0, ErrorMessage = "Price cannot be greater than $100")]
    public decimal Price { get; set; }

    [DisplayName("Product Material")]
    public int MaterialId { get; set; }

    [ForeignKey("MaterialId")]
    public ClothingMaterial ClothingMaterial { get; set; }

    [DisplayName("Product Style")]
    public int StyleId { get; set; }
    
    [ForeignKey("StyleId")]
    public ClothingStyle ClothingStyle { get; set; }

    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
}
