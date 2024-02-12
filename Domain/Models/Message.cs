using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Message
{
    [Key]
    [Column("MessageID")]
    public int MessageId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedTime { get; set; }

    [Column("ChatID")]
    public int ChatId { get; set; }

    [Column(TypeName = "text")]
    public string MessageDetail { get; set; } = null!;

    public bool? IsRead { get; set; }

    
}
