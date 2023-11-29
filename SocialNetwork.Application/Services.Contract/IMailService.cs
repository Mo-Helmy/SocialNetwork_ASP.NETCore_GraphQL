using SocialNetwork.Application.Dtos.MailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Services.Contract
{
    public interface IMailService
    {
        void SendMail(MailRequest mailRequest);
    }
}
