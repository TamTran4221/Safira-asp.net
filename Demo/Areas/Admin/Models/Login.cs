﻿using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Demo.Areas.Admin.Models
{
    public class Login
    {
        
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}
