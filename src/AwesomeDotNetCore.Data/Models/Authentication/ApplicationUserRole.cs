using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeDotNetCore.Data.Models
{
    public class ApplicationUserRole : IdentityRole<string>
    {
        public ApplicationUserRole() : base()
        {
        }
    }
}
