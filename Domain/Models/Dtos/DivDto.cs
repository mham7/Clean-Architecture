using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Dtos;

public class DivDto
{
   [Required] public int DivID { get; set; }
    [Required] public string DivName { get; set; }

   
}
