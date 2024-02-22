using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("Chats")]
public partial class Chats
{
    [Key]
    [Column("ChatID")]
    public int ChatId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedTime { get; set; }


    [InverseProperty("Chats")]
    public virtual ICollection<UserChat> UserChats { get; set; } = new List<UserChat>();
}
