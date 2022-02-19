using System;
using bknd.Users;

namespace bknd.UserProfile
{
    public class UserProfileRequest
    {
        public string user { get; set; }
        public string fbLink { get; set; }
        public string phoneNum { get; set; }
        public DateTime birthday { get; set; }
        public string picture { get; set; }
        public string team { get; set; }
    }
}