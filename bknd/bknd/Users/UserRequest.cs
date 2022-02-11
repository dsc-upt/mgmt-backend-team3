using System.ComponentModel.DataAnnotations;

namespace bknd.Users
{
    public class UserRequest
    {
       public string Id { get; set; }
        public string Firstname { get; set; }
       
        public string Lastname { get; set; }
        
        public string Email { get; set; }
        
        public string Roles { get; set; }
    }
}