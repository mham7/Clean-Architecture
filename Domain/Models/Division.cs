using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("Division")]
public partial class Division
{
    [Key]
    [Column("DivID")]
    public int DivId { get; set; }

    [Required]
    [StringLength(250)]
    public string? DivName { get; set; }

    [InverseProperty("Div")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
