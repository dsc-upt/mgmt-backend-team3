using System;

namespace bknd.Team
{
    public class GetTeamView
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string GithubLink { get; set; }
        public GetTeamLeadView TeamLead { get; set; }
        
    }
}