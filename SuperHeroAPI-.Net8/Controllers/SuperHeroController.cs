using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_.Net8.Data;
using SuperHeroAPI_.Net8.Entities;

namespace SuperHeroAPI_.Net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;
        public SuperHeroController(DataContext context) { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var heros = await _context.SuperHeros.ToListAsync();

            return Ok(heros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetOneHero(int id)
        {
            var hero = await _context.SuperHeros.FindAsync(id);

            if (hero == null) { 
                return NotFound("Hero Not Found");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> createHero(SuperHero hero)
        {
            _context.SuperHeros.Add(hero);
             await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeros.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedHero)
        {
            var dbHero = await _context.SuperHeros.FindAsync(updatedHero.Id);

            if (dbHero == null)
            {
                return NotFound("Hero Not Found");
            }

            dbHero.Name = updatedHero.Name;
            dbHero.FirstName = updatedHero.FirstName;
            dbHero.LastName = updatedHero.LastName; 
            dbHero.Place = updatedHero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeros.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeros.FindAsync(id);

            if (dbHero == null)
            {
                return NotFound("Hero Not Found");
            }

           _context.SuperHeros.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeros.ToListAsync());
        }
    }
}
