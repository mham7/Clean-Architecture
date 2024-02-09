using System.ComponentModel.DataAnnotations;

 namespace Domain.Entities
{
    public class Admin
    {

        [Key] public int Employee_Id { get; set; }
        public required string Name { get; set; }

        public required string Location { get; set; }
        public int Salary { get; set; }
    }
}
