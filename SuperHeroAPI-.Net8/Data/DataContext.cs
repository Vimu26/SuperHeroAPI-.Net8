using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_.Net8.Entities;

namespace SuperHeroAPI_.Net8.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {

        }

        //Table Name - SuperHeros
        public DbSet<SuperHero> SuperHeros { get; set; }
    }

   
}
