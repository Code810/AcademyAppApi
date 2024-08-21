
using AcademyApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcademyApp.Data.Configurations
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name).IsRequired().HasMaxLength(5);
            builder.Property(g => g.Limit).IsRequired();
            builder.HasKey(g => g.Id);
        }
    }
}
