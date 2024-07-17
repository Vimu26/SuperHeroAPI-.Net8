using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_.Net8.Entities;

namespace SuperHeroAPI_.Net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var heros = new List<SuperHero>{
                new SuperHero {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName= "Peter" ,
                    LastName = "Parker" ,
                    Place ="NewYork"
                }
            };
            return Ok(heros);
        }
    }
}
