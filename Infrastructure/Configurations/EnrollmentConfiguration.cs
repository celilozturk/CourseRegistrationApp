using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations;
public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("Enrollments");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.HasOne(e=>e.Course).WithMany(e=>e.Enrollments).HasForeignKey(e => e.CourseId);
        builder.HasOne(e=>e.Candidate).WithMany(e=>e.Enrollments).HasForeignKey(e => e.CandidateId);
        

        builder.HasData(
            new Enrollment { Id=1, CandidateId=1, CourseId=1, IsApproved=false},
            new Enrollment { Id=2,CandidateId=1, CourseId=2, IsApproved=false},
            new Enrollment { Id=3,CandidateId=2, CourseId=1, IsApproved=false},
            new Enrollment { Id=4,CandidateId=2, CourseId=3, IsApproved=false},
            new Enrollment { Id=5,CandidateId=3, CourseId=3, IsApproved=false}
            );
    }
}
