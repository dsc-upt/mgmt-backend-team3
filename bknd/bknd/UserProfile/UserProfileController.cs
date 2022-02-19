using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bknd.UserProfile
{
    [ApiController]
    [Route("api/profiles")]
    public class UserProfileController
    {
        private readonly DataContext _dataContext;

        public UserProfileController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        
        [HttpGet]
        public async Task<List<UserProfile>>lala()
        {
            return await _dataContext.userprofiles.ToListAsync();

        }

        [HttpPost]
        public async Task<UserProfile> Add(UserProfileRequest entity)
        {
            var usr = await _dataContext.users.FirstOrDefaultAsync(x => x.Id == entity.user);
            var team = await _dataContext.teams.FirstOrDefaultAsync(x => x.Id == entity.team);
            if (usr is null || team is null || !Verify.phoneNumber(entity.phoneNum)) return null;
        
            var usrprf = new UserProfile
            {
                user = usr,
                team = team,
                birthday = entity.birthday,
                picture = entity.picture,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                fbLink = entity.fbLink,
                Id = Guid.NewGuid().ToString(),
                phoneNum = entity.phoneNum
            };
            var res =await _dataContext.userprofiles.AddAsync(usrprf);
            await _dataContext.SaveChangesAsync();
            return res.Entity;
        }
    }
}