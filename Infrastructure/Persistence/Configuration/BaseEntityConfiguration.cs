using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    internal abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        void IEntityTypeConfiguration<T>.Configure(EntityTypeBuilder<T> builder)
        {   
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Guid).IsUnique();

            Configure(builder);
        }

        /// <summary>
        /// Additional Configuration specific to the entity.
        /// The private & public keys have been set already
        /// </summary>
        /// <param name="builder">The EntityTypeBuidler to configure</param>
        protected abstract void Configure(EntityTypeBuilder<T> builder);
    }
}
