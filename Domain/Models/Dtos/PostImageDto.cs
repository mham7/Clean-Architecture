using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class PostImageDto
    {
        public Byte[] PostImage { get; set; }
        public int PostID { get; set; }
    }
}
