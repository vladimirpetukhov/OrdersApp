namespace Server.API.Data.ModelConfigurations
{
    using Server.API.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(keyExpression => keyExpression.Id);

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
