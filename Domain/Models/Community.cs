using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("Community")]
public partial class Community
{
    [StringLength(250)]
    public string CommunityName { get; set; } = null!;

    [Key]
    [Column("DivisionID")]
    public int DivisionId { get; set; }

    [ForeignKey("DivisionId")]
    public virtual Division Division { get; set; } = null!;
}
