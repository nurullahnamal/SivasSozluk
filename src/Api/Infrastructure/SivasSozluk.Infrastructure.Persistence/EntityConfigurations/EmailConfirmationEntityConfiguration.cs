using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SivasSozluk.Api.Domain.Models;
using SivasSozluk.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivasSozluk.Infrastructure.Persistence.EntityConfigurations
{
    public class EmailConfirmationEntityConfiguration : BaseEntityConfiguration<EmailConfirmation>
    {
        public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            base.Configure(builder);

            builder.ToTable("emailconfirmation", SivasSozlukContext.DEFAULT_SCHEMA);
        }
    }
}
