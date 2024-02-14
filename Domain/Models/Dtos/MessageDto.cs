using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Dtos
{
    public class MessageDto
    {
        [Required]public int senderID {  get; set; }
       [Required]public int recieverID { get; set; }
       [Required]public string message { get; set; }

    }
}
