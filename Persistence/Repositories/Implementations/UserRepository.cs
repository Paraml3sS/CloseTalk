using CloseTalk.Domain.Models;
using CloseTalk.Persistence.Repositories.Base;
using CloseTalk.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloseTalk.Persistence.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public async  Task<IEnumerable<User>> GetAsync() =>  await EntitySet.ToListAsync();

        public async Task<User> GetAsync(int id) => await EntitySet.FindAsync(id);

        public int AddUserAsync(User user)
        {
            if (user.UserId == 0)
                EntitySet.Add(user);

            return Context.SaveChanges();
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            var entity = Context.Users
                .FirstOrDefault(u => u.UserId == user.UserId);

            if (entity != null)
            {
                entity.FirstName = user.FirstName;
                entity.LastName = user.LastName;
                entity.DoB = user.DoB;
                entity.UserName = user.UserName;
                entity.EmailAddress = user.EmailAddress;

                EntitySet.Update(entity);
            }

            return await SaveChanges();
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            var entity = EntitySet
                .FirstOrDefault(u => u.UserId == id);

            if (entity != null)
            {
                EntitySet.Remove(entity);
            }

            return await SaveChanges();
        }


        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
