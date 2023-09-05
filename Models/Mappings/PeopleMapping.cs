using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Models.Mappings
{
   internal class PeopleMapping : IEntityTypeConfiguration<People>
   {
      public void Configure(EntityTypeBuilder<People> builder)
      {
         builder.ToTable("peoples");
         builder.HasKey(c => c.Id);
         builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd();
         builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
         builder.Property(c => c.CreatedAt).HasColumnName("created_at");
      }
   }
}
