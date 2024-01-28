using EFCore_101.App_Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EFCore_101.App_Data.Configuration
{
    public class ILConfiguration : IEntityTypeConfiguration<IL>
    {
        public void Configure(EntityTypeBuilder<IL> builder)
        {
            builder.HasIndex(e => e.IlKod).IsUnique(true);
            builder.Property(p => p.IlKod).IsRequired();
            builder.Property(i => i.IlKod).HasColumnType("char(2)").HasMaxLength(2);
        }
    }
}
