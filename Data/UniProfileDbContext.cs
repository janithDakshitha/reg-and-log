using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class UniProfileDbContext:DbContext
    {
        public UniProfileDbContext(DbContextOptions<UniProfileDbContext> options):base(options)
        {

        }
        public virtual DbSet<UniProfileModel> UniProfiles { get; set; }
        public virtual DbSet<DegreeModel> Degrees { get; set; }
        public DbSet<WebApplication1.Models.UniAdminModel> UniAdminModel { get; set; }
        public DbSet<WebApplication1.Models.UniAdminLoging> UniAdminLoging { get; set; }
        //public virtual DbSet<UniAdminModel> UniAdmins { get; set; }
    }
}
