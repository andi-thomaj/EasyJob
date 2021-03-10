using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EasyJob.DataLayer.Entities
{
    public class UserEntity : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string UserName { get; set; }
        public string CompanyName { get; set; }
    }
}