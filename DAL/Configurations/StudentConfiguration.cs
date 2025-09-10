using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.FirstName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(x => x.LastName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.HasOne(x => x.Intake)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.IntakeId);
        }
    }
}
