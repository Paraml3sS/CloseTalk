using Domain.Interfaces;
using System;

namespace CloseTalk.Domain.Models
{
    public partial class User : ICloneable<User>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DoB { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? AccountRegistered { get; set; }
    }
}
