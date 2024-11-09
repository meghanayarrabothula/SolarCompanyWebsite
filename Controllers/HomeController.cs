using Microsoft.AspNetCore.Mvc;

namespace MyInteractiveWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ServiceDetails(string id)
        {
            // Prepare service details based on the ID
            ViewData["ServiceTitle"] = id switch
            {
                "Installation" => "Solar Panel Installation",
                "Maintenance" => "Maintenance & Repair",
                "Consultation" => "Consultation & Planning",
                _ => "Service Not Found"
            };

            ViewData["ServiceDescription"] = id switch
            {
                "Installation" => "Our expert team provides professional solar panel installations to ensure you get the most out of your solar energy investment.",
                "Maintenance" => "We offer comprehensive maintenance and repair services to keep your solar system in optimal condition and maximize its lifespan.",
                "Consultation" => "Our consultants work closely with you to plan and design a customized solar solution that best fits your energy needs.",
                _ => "The requested service could not be found."
            };

            return View();
        }
    }
}
