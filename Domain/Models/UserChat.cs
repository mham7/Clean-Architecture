using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class UserChat
{
    [Key]
    [Column("UserChatsID")]
    public int UserChatsId { get; set; }

    [Column("ChatID")]
    public int ChatId { get; set; }

    [Column("SenderID")]
    public int SenderId { get; set; }

    [Column("RecieverID")]
    public int RecieverId { get; set; }

    [ForeignKey("ChatId")]
    [InverseProperty("UserChats")]
    public virtual Chats Chats { get; set; }

    [ForeignKey("RecieverId")]
    [InverseProperty("UserChatRecievers")]
    public virtual User? Reciever { get; set; }

    [ForeignKey("SenderId")]
    [InverseProperty("UserChatSenders")]
    public virtual User? Sender { get; set; }
}
