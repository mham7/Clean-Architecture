using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Dtos;

public class DivDto
{
   [Required] public int DivisionID { get; set; }
    [Required] public string DivisionName { get; set; }

   
}
