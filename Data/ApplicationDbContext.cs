using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LittleMoments.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Moment> Moments { get; set; }
        public DbSet<Baby> Babies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var tagsConverter = new ValueConverter<List<string>?, string>(
                tags => string.Join(",", tags ?? new List<string>()), // Converts List<string> to a comma-separated string
                tags => tags.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()); // Converts comma-separated string back to List<string>

            var tagsComparer = new ValueComparer<List<string>>(
                (c1, c2) => (c1 ?? new List<string>()).SequenceEqual(c2 ?? new List<string>()),
                c => (c ?? new List<string>()).Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => (c ?? new List<string>()).ToList());

            modelBuilder.Entity<Moment>()
                .Property(m => m.Tags)
                .HasConversion(tagsConverter)
                .Metadata
                .SetValueComparer(tagsComparer);
        }
    }
}
