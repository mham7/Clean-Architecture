using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Trainee
    {
        [Key] public int Employee_Id { get; set; }

        public required string Name { get; set; }
        public int Division_id { get; set; }

        public int Tenure_year { get; set; }

      
        public int Salary { get; set; }
    }
}
