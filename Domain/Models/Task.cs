using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("Task")]
public partial class Tasks
{
    [Key]
    [Column("TaskID")]
    public int TaskId { get; set; }

    [Column(TypeName = "text")]
    public string TaskDetail { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Deadline { get; set; }

    [Column("CreatorID")]
    public int CreatorId { get; set; }

    [Column("AssignedID")]
    public int AssignedId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedTime { get; set; }

    [ForeignKey("AssignedId")]
    [InverseProperty("TaskAssigneds")]
    public virtual User Assigned { get; set; } = null!;

    [ForeignKey("CreatorId")]
    [InverseProperty("TaskCreators")]
    public virtual User Creator { get; set; } = null!;
}
