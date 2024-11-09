using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyInteractiveWebsite.Controllers
{
    public class FeedbackController : Controller
    {
        // Static list to hold feedback entries in memory
        private static List<string> feedbackList = new List<string>
        {
            "Great service! Solar Solutions reduced our energy bill significantly.",
            "Reliable and professional. The solar installation process was seamless.",
            "Exceptional customer service and knowledgeable staff."
        };

        // Display all feedback
        public IActionResult Index()
        {
            return View(feedbackList);
        }

        // Show the add feedback form
        public IActionResult AddFeedback()
        {
            return View();
        }

        // Handle the form submission to add feedback
        [HttpPost]
        public IActionResult SubmitFeedback(string feedback)
        {
            // Add new feedback to the list
            if (!string.IsNullOrWhiteSpace(feedback))
            {
                feedbackList.Add(feedback);
            }

            // Pass a success message to display on the feedback page
            TempData["Message"] = "Thank you for your feedback!";
            return RedirectToAction("Index");
        }
    }
}
