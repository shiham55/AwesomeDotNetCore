using SendGrid;
using SendGrid.Helpers.Mail;

namespace AwesomeDotNetCore.Service.Common
{
    public class EmailService : IEmailService
    {
        public SendGridClient SendGridClient { get; set; }

        public EmailService(string ApiKey)
        {
            this.SendGridClient = new SendGridClient(ApiKey);
        }        

        public async void Send(SendGridMessage message)
        {           
            var response = await SendGridClient.SendEmailAsync(message);
        }
    }
}
