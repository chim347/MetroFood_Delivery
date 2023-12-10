using MailKit.Security;
using MediatR;
using MetroDelivery.Application.Common.Exceptions;
using MetroDelivery.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDelivery.Application.Features.Auth.Queries.ResetPassword
{
    public class ResetPasswordQueryHandler : IRequestHandler<ResetPasswordQuery, string>
    {

        private readonly UserManager<ApplicationUser> _userManager;
        public ResetPasswordQueryHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(ResetPasswordQuery request, CancellationToken cancellationToken)
        {
            try {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                    throw new NotFoundException(nameof(ApplicationUser), request.Email);

                var newPassword = GenerateRandomPassword();

                var resetPasswordResult = await _userManager.ResetPasswordAsync(user, await _userManager.GeneratePasswordResetTokenAsync(user), newPassword);
                if (!resetPasswordResult.Succeeded) {
                    throw new BadRequestException("Password reset failed.");
                }

                await SendEmailAsync(user.Email, "Reset password", $"Your new password is: {newPassword}");

                return "Password reset successful. Please check your email for the new password.";
            }
            catch (Exception ex) { throw new BadRequestException($"Error at ResetPasswordQueryHandler : {ex}"); }
        }

        private string GenerateRandomPassword()
        {
            try {
                const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                const string specialChars = "!@#$%^&*()";
                var random = new Random();
                var password = new StringBuilder();


                for (int i = 0; i < 5; i++) {
                    password.Append(validChars[random.Next(validChars.Length)]);
                }


                password.Append(specialChars[random.Next(specialChars.Length)]);


                for (int i = password.Length - 1; i > 0; i--) {
                    int j = random.Next(i + 1);
                    char temp = password[i];
                    password[i] = password[j];
                    password[j] = temp;
                }

                return password.ToString();
            }
            catch (Exception ex) { throw new BadRequestException($"Error at GenerateRandomPassword: {ex}"); }
        }

        private async Task SendEmailAsync(string email, string subject, string body)
        {
            try {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("LogOT","pansy19@ethereal.email"));
                message.To.Add(new MailboxAddress("pansy19@ethereal.email", email));
                message.Subject = subject;

                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = body
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient()) {
                    await client.ConnectAsync("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("pansy19@ethereal.email", "ApmhjVB3GZeHJ9tkfH"); //Tài khoản gmail và mạt khẩu on ethereal.email
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex) { throw new BadRequestException($"Error at SendEmailAsync: {ex}"); }
        }
    }
}
