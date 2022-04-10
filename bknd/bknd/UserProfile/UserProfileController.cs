using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bknd.Users;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bknd.UserProfile
{
    [ApiController]
    [Route("api/profiles")]
    public class UserProfileController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UserProfileController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserProfile>>> lala()
        {
            return Ok(await _dataContext.userprofiles.ToListAsync());

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UserProfile> getById(Guid Id)
        {
            var userp = await _dataContext.userprofiles.FirstOrDefaultAsync(x => x.Id == Id.ToString());
            if (userp is null) return null;
            return userp;
        }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserProfile>> Add(UserProfileRequest entity)
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
            return Created("api/profiles", res.Entity);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserProfile>> delete(Guid id)
        {
            var usr = await _dataContext.userprofiles.FirstOrDefaultAsync(x => x.Id == id.ToString());
            if (usr is null) return NotFound();
            _dataContext.userprofiles.Remove(usr);
           await _dataContext.SaveChangesAsync();
           return Created("api/profiles",usr);
        }
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{id}")]
        public async Task<ActionResult<UserProfile>> Update(Guid id, JsonPatchDocument toUpdate)
        {
            var usr = await _dataContext.userprofiles.FirstOrDefaultAsync((x => x.Id == id.ToString()));
            if (usr is null) return NotFound();
          toUpdate.ApplyTo(usr);
          _dataContext.Update(usr);
          await _dataContext.SaveChangesAsync();
          return Created("api/profiles", usr);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserProfile>> UpdateTeam(Guid id, Guid teamId)
        {
            var usr = await _dataContext.userprofiles.FirstOrDefaultAsync(x => x.Id == id.ToString());
            if (usr is null) return NotFound();
            var team = await _dataContext.teams.FirstOrDefaultAsync(x => x.Id == teamId.ToString());
            if (team is null) return BadRequest();
            var newUsr = new UserProfile
            {
                team = team,
                Created = usr.Created,
                Updated = DateTime.UtcNow,
                fbLink = usr.fbLink,
                phoneNum = usr.phoneNum,
                birthday = usr.birthday,
                picture = usr.picture,
                user = usr.user
            };
            return Created("api/profiles", newUsr);
        }

    }
}