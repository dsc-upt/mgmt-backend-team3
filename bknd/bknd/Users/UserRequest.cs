using System.ComponentModel.DataAnnotations;

namespace bknd.Users
{
    public class UserRequest
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Roles { get; set; }
    }
}