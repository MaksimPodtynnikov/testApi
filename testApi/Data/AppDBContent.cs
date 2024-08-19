using Microsoft.EntityFrameworkCore;

namespace testApi.Data
{
    public class AppDBContent: DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options): base(options) {

        }
        public DbSet<Status> Statuses { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=StatusBase;Username=postgres;Password=112233");
		}
	}
}
