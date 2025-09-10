using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.FirstName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(x=>x.LastName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired(true);

            builder.HasOne(x=>x.Department)
                .WithMany(x=>x.Instructors)
                .HasForeignKey(x=>x.DepartmentId);
        }
    }
}
