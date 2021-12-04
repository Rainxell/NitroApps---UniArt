using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uniart.Entities.identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public List<ApplicationUserRole> UserRoles { get; set; }
    }
}
