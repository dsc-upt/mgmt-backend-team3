using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bknd.Users
{
    [ApiController]
    [Route("api/[controller]")]
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
        [Route("/{id}")]
        public async Task<User>GetById(Guid id)
        {
            var usr = await _datacontext.users.FirstOrDefaultAsync(x => x.Id == id.ToString());
            if (usr is null) return null;
            return usr;
        }
        [HttpPost]
        public async Task<User> Post(UserRequest entity)
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
                    Roles = entity.Roles
                    
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
      
        
    }
}