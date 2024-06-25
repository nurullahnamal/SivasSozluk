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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SivasSozlukContext dbContext) : base(dbContext)
        {
        }
    }
}
