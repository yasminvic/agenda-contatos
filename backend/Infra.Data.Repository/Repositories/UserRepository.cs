using Domain.Entities;
using Domain.Interfaces.IRepositories;
using Infra.Data.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MySQLContext context)
            :base(context)
        {

        }
    }
}
