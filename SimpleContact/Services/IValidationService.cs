using SimpleContact.Models;

namespace SimpleContact.Services
{
    public interface IValidationService
    {
        public bool ValidateEmailData(EmailViewModel emailViewModel);
    }
}
