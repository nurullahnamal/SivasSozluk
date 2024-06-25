using SivasSozluk.Api.Application.Interfaces.Repositories;
using SivasSozluk.Api.Domain.Models;
using SivasSozluk.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivasSozluk.Infrastructure.Persistence.Repositories
{
    public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
    {
        public EmailConfirmationRepository(SivasSozlukContext dbContext) : base(dbContext)
        {
        }
    }
}
