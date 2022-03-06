using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_19webapi.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3_19webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CoreDbContext _coreDbContext;

        public UserController(CoreDbContext coreDbContext)//构造函数
        {
            _coreDbContext = coreDbContext;
        }

        //GET api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getuser()
        {
            return await _coreDbContext.user.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Getuser(int id)
        {
            var user = await _coreDbContext.user.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpPost]
        public async Task<ActionResult<User>> Postuser(User user)
        {
            _coreDbContext.user.Add(user);
            await _coreDbContext.SaveChangesAsync();
            return CreatedAtAction("Postuser", new { id = user.Id, name = user.Username, age = user.Password }, user);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Putuser(int id, User user)
        {
            var olduser = await _coreDbContext.user.FindAsync(id);
            olduser.Username = user.Username;
            _coreDbContext.Entry(olduser).State = EntityState.Modified;
            await _coreDbContext.SaveChangesAsync();
            return olduser;
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<User>> Deleteuser(int id)
        {
            var user = await _coreDbContext.user.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _coreDbContext.user.Remove(user);
            await _coreDbContext.SaveChangesAsync();
            return user;
        }

    }
}
