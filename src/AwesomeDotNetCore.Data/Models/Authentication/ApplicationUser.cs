﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeDotNetCore.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string Id { get; set; }

        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }
    }
}
