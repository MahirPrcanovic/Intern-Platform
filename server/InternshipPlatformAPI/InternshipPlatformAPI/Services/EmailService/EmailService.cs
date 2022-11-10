using SendGrid;
using SendGrid.Helpers.Mail;

namespace InternshipPlatformAPI.Services.EmailService
{
    public class EmailService : IEmailService
    {

        private readonly ISendGridClient _sendGridClient;
        private readonly ILogger logger;

        public EmailService(ISendGridClient sendGridClient, ILogger<EmailService> logger)
        {
            this._sendGridClient = sendGridClient;
            this.logger = logger;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("mahirprcanovic2@hotmail.com", "Maestral Solutions"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            var response = await _sendGridClient.SendEmailAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                logger.LogInformation("Email queued successfully");
            }
            else
            {
                logger.LogError("Failed to send email");
                // Adding more information related to the failed email could be helpful in debugging failure,
                // but be careful about logging PII, as it increases the chance of leaking PII
            }
        }
    }
}
