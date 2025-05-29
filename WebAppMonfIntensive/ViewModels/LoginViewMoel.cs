﻿using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace WebAppMonfIntensive.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}
