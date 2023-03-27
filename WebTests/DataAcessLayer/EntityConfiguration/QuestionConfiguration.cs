using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityConfiguration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(u => u.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.Text).IsRequired();

            builder
               .HasOne(u => u.Test)
               .WithMany(u => u.Questions)
               .HasForeignKey(u => u.TestId)
               .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
