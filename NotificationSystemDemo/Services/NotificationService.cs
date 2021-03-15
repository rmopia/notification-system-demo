using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using SendGrid;
using SendGrid.Helpers.Mail;
using NotificationSystemDemo.Models;

namespace NotificationSystemDemo.Services
{
    public class NotificationService
    {
        public void SendAndStoreSMS(SmsModel smsModel)
        {
            // TODO: store SMS in database, if required
            // TODO: functionality for scheduled SMS events

            var twilioAccountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            var twilioAuthToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            TwilioClient.Init(twilioAccountSid, twilioAuthToken);

            var message = MessageResource.Create(
                body: smsModel.Body,
                from: new PhoneNumber(smsModel.SendersPhoneNumber),
                to: new PhoneNumber(smsModel.ReceiversPhoneNumber)
            );

            Console.WriteLine(message.Sid);

            // TODO: return message response to contoller
        }

        public async void SendAndStoreEmail(EmailModel emailModel)
        {
            // TODO: store email in database, if required
            // TODO: functionality for scheduled email events

            var sendGridApiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var sendGridClient = new SendGridClient(sendGridApiKey);

            var fromAddr = new EmailAddress(emailModel.SendersEmail);
            var toAddr = new EmailAddress(emailModel.ReceiversEmail);
            var subject = emailModel.Subject;
            var plainTextContent = emailModel.PlainTextContent;
            var htmlContent = emailModel.HtmlTextContent;

            var outgoingEmail = MailHelper.CreateSingleEmail(fromAddr, toAddr, subject, plainTextContent, htmlContent);
            var response = await sendGridClient.SendEmailAsync(outgoingEmail).ConfigureAwait(false);

            Console.WriteLine(response);

            // TODO: return response to controller
        }
    }
}
