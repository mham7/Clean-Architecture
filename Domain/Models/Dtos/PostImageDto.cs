using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class PostImageDto
    {
        [Required]public Byte[] PostImage { get; set; }
        [Required]public int PostID { get; set; }
    }
}
