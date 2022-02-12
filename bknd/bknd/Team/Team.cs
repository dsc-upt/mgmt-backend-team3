using System.ComponentModel.DataAnnotations.Schema;
using bknd.Users;

namespace bknd.Team
{
    
    public class Team : Entity
    {
        public User TeamLead { get; set; }
        public string name { get; set; }
        public string GithubLink { get; set; }
        
    }
}