using CostumerSupport.Domain.Entities;
using CostumerSupport.Persistence.Context;
using CostummerSupport.Application.Interfaces.AppUserInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CostumerSupport.Persistence.Repositories.AppUserRepository
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CostumerSupportContext _context;

        public AppUserRepository(CostumerSupportContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            var values  =await _context.AppUsers.Where(filter).ToListAsync();
            return values;
        }
    }
}
