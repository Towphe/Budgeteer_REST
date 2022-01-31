using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Budgeteer_REST.Identity
{
    public class AppUser : IdentityUser
    {
        public string SettingsJSON { get; set; }
        public string ProfileDir { get; set; }
        public decimal TotalMoney { get; set; } = 0;
    }
}
