﻿using System.ComponentModel.DataAnnotations;

namespace StoreSolution.Web.Models
{
    public class DepartmentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
