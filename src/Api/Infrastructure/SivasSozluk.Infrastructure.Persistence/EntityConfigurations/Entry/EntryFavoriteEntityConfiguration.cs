using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SivasSozluk.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SivasSozluk.Infrastructure.Persistence.Context;

namespace SivasSozluk.Infrastructure.Persistence.EntityConfigurations.Entry
{
    public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entryfavorite", SivasSozlukContext.DEFAULT_SCHEMA);


            builder.HasOne(i => i.Entry)
                .WithMany(i => i.EntryFavorites)
                .HasForeignKey(i => i.EntryId);

            builder.HasOne(i => i.CreatedUser)
                .WithMany(i => i.EntryFavorites)
                .HasForeignKey(i => i.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
