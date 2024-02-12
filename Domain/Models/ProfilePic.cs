using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;


[Table("ProfilePic")]
public partial class ProfilePic
{
    [Column("Profilepic")]
    public byte[]? Profilepic1 { get; set; }

    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
}
