﻿using SocialNetwork.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Profiles.Commands.Responses
{
    public class AddNewProfileResponse
    {
        public string? ProfileId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string? Bio { get; set; }
        public Gender Gender { get; set; }
        public string? PicturePath { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
