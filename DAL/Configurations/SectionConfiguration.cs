using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.Id);  

            builder.HasOne(x=>x.Instructor)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.InstructorId);

            builder.HasOne(x=>x.Course)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
