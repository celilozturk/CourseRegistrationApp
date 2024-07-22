using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations;
public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.ToTable("Candidates");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x=>x.LastName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Age).IsRequired();

        builder.HasData(
            new Candidate { Id=1, FirstName="Uras", LastName="Ozturk", Age=4, Email="uras@gmail.com"},
            new Candidate { Id=2, FirstName="Umay", LastName="Turkmen", Age=4, Email="umay@gmail.com"},
            new Candidate { Id=3, FirstName="Efe", LastName="Oz", Age=4, Email="efe@gmail.com"}
            );
    }
}
