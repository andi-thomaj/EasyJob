using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EasyJob.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string UserName { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}