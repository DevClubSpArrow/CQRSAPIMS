using CQRSAPI.DataModel;
using Microsoft.EntityFrameworkCore;

namespace CQRSAPI.DbSettings
{
    public class AppDbContext:DbContext
    {
        private readonly IConfiguration _configuration;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Employee>().ToTable("Employee");
        }
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<tbl_Employee> tbl_Employee { get; set; }
    }
}
