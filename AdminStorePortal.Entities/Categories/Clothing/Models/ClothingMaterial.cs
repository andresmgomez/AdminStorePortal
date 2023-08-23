using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminStorePortal.Entities;

[Table("ProductMaterials")]
public class ClothingMaterial
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "You need to type a valid Product Material")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "Product Material cannot be less than 6 characters")]
    public string Material { get; set; }
}
