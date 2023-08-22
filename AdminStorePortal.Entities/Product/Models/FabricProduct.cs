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

    [DisplayName("Product Material")]
    [Required(ErrorMessage = "You need to type a valid Product Material")]
    [StringLength(20, MinimumLength = 6, ErrorMessage = "Product Material cannot be less than 6 characters")]
    public string Material { get; set; }

    [DisplayName("Product Style")]
    [Required(ErrorMessage = "You need to type a valid Product Style")]
    [StringLength(15, MinimumLength = 6, ErrorMessage = "Product Style cannot be less than 6 characters")]
    public string Style { get; set; }

    [DisplayName("Product Length")]
    [Required(ErrorMessage = "You need to type a valid Product Material")]
    [StringLength(18, MinimumLength = 6, ErrorMessage = "Product Length cannot be less than 6 characters")]
    public string Length { get; set; }

    [DisplayName("Chest Length")]
    [Range(15.0, 30.0, ErrorMessage = "Chest Measurement has to be between 15 and 30 inches")]
    public float ChestMeasurement { get; set; }

    [DisplayName("Shoulder Width")]
    [Range(15.0, 30.0, ErrorMessage = "Shoulder Measurement has to be between 15 and 30 inches")]
    public float ShoulderMeasurement { get; set; }
    
    [DisplayName("Sleeve Length")]
    [Range(15.0, 30.0, ErrorMessage = "Sleeve Measurement has to be between 15 and 30 inches")]
    public float SleeveMeasurement { get; set; }
}
