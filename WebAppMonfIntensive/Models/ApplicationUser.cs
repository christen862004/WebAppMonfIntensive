﻿using Microsoft.AspNetCore.Identity;

namespace WebAppMonfIntensive.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
