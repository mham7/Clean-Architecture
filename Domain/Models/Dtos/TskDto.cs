using Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Dtos
{
    public class TskDto
    {
        [Required]
        public string TaskDetail { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Compare(nameof(Deadline), ErrorMessage = MagicString.DateMessage)]
        public DateTime Deadline { get; set; }

        [Required]
        public int CreatorID { get; set; }

        [Required]
        public int AssignedID { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
