using System;
using System.Collections.Generic;
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

        [HttpPost]
        public async Task<User> Post(UserRequest entity)
        {
            var usr = new User
            {
                Id = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname,
                Email = entity.Email,
                Roles = entity.Roles
            };
            var result = await _datacontext.AddAsync(usr);
            await _datacontext.SaveChangesAsync();
            return result.Entity;
        }
        
    }
}