using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Division
    {
        [Key] public int Division_id { get; set; }
        public string Division_name { get; set; }
        public int Num_employees { get; set; }

    }
}
