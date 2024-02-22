using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class ChatDto
    {
        [Required] public int ChatId { get; set; }
        [Required] public int UserId { get; set; }
        [Required] public string Name { get; set; }
       [Required] public Byte[] ProfilePic { get; set; }
       [Required] public string TopMessage {  get; set; }
    }
}
