using DataAcessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessLayer.EntityConfiguration
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(u => u.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.Title).IsRequired();
            builder.Property(u => u.Description).IsRequired();

            builder
                .HasOne(u => u.CreatedForUser)
                .WithMany(u => u.Tests)
                .HasForeignKey(u => u.CreatedForUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
