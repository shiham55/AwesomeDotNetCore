using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeDotNetCore.Service.Common
{
    public interface IEmailService
    {
        void Send(SendGridMessage message);
    }
}
