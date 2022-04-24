using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apirestcore31.Repository;
using apirestcore31.Repository.Models;
using Microsoft.AspNetCore.Cors;

namespace apirestcore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuarios1Controller : ControllerBase
    {
        private readonly webapidemodbDbContext _context;

        public Usuarios1Controller(webapidemodbDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios1
        [HttpGet]
        //method that fill a parameters in a header response named as X-Total-Count
        //and that get all users into a list from DB
        public async Task<ActionResult<IEnumerable<Usuarios1>>> GetUsuarios1s()
        {
            Response.Headers.Add("X-Total-Count", _context.Usuarios1s.ToListAsync().Result.Count.ToString());
            return await _context.Usuarios1s.ToListAsync();
        }

        // GET: api/Usuarios1/5
        //async method that get just one user from DB and need parameters named as id
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios1>> GetUsuarios1(string id)
        {
            var usuarios1 = await _context.Usuarios1s.FindAsync(id);

            if (usuarios1 == null)
            {
                return NotFound();
            }
            
            Response.Headers.Add("X-Total-Count", "1");
            return usuarios1;
        }

        // PUT: api/Usuarios1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //async method that modify one user from DB and need two parameters named as  id and  Usuarios1 Class
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios1(string id, Usuarios1 usuarios1)
        {
            if (id != usuarios1.Usuarioid)
            {
                return BadRequest();
            }

            _context.Entry(usuarios1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Usuarios1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //async method that save a user into the DB and need a usuarios1 class
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult<Usuarios1>> PostUsuarios1(Usuarios1 usuarios1)
        {
            _context.Usuarios1s.Add(usuarios1);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Usuarios1Exists(usuarios1.Usuarioid))
                {
                    _context.Entry(usuarios1).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    //return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarios1", new { id = usuarios1.Usuarioid }, usuarios1);
        }

        // DELETE: api/Usuarios1/5
        //async method that delete a user from the DB and need a parameter named id 
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteUsuarios1(string id)
        {
            var usuarios1 = await _context.Usuarios1s.FindAsync(id);
            if (usuarios1 == null)
            {
                return NotFound();
            }

            _context.Usuarios1s.Remove(usuarios1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Usuarios1Exists(string id)
        {
            return _context.Usuarios1s.Any(e => e.Usuarioid == id);
        }
    }
}
