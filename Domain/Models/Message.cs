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

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime? CreatedTime { get; set; }

    [Required]
    [Column("ChatID")]
    public int ChatId { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string MessageDetail { get; set; } = null!;

    public bool? IsRead { get; set; }

    
}
