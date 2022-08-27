using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entity;

namespace Ordering.Data.EntityConfiguration
{
    public class OrderEntityConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Table Name
            builder.ToTable("Orders");
            //Primary Key
            builder.HasKey(o => o.Id);
            //Configure Type property
            builder.Property(o => o.UserName)
                .IsRequired()//Username can't be empty
                .HasMaxLength(50);//Username has max 100 characters
        }
    }
}
