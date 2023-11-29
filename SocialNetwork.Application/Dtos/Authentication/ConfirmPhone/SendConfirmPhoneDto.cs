﻿using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Application.Dtos.Authentication.ConfirmPhone
{
    public class SendConfirmPhoneDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
