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
        public async Task<ActionResult<List<SuperHero>>> GetOneHeros(int id)
        {
            var hero = await _context.SuperHeros.FindAsync(id);

            if (hero == null) { 
                return NotFound("Hero Not Found");
            }

            return Ok(hero);
        }
    }
}
