using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Chats.Commands.Responses
{
    public class SendNewMessageResponse
    {
        public string MessageID { get; set; }
        public int ChatID { get; set; }

        public string MessageText { get; set; }

        
    }
}
