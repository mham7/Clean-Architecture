using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("User")]
public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(250)]

    public string FirstName { get; set; } = null!;

    [StringLength(250)]

    public string LastName { get; set; } = null!;

    [StringLength(250)]

    public string Email { get; set; } = null!;

    [StringLength(250)]
    
    public string Password { get; set; } = null!;

    public DateOnly DateOfJoining { get; set; }

    public int Salary { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [Column("DivID")]
    public int DivId { get; set; }

    //[InverseProperty("Reciever")]
    //public virtual ICollection<Chats> ChatRecievers { get; set; } = new List<Chats>();

    //[InverseProperty("Sender")]
    //public virtual ICollection<Chats> ChatSenders { get; set; } = new List<Chats>();

    [ForeignKey("DivId")]
    [InverseProperty("Users")]
    public virtual Division Div { get; set; } = null!;

    [InverseProperty("Creator")]
    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("Assigned")]
    public virtual ICollection<Tasks> TaskAssigneds { get; set; } = new List<Tasks>();

    [InverseProperty("Creator")]
    public virtual ICollection<Tasks> TaskCreators { get; set; } = new List<Tasks>();

    [InverseProperty("Reciever")]
    public virtual ICollection<UserChat> UserChatRecievers { get; set; } = new List<UserChat>();

    [InverseProperty("Sender")]
    public virtual ICollection<UserChat> UserChatSenders { get; set; } = new List<UserChat>();
}
