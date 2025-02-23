using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio_Regine.Data;
using Portfolio_Regine.Models;
using System.Linq;


namespace Portfolio_Regine.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AdminController> _logger;

        public AdminController(AppDbContext context, ILogger<AdminController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }
        public IActionResult Edit(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Project project, IFormFile image)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            // Check if an image was uploaded
            if (image != null && image.Length > 0)
            {
                _logger.LogInformation("Image uploaded: {ImageFileName}, Size: {ImageSize} bytes", image.FileName, image.Length);

                // Define the path where the image will be stored
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image.FileName);

                try
                {
                    // Save the new image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }

                    // Update the image path for the project
                    project.ImagePath = "/images/" + image.FileName;

                    _logger.LogInformation("Image saved at path: {ImagePath}", project.ImagePath);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error saving image: {Message}", ex.Message);
                    ModelState.AddModelError("", "There was an error saving the image.");
                    return View(project);
                }
            }
            else
            {
                // If no new image is uploaded, keep the current image path
                var existingProject = _context.Projects.FirstOrDefault(p => p.Id == id);
                if (existingProject != null)
                {
                    project.ImagePath = existingProject.ImagePath; // Keep the existing image path
                }
            }

            // Detach the existing entity if it's being tracked to avoid the conflict
            var trackedProject = _context.Projects.Local.FirstOrDefault(p => p.Id == project.Id);
            if (trackedProject != null)
            {
                _context.Entry(trackedProject).State = EntityState.Detached;
            }

            // Update the project data
            _context.Projects.Update(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var project = _context.Projects.Find(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // New Create GET method
        public IActionResult Create()
        {
            return View();
        }

        // New Create POST method
        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project, IFormFile image)
        {
            // Log incoming request data
            _logger.LogInformation("Creating new project. Title: {Title}, Category: {Category}, Description: {Description}, Image: {ImagePath}",
                                    project.Title, project.Category, project.Description, project.ImagePath);

                // Check if an image was uploaded
                if (image != null && image.Length > 0)
                {
                    _logger.LogInformation("Image uploaded: {ImageFileName}, Size: {ImageSize} bytes", image.FileName, image.Length);

                    // Define the path where the image will be stored
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image.FileName);

                    try
                    {
                        // Save the image to the file system
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }

                        // Set the relative image path for database storage
                        project.ImagePath = "/images/" + image.FileName;

                        _logger.LogInformation("Image saved at path: {ImagePath}", project.ImagePath);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Error saving image: {Message}", ex.Message);
                        ModelState.AddModelError("", "There was an error saving the image.");
                        return View(project);
                    }
                }
                else
                {
                    _logger.LogInformation("No image uploaded.");
                }

                // Add project to the database and save changes
                _context.Projects.Add(project);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));  // Redirect after saving the project
            }
    }
}
