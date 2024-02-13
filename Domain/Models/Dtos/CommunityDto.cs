using System.ComponentModel.DataAnnotations;

public class CommunityDto
{
    [Required]
    public string CommunityName { get; set; }

    [Required]
    public int DivisionID { get; set; }
}
