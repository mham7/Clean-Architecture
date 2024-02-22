using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class PostCommentDto
    {
        
        public int CommentId { get; set; }
       [Required] public string CommentDetail { get; set; } = null!;

       [Required] public int CreatorId { get; set; }

        [Required]public int PostId { get; set; }

       [Required] public DateTime CreatedTime { get; set; }=DateTime.Now;
    }
}
