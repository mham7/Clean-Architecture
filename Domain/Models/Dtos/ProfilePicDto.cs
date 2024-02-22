using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class ProfilePicDto
    {
        [Required]
        public IFormFile ProfilePic1 { get; set; }
        [Required]public int UserId { get; set; }
    }
}
