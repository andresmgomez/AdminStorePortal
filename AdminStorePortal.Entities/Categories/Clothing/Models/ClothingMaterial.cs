using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminStorePortal.Entities;

public class ClothingMaterial
{
    [Key]
    public int Id { get; set; }
    public string Material { get; set; }
}
