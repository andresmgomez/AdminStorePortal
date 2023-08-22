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

    [Required]
    [Range(20.99, 80.0, ErrorMessage = "Minimum price cannot be less than $20")]
    public decimal MinimumPrice { get; set; }

    [Required]
    [Range(5.0, 35.0, ErrorMessage = "Discount price cannot be larger than $35")]
    public decimal DiscountPrice { get; set; }

    [Required]
    [Range(5, 45, ErrorMessage = "Percentage off cannot be larger than 45 %")]
    public int PercentageOff { get; set; }
}
