using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Domain.Models.Dtos
{
   public class PostDto
    {
      
      [Required] public int PostId { get; set; }
       [Required] public string? PostTile { get; set; }
       [Required] public string? PostDetail { get; set; }
        [Required]public int CommunityId { get; set; }
        [Required]public int CreatorId { get; set; }
        public DateTime? CreateTime { get; }=DateTime.Now;
        public int? Upvote { get; } = 0;
        public int? Downvote { get; } = 0;
        public List<IFormFile>? PostPics { get; set; }
    }
}
