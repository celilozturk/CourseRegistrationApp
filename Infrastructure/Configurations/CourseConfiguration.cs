using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations;
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        builder.HasKey(c=>c.Id);
        builder.Property(c=>c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c=>c.TotalPaticipants).IsRequired();

        builder.HasData(
            new Course() { Id=1, Name="Angular 18",CreatedDate=DateTime.UtcNow, TotalPaticipants=20 },
            new Course() { Id=2, Name="Full Stack Web Development",CreatedDate=DateTime.UtcNow , TotalPaticipants=100},
            new Course() { Id=3, Name="Database Organization",CreatedDate=DateTime.UtcNow , TotalPaticipants=50}
            );
    }

}
