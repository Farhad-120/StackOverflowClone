using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using StackOverflowClone.Models;

namespace StackOverflowClone.Data
{
    public class AppDbContext : DbContext   // here I inherit DbContext class from Entity Framework Core
    {
        static AppDbContext()
        {
            Batteries.Init(); // Required for SQLite EF Core design-time support
        }

        // Constructor that takes DbContextOptions and passes it to the base class constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }  // DbSet for Questions
        public DbSet<Answer> Answers { get; set; }      // DbSet for Answers

        // Configure one-to-many relationship between Question and Answer entities
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            // Seed sample questions
            builder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Title = "What is ASP.NET Core?",
                    Body = "Can someone explain the basics of ASP.NET Core?",
                    PostedBy = "Alice",
                    PostedDate = DateTime.Now
                },
                new Question
                {
                    Id = 2,
                    Title = "How does EF Core work?",
                    Body = "I want to understand EF Core with SQLite.",
                    PostedBy = "Bob",
                    PostedDate = DateTime.Now
                }
            );

            // Seed sample answers
            builder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = 1,
                    Body = "ASP.NET Core is a cross-platform web framework.",
                    PostedBy = "Charlie",
                    PostedDate = DateTime.Now,
                    QuestionId = 1
                },
                new Answer
                {
                    Id = 2,
                    Body = "EF Core maps C# classes to database tables.",
                    PostedBy = "Dave",
                    PostedDate = DateTime.Now,
                    QuestionId = 2
                }
            );

            base.OnModelCreating(builder);
        }
    }
}
