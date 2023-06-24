using Microsoft.AspNetCore.Mvc;
using SimpleContact.Models;
using SimpleContact.Services;

namespace SimpleContact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IValidationService _validationService;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger,
            IValidationService validationService,
            IEmailService emailService)
        {
            _logger = logger;
            _validationService = validationService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(EmailViewModel emailViewModel)
        {
            try
            {
                var validData = _validationService.ValidateEmailData(emailViewModel);
                if (validData)
                {
                    var result = _emailService.SendContactEmail(emailViewModel);
                    
                }
                TempData["UserMessage"] = $"Thanks {emailViewModel.Name} for filling out our form!";
                _logger.LogInformation($"New user {emailViewModel.Name} has been registered");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                TempData["UserMessage"] = $"Error occured {ex.Message.ToString()} : Please try again!";
                return RedirectToAction("Index");
            }
        }
    }
}