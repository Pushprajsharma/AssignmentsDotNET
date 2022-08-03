using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Models
{
    public class EmployeeDbContext : DbContext
    {
		public DbSet<employee> employees { get; set; }

		public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
		 : base(options)
		{

		}

	}
}
