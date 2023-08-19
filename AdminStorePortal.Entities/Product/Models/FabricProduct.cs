using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStorePortal.Entities;

[Table("FabricProducts")]
public class FabricProduct
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "You need to type a valid Product Material")]
    public string Material { get; set; }

    [DefaultValue("Casual")]
    public string Style { get; set; } = "Casual";

    [DefaultValue("Regular")]
    public string Length { get; set; } = "Length";

    [DisplayName("Chest Length")]
    public float ChestMeasurement { get; set; }
    [DisplayName("Shoulder Width")]
    public float ShoulderMeasurement { get; set; }
    [DisplayName("Sleeve Length")]
    public float SleeveMeasurement { get; set; }
}
