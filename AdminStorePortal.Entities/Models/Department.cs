using System.ComponentModel.DataAnnotations;

namespace AdminStorePortal.Entities;

public class Department
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
