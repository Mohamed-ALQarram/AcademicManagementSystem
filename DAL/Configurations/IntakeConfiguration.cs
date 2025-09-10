using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class IntakeConfiguration : IEntityTypeConfiguration<Intake>
    {
        public void Configure(EntityTypeBuilder<Intake> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired(true);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Intakes)
                .HasForeignKey(x => x.DepartmentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
