using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Entities;

[Table("DealProducts")]
public class DealProduct
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "You need to type a valid Minimum Price")]
    public decimal MinimumPrice { get; set; }

    [Required(ErrorMessage = "You need to type a valid Discount Price")]
    public decimal DiscountPrice { get; set; }

    [Required(ErrorMessage = "You need to type a valid Percentage")]
    [DisplayName("Promo Deal")]
    public int PercentageOff { get; set; }
}
