using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("PostImage")]
public partial class PostImage
{
    [Key]
    [Column("PostImgID")]
    public int PostImgId { get; set; }

    public byte[]? PostImg { get; set; }

    [Column("PostID")]
    public int PostId { get; set; }

    [ForeignKey("PostId")]
    [InverseProperty("PostImages")]
    public virtual Post Post { get; set; } = null!;
}
