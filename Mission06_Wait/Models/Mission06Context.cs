using Microsoft.EntityFrameworkCore;

namespace Mission006Assignment.Models;

public class Mission06Context : DbContext
{
    public Mission06Context(DbContextOptions<Mission06Context> options) : base(options) // Constructor
    {
        
    }
    
    public DbSet<MovieSubmission> Movies { get; set; }
}