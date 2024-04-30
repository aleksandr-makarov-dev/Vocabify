using Microsoft.EntityFrameworkCore;
using Vocabify.API.Data.Entities;

namespace Vocabify.API.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Set> Sets { get; set; }
        public DbSet<Term> Terms { get; set; }
    }
}
