﻿using System.ComponentModel.DataAnnotations;

namespace RunGroupWebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
