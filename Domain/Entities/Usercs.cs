using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Usercs
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private bool? isAuthenticated;

        public bool IsAuthenticated
        {
            get => isAuthenticated ?? false;
            set => isAuthenticated = value;
        }
    }
}
