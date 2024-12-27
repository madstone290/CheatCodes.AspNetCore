using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutboxPattern.Core.Domain;

namespace OutboxPattern.Core.Infrastructure
{
    public class OutboxBoxConfig : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.HasKey(x => x.Id);



            builder.Property(x => x.PayloadType);
            builder.Property(x => x.Payload);
            builder.Property(x => x.OccurredDateTime);
            builder.Property(x => x.IsProcessed);
            builder.Property(x => x.IsSuccessful);
            builder.Property(x => x.RetryCount);
            builder.Property(x => x.ProcessedDateTime);
            builder.Property(x => x.FailiureReasons).HasConversion(new CollectionStringConverter());
        }
    }
}
