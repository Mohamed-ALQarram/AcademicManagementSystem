using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnType("nvarchar")

                .HasMaxLength(50)
                .IsRequired(true);
            builder.Property(x => x.Location)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired(false);

            builder.Property(x => x.RoomType)
                .HasConversion<string>()
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired(true);
        }
    }
}
