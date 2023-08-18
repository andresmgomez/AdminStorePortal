using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminStorePortal.Entities;

[Table("RetailProducts")]
public class RetailProduct
{
    [Key]
    public int Id { get; set; }
   
    [DefaultValue("Male")]
    public string Gender { get; set; } = "Male";

    [Required(ErrorMessage = "You need to type a valid Product Name")]
    public string Name { get; set; }

    [DefaultValue("Winter")]
    public string Season { get; set; } = "Winter";

    [Required(ErrorMessage = "You need to type a valid Product Size")]
    public string Size { get; set; }

    public string Color { get; set; } = String.Empty;

    [Required(ErrorMessage = "You need to type a valid Product Type")]
    public string Type { get; set; }

    [Required(ErrorMessage = "You need to type a valid Product Price")]
    public decimal Price { get; set; }

    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
}
