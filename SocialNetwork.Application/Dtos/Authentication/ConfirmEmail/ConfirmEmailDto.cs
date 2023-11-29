﻿using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Application.Dtos.Authentication.ConfirmEmail
{
    public class ConfirmEmailDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
