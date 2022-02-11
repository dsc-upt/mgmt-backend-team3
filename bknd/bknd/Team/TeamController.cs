using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bknd.Team
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public TeamController(DataContext datacontext)
        {
            this._datacontext = datacontext;
        }
        [HttpGet]
        public async Task<List<Team>>Get()
        {
            return await _datacontext.teams.ToListAsync();
        }

        [HttpPost]
        public async Task<GetTeamView> Add(AddTeamVieww teamV)
        {
            var teamLead = await _datacontext.users.FirstOrDefaultAsync(x => x.Id == teamV.TeamLeadId);
            try
            {
                var team = new Team
                {
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    Id = Guid.NewGuid().ToString(),
                    GithubLink = teamV.GithubLink,
                    TeamLead = teamLead
                };
                var result = await _datacontext.AddAsync(team);
                await _datacontext.SaveChangesAsync();
                return new GetTeamView
                {
                    GithubLink = team.GithubLink,
                    Id = team.Id,
                    name = team.name,
                    TeamLead = new GetTeamLeadView
                    {
                        Id = team.TeamLead.Id,
                        email = team.TeamLead.Email,
                        FirstName = team.TeamLead.Firstname,
                        LastName = team.TeamLead.Lastname
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }
    }
}