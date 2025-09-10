using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace DAL.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired(false);
        }
    }
}
