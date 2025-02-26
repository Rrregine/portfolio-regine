using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Portfolio_Regine.Data;
using Portfolio_Regine.Helpers;
using Portfolio_Regine.Models;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;

namespace Portfolio_Regine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index(string lang = "en")
        {
            // Set the language (default to English if not provided)
            Translations.SetLanguage(lang);

            var viewModel = new HomeViewModel
            {
                Testimonials = _context.Testimonials
                                       .Where(t => t.IsApproved)
                                       .OrderByDescending(t => t.SubmittedAt)
                                       .ToList(),
                Projects = _context.Projects.ToList(),
                TranslatedStrings = new Dictionary<string, string>
        {
            { "AuthorName", Translations.Translate("AuthorName") },
            { "JobTitle", Translations.Translate("JobTitle") },
            { "AboutMe", Translations.Translate("AboutMe") },
            { "WhatImGoodAt", Translations.Translate("WhatImGoodAt") },
            { "MyWork", Translations.Translate("MyWork") },
            { "Testimonials", Translations.Translate("Testimonials") },
            { "AboutMeHeading", Translations.Translate("AboutMeHeading") },
            { "AboutMeContent1", Translations.Translate("AboutMeContent1") },
            { "AboutMeContent2", Translations.Translate("AboutMeContent2") },
            { "AboutMeContent3", Translations.Translate("AboutMeContent3") },
            { "AboutMeContent4", Translations.Translate("AboutMeContent4") },
            { "SkillsHeading", Translations.Translate("SkillsHeading") },
            { "SkillsContent1", Translations.Translate("SkillsContent1") },
            { "SkillsContent2", Translations.Translate("SkillsContent2") },
            { "SkillsContent3", Translations.Translate("SkillsContent3") },
            { "SkillsCVText", Translations.Translate("SkillsCVText") },
            { "DownloadCV", Translations.Translate("DownloadCV") },
            { "FreeTimeHeading", Translations.Translate("FreeTimeHeading") },
            { "FreeTimeContent1", Translations.Translate("FreeTimeContent1") },
            { "FreeTimeContent2", Translations.Translate("FreeTimeContent2") },
            { "FreeTimeContent3", Translations.Translate("FreeTimeContent3") },
            { "FreeTimeContactText", Translations.Translate("FreeTimeContactText") },
            { "FreeTimeButton", Translations.Translate("FreeTimeButton") },
            { "WhatImGoodAtHeading", Translations.Translate("WhatImGoodAtHeading") },
            { "WhatImGoodAtIntro", Translations.Translate("WhatImGoodAtIntro") },
            { "Skill1Title", Translations.Translate("Skill1Title") },
            { "Skill1Description", Translations.Translate("Skill1Description") },
            { "Skill2Title", Translations.Translate("Skill2Title") },
            { "Skill2Description", Translations.Translate("Skill2Description") },
            { "Skill3Title", Translations.Translate("Skill3Title") },
            { "Skill3Description", Translations.Translate("Skill3Description") },
            { "Skill4Title", Translations.Translate("Skill4Title") },
            { "Skill4Description", Translations.Translate("Skill4Description") },
            { "MyWorkHeading", Translations.Translate("MyWorkHeading") },  
            { "HereAreSomeProjects", Translations.Translate("HereAreSomeProjects") }, 
            { "All", Translations.Translate("All") },
            { "Website", Translations.Translate("Website") }, 
            { "MobileApp", Translations.Translate("MobileApp") }, 
            { "Game", Translations.Translate("Game") },

            // Translations for "Leave Your Comments Here!" section
            { "LeaveYourCommentsHere", Translations.Translate("LeaveYourCommentsHere") },
            { "WhatDoYouThinkAboutMyWork", Translations.Translate("WhatDoYouThinkAboutMyWork") },
            { "YourName", Translations.Translate("YourName") },
            { "YourEmail", Translations.Translate("YourEmail") },
            { "Title", Translations.Translate("Title") },
            { "YourMessage", Translations.Translate("YourMessage") },
            { "Submit", Translations.Translate("Submit") },
            { "TestimonialsHeading", Translations.Translate("TestimonialsHeading") },
            { "ViewDetails", Translations.Translate("ViewDetails") },
            
            //email model
            {"SendMeEmail", Translations.Translate("SendMeEmail") },
            {"EmailName", Translations.Translate("EmailName") },
            {"EmailAddress", Translations.Translate("EmailAddress") },
            {"EmailMessage", Translations.Translate("EmailMessage") },

        }
            };

            return View(viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Download CV
        public IActionResult DownloadCV()
        {
            // Define file paths
            string cvFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/CV_E.pdf");
            string additionalFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/CV_F.pdf");

            // Prepare the file names for download
            string zipFileName = "CVs.zip";

            // Create a memory stream to hold the zip file
            using (var memoryStream = new MemoryStream())
            {
                // Create a zip archive in memory
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    // Add the first CV file to the zip
                    var cvFileEntry = archive.CreateEntry("CV_E.pdf");
                    using (var entryStream = cvFileEntry.Open())
                    using (var fileStream = new FileStream(cvFilePath, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.CopyTo(entryStream);
                    }

                    // Add the second additional file to the zip
                    var additionalFileEntry = archive.CreateEntry("CV_F.pdf");
                    using (var entryStream = additionalFileEntry.Open())
                    using (var fileStream = new FileStream(additionalFilePath, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.CopyTo(entryStream);
                    }
                }

                // Reset memory stream position to the beginning before returning
                memoryStream.Position = 0;

                // Return the zip file as a download
                return File(memoryStream.ToArray(), "application/zip", zipFileName);
            }
        }

        [HttpPost]
        public IActionResult Submit(Testimonial model)
        {
            try
            {
                _logger.LogInformation("Submitting testimonial: {Name}", model.Name);

                // Set IsApproved to false by default and set the submission timestamp
                model.IsApproved = false;
                model.SubmittedAt = DateTime.Now;
                _logger.LogInformation("Testimonial default values set. Id: {Id}, Name: {Name}, Email: {Email}, Title: {Title}, Message: {Message}, SubmittedAt: {SubmittedAt}, IsApproved: {IsApproved}",
                                        model.Id, model.Name, model.Email, model.Title, model.Message, model.SubmittedAt, model.IsApproved);

                // Check if the model is valid before proceeding
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Model is valid. Adding testimonial to database.");

                    // Add the testimonial to the database
                    _context.Testimonials.Add(model);
                    _context.SaveChanges();

                    _logger.LogInformation("Testimonial submitted successfully.");
                    // Return a JSON response with a translated success message
                    return Json(new
                    {
                        success = true,
                        message = Translations.Translate("TestimonialSuccess")
                    });
                }
                else
                {
                    _logger.LogWarning("Model is invalid. Returning error response.");
                    return Json(new { success = false, message = "Invalid data. Please check your input." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while submitting the testimonial for {Name}.", model.Name);
                return Json(new { success = false, message = "Something went wrong. Please try again later." });
            }
        }

    }
}
