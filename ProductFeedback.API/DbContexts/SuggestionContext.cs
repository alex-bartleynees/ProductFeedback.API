using Microsoft.EntityFrameworkCore;
using ProductFeedback.API.Entities;

namespace ProductFeedback.API.DbContexts
{
    public class SuggestionContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<Suggestion> Suggestions { get; set; } = null!;

        public DbSet<SuggestionComment> SuggestionsComment { get; set;} = null!;

        public DbSet<SuggestionCommentReply> SuggestionsCommentReply { get;set; } = null!;

        public DbSet<User> Users { get; set; }

        public SuggestionContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("SuggestionDBConnectionString"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suggestion>()
                .HasData(
                    new Suggestion("Add tags for solutions okay", "enhancement", "live", "Easier to search for solutions based on a specific stack.") 
                    {
                        Id = 1,
                        Upvotes = 144,
                    }
                    );

            modelBuilder.Entity<SuggestionComment>()
                .HasData(
                    new SuggestionComment("Awesome idea! Trying to find framework-specific projects within the hubs can be tedious")
                    {
                        Id = 1,
                        SuggestionId = 1,
                        UserId = 1,
                    }
                    );

            modelBuilder.Entity<SuggestionCommentReply>()
                .HasData(
                    new SuggestionCommentReply("Good idea!", "Suzanne Chang")
                    {
                        Id = 1,
                        UserId = 2,
                        SuggestionCommentId = 1
                    }
                    );

            modelBuilder.Entity<User>()
                .HasData(
                    new User("Suzanne Chang", "upbeat1811", "./assets/user-images/image-suzanne.jpg")
                    {
                        Id = 1,

                    },
                    new User("Thomas Hood", "brawnybrave", "./assets/user-images/image-thomas.jpg")
                    {
                        Id = 2,
                    }
                    );
        }
    }
}
