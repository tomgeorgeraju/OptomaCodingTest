using SimpleContact.Models;

namespace SimpleContact.Services.Implementation
{
    public class ValidationService : IValidationService
    {
        public bool ValidateEmailData(EmailViewModel emailViewModel)
        {
            //Check nulls
            if (string.IsNullOrWhiteSpace(emailViewModel.Name))
                throw new ArgumentNullException(nameof(emailViewModel.Name));

            if (string.IsNullOrWhiteSpace(emailViewModel.Email))
                throw new ArgumentNullException(nameof(emailViewModel.Email));

            if (string.IsNullOrWhiteSpace(emailViewModel.Message))
                throw new ArgumentNullException(nameof(emailViewModel.Message));

            //Check length
            if (emailViewModel.Name.Length > 128)
                throw new InvalidOperationException("Name is bigger then 128 characters");

            if (emailViewModel.Email.Length > 256)
                throw new InvalidOperationException("Email is bigger then 256 characters");

            if (emailViewModel.Message.Length > 2048)
                throw new InvalidOperationException("Message is bigger then 2048 characters");

            //Check valid email address
            if (!ValidEmail(emailViewModel.Email))
                throw new InvalidOperationException("Invalid email address");

            return true;
        }

        private bool ValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
