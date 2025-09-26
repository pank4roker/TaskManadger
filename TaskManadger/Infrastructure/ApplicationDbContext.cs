using Microsoft.EntityFrameworkCore;
using TaskManadger.Models;

namespace TaskManadger.Infrastructure;

public class ApplicationDbContext:DbContext
{
    public DbSet<TaskItem> TaskItems { get;set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
}