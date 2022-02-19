using System;
using bknd.Users;

namespace bknd.UserProfile
{
    public class UserProfile : Entity
    {
        public User user { get; set; }
        public Team.Team team { get; set; }
        public string fbLink { get; set; }
        public string phoneNum { get; set; }
        public DateTime birthday { get; set; }
        public string picture { get; set; }
    }
}