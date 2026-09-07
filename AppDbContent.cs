Using Microsoft.EntityFrameworkCore;
using AssessmentApp.Models;

namespace AssessmentApp.Data
{
  public class AppDbContect : DbContext
  {
    public AppDbContext(DbConhtextOptions<AppDbContext>options) : base(options) {}

    public DbSet<AssessmentItem> AssessmentItems { get; set; }
  }

}
