using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class CourseEnrollmentConfiguration : IEntityTypeConfiguration<CourseEnrollment>
    {
        public void Configure(EntityTypeBuilder<CourseEnrollment> builder)
        {
            builder.HasKey(x => new { x.CourseId, x.StudentId });

            builder.HasOne(x=>x.Section)
                .WithMany(x=>x.CourseEnrollments)
                .HasForeignKey(x=>x.SectionId)
                .IsRequired(false);

            builder.HasOne(x=>x.Student)
                .WithMany(x=>x.CourseEnrollments)
                .HasForeignKey(x=>x.StudentId);

            builder.HasOne(x=>x.Course)
                .WithMany(x=>x.CourseEnrollments)
                .HasForeignKey(x=>x.CourseId);
        }
    }
}
