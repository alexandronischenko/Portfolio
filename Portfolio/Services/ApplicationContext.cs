using Microsoft.EntityFrameworkCore;

namespace Portfolio.Services;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options) : base(options)
    {
        
    }
}