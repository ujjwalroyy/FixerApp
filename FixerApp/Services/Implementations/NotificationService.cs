using FirebaseAdmin.Messaging;
using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;
using FixerApp.Services.Interfaces;
using FixrApp.Data;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace FixerApp.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateNotification(User user, string message)
        {
            var notification = new Models.Entities.Notification
            {
                User = user,
                Message = message,
                CreatedAt = DateTime.UtcNow,
                Read = false,
                Type = NotificationType.IN_APP
            };
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public void SendNotification(NotificationRequestDto dto)
        {
            var user = _context.Users.Find(dto.UserId);
            if (user == null) throw new Exception("User not found");

            var notification = new Models.Entities.Notification
            {
                User = user,
                Message = dto.Message,
                Type = dto.Type,
                Read = false,
                CreatedAt = DateTime.UtcNow
            };
            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public void SendNotificationEmail(NotificationRequestDto dto)
        {
            var message = new MimeKit.MimeMessage();
            message.From.Add(new MimeKit.MailboxAddress("FixrApp", "your_email@example.com"));
            message.To.Add(MimeKit.MailboxAddress.Parse(dto.Email));
            message.Subject = "Fixr Notification";
            message.Body = new MimeKit.TextPart("plain")
            {
                Text = dto.Message
            };

            using var client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate("your_email@example.com", "your_app_password");
            client.Send(message);
            client.Disconnect(true);
        }

        public void SendNotificationSms(NotificationRequestDto dto)
        {
            const string accountSid = "your_twilio_sid";
            const string authToken = "your_twilio_token";
            const string twilioNumber = "+1234567890"; 

            Twilio.TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: dto.Message,
                from: new PhoneNumber(twilioNumber),
                to: new PhoneNumber(dto.Phone)
            );
        }

        public void SendNotificationFcm(NotificationRequestDto dto)
        {
            var message = new FirebaseAdmin.Messaging.Message()
            {
                Token = dto.FcmToken,
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Title = "FixrApp",
                    Body = dto.Message
                }
            };

            var messaging = FirebaseMessaging.DefaultInstance;
            messaging.SendAsync(message).Wait(); 
        }

      
    }
}
