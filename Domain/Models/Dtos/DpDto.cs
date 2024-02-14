using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class DpDto
    {
        public byte[] ProfilePic1 { get; set; }
        public int UserId { get; set; }
    }
}
