using Microsoft.EntityFrameworkCore;

namespace video.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { }
        public DbSet<Video> Videos { get; set; }
    }
}
