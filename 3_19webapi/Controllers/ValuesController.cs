using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_19webapi.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
namespace _3_19webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //在person里存着
    [EnableCors()]

    public class ValuesController : ControllerBase
    {
        private readonly CoreDbContext _coreDbContext;

        public ValuesController(CoreDbContext coreDbContext)//构造函数
        {
            _coreDbContext = coreDbContext;
        }

        //GET person/login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Getperson()
        {
            return await _coreDbContext.person.ToListAsync();
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Getperson(int id)
        {
            var per = await _coreDbContext.person.FindAsync(id);
            if (per == null)
            {
                return NotFound();
            }
            return per;
        }
        [HttpPost]
        public async Task<ActionResult<Person>> Postperson(Person per)
        {

            _coreDbContext.person.Add(per);
            await _coreDbContext.SaveChangesAsync();
            return CreatedAtAction("Postperson", new { id = per.Id, name = per.Name, age = per.Age }, per);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Person>> Putperson(int id, Person per)
        {
            var oldperson = await _coreDbContext.person.FindAsync(id);
            oldperson.Name = per.Name;
            _coreDbContext.Entry(oldperson).State = EntityState.Modified;
            await _coreDbContext.SaveChangesAsync();
            return oldperson;
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<Person>> Deleteperson(int id)
        {
            var per = await _coreDbContext.person.FindAsync(id);
            if (per == null)
            {
                return NotFound();
            }
            _coreDbContext.person.Remove(per);
            await _coreDbContext.SaveChangesAsync();
            return per;
        }

    }
    
 
}
