using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminStorePortal.Entities;

[Table("ProductStyles")]
public class ClothingStyle
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "You need to type a valid Product Style")]
    [StringLength(15, MinimumLength = 6, ErrorMessage = "Product Style cannot be less than 6 characters")]
    public string Style { get; set; }
}
