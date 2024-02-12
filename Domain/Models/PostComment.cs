using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("PostComment")]
public partial class PostComment
{
    [Key]
    [Column("CommentID")]
    public int CommentId { get; set; }

    [Column(TypeName = "text")]
    public string CommentDetail { get; set; } = null!;

    [Column("CreatorID")]
    public int CreatorId { get; set; }

    [Column("PostID")]
    public int PostId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedTime { get; set; }

    public int? Upvote { get; set; }

    public int? Downvote { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("PostComments")]
    public virtual User Creator { get; set; } = null!;

    [ForeignKey("PostId")]
    [InverseProperty("PostComments")]
    public virtual Post Post { get; set; } = null!;
}
