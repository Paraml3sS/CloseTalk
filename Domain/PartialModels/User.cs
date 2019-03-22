using Domain.Interfaces;
using System;

namespace CloseTalk.Domain.Models
{
    public partial class User : ICloneable<User>
    {
        public User DeepClone() =>

            new User {
                UserId = this.UserId,
                FirstName = this.FirstName,
                LastName = this.LastName,
                DoB = this.DoB.Value,
                UserName = this.UserName,
                EmailAddress = this.EmailAddress,
                AccountRegistered = this.AccountRegistered ?? DateTime.Now
            };
    }
}
