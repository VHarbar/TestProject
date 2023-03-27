using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityConfiguration
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(u => u.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.Text).IsRequired();
            builder.Property(u => u.IsCorrect).IsRequired();

            builder
               .HasOne(u => u.Question)
               .WithMany(u => u.Answers)
               .HasForeignKey(u => u.QuestionId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
