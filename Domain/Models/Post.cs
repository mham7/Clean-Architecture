using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("Post")]
public partial class Post
{
    [Key]
    [Column("PostID")]
    public int PostId { get; set; }

    [StringLength(250)]
    public string? PostTile { get; set; }

    [Column(TypeName = "text")]
    public string? PostDetail { get; set; }

    [Column("CommunityID")]
    public int CommunityId { get; set; }

    [Column("CreatorID")]
    public int CreatorId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateTime { get; set; }

    public int? Upvote { get; set; }

    public int? Downvote { get; set; }

    [InverseProperty("Post")]
    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    [InverseProperty("Post")]
    public virtual ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();
}
