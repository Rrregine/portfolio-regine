using Microsoft.AspNetCore.Mvc;
using Portfolio_Regine.Data;
using Portfolio_Regine.Models;

namespace Portfolio_Regine.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;

        public TestimonialController(AppDbContext context)
        {
            _context = context;
        }

        // Display ALL Testimonials
        public IActionResult Index()
        {
            var Testimonials = _context.Testimonials.OrderByDescending(t => t.SubmittedAt).ToList();

            return View(Testimonials);
        }

        // Approve Testimonial
        public IActionResult Approve(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial != null)
            {
                testimonial.IsApproved = true;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Reject/Delete Testimonial
        public IActionResult Reject(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial != null)
            {
                _context.Testimonials.Remove(testimonial);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
