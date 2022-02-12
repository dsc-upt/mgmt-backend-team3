using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace bknd.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _datacontext;
        
        public UserController(DataContext dataContext)
        {
            this._datacontext = dataContext;
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _datacontext.users.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<User>GetById(Guid id)
        {
            var usr = await _datacontext.users.FirstOrDefaultAsync(x => x.Id == id.ToString());
            if (usr is null) return null;
            return usr;
        }
        [HttpPost]
        public async Task<User> Post(UserAddView entity)
        {
            try
            {
                var usr = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Firstname = entity.Firstname,
                    Lastname = entity.Lastname,
                    Roles = Verify.Roles(entity.Roles)
                    
                };
                if (!Verify.Email(entity.Email))
                    return null;
                usr.Email = entity.Email;
                var result = await _datacontext.AddAsync(usr);
                await _datacontext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
        [HttpDelete]
        [HttpPut]
        [Route("{id}")]

        public async Task<User> AddRole(Guid id, string role)
        {
            var usr = await _datacontext.users.FirstOrDefaultAsync(x => x.Id == id.ToString());
            if (usr is null || usr.Roles.Contains(role))
                return null;
            var rolesList = Verify.GetRolesList(usr.Roles);
            if (rolesList.Contains(role))
                return null;
            rolesList.Add($",{role}");
            var roles = Verify.GetRolesString(rolesList);
            usr.Roles = roles;
            await _datacontext.SaveChangesAsync();
            return usr;
        }
        [HttpPut]
        public async Task<User> Update(UserRequest user)
        {
            var usr = await _datacontext.users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (usr is null) return null;
            usr.Email = user.Email;
            usr.Firstname = user.Firstname;
            usr.Lastname = user.Lastname;
            usr.Roles = user.Roles;
            usr.Updated = DateTime.UtcNow;

            await _datacontext.SaveChangesAsync();
            return usr;
        }
        [HttpDelete]
        public async Task<User> Delete(Guid id)
        {
            var usr = await _datacontext.users.FirstOrDefaultAsync(x => x.Id == id.ToString());
            if (usr is null) return null;
            var result = _datacontext.users.Remove(usr);
            await _datacontext.SaveChangesAsync();
            return usr;
        }
      
        
    }
}