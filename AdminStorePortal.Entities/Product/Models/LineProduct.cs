using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Entities;

public class LineProduct
{
    [Key]
    public int Id { get; set; }
    public string? Brand { get; set; } = string.Empty;

    [Required(ErrorMessage = "You need to type a valid Product Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "You need to type a valid Product Price")]
    public float Price { get; set; }

    public string? Color { get; set; } = string.Empty;

    [DefaultValue("Casual")]
    public string Style { get; set; } = "Casual";

    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
}
