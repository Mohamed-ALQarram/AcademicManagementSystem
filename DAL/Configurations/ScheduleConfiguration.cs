using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => new { x.SectionId, x.RoomId });

            builder.HasOne(x=>x.Section)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Room)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.RoomId);

            builder.Property(x => x.DayOfWeek)
                .HasConversion<string>()
                .HasColumnType("nvarchar")
                .HasMaxLength(10)
                .IsRequired(true);


        }
    }
}
