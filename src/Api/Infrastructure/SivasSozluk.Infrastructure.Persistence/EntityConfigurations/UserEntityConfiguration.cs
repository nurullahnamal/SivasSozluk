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
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user", SivasSozlukContext.DEFAULT_SCHEMA);
        }
    }
}
