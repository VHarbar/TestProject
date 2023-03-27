using DataAccessLayer.Entity;
using DataAccessLayer.EntityConfiguration;
using DataAcessLayer.Entity;
using DataAcessLayer.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DataAcessLayer.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Name = "Vadim",
                        Password ="1234",
                        Surname = "Vadik"
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Alex",
                        Password = "Alex234",
                        Surname = "TheLion"
                    }
                );
            modelBuilder.Entity<Test>()
                .HasData(
                    new Test
                    {
                        Id = 1,
                        Title = "math",
                        Description = "It's a simple math test for Vadik",
                        CreatedForUserId = 1,
                    },
                    new Test
                    {
                        Id = 2,
                        Title = "What are you doing in my car",
                        Description = "Alex the lion what are you doing in my car",
                        CreatedForUserId = 2
                    },
                    new Test
                    {
                        Id = 3,
                        Title = "What are you doing in my car",
                        Description = "Alex the lion what are you doing in my car",
                        CreatedForUserId = 1
                    });
            modelBuilder.Entity<Question>()
                .HasData(
                    new Question
                    {
                        Id = 1,
                        Text = "a riddle from jacques fresco how much is 2+2:",
                        TestId = 1,
                    },
                    new Question
                    {
                        Id = 2,
                        Text = "Alex why you are doing this",
                        TestId = 2
                    },
                    new Question
                    {
                        Id = 3,
                        Text = "Alex why you are doing this",
                        TestId = 3
                    });
            modelBuilder.Entity<Answer>()
                .HasData(
                    new Answer
                    {
                        Id = 1,
                        Text = "4",
                        IsCorrect = true,
                        QuestionId = 1,

                    },
                    new Answer
                    {
                        Id = 2,
                        Text = "5",
                        IsCorrect = false,
                        QuestionId = 1,
                    },
                    new Answer
                    {
                        Id = 3,
                        Text = "Because I can",
                        IsCorrect = false,
                        QuestionId = 2,
                    },
                    new Answer
                    {
                        Id = 4,
                        Text = "Sorry",
                        IsCorrect = true,
                        QuestionId = 2,
                    },
                    new Answer
                    {
                        Id = 5,
                        Text = "Because I can",
                        IsCorrect = false,
                        QuestionId = 3,
                    },
                    new Answer
                    {
                        Id = 6,
                        Text = "Sorry",
                        IsCorrect = true,
                        QuestionId = 3,
                    }
                );
                    

        }
    }
    }
