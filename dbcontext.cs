using Microsoft.EntityFrameworkCore;

namespace retroom_last.Models
{
    public class RetrooomDbContext : DbContext
    {
        public RetrooomDbContext(DbContextOptions<RetrooomDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Server=DADj\\sqlexpress;Database=Retroomdb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships in the modelBuilder

            // Each person can have multiple comments
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Person)
                .HasForeignKey(c => c.PersonID);

            // Each person can have multiple restaurants
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Restaurants)
                .WithOne(r => r.Person)
                .HasForeignKey(r => r.PersonID);
            ////each Restaurant belongs to one person
            //modelBuilder.Entity<Restaurant>()
            //    .HasOne(r=>r.Person)
            //    .WithMany(p=>p.Restaurants)
            //    .HasForeignKey(r => r.PersonID);

            // Each restaurant has many comments
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Comments)
                .WithOne(c => c.Restaurant)
                .HasForeignKey(c => c.RestaurantID);
            //each comment belongs to one restaurant
            modelBuilder.Entity<Comment>().
                HasOne(c => c.Restaurant)
                .WithMany(r => r.Comments)
                .HasForeignKey(r => r.RestaurantID);
            //each Comment belongs to on person
            modelBuilder.Entity<Comment>().
                HasOne(c => c.Person)
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.PersonID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
