using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(x=>x.Id);

            builder.HasOne(x=>x.Section) 
                .WithMany(x=>x.Attendences)
                .HasForeignKey(x=>x.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(x => x.Student)
                .WithMany(x => x.Attendences)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.AttendStatus)
            .HasConversion<string>()
            .HasColumnType("varchar")
            .HasMaxLength(15)
            .IsRequired(true);

            builder.Property(x=>x.Reason)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired(false);

        }
    }
}
