using SimpleContact.Models;

namespace SimpleContact.Services.Implementation;

public class EmailService : IEmailService
{
    public bool SendContactEmail(EmailViewModel emailViewModel)
    {
        try
        {
            var emailObj = new EmailEntity
            {
                Name = emailViewModel.Name,
                Email = emailViewModel.Email,
                Message = emailViewModel.Message
            };

            //This function would then send an email to optoma.
            //You do NOT need to complete this method.

            return true;
        }
        catch(Exception ex)
        {
            
            return false;
        }
    }
}