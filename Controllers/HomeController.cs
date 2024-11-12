using Microsoft.AspNetCore.Mvc;

namespace MyInteractiveWebsite.Controllers
{
    public class HomeController : Controller
    {
        // public IActionResult Index()
        // {
        //     return View();
        // }
        public IActionResult Index()
        {
            ViewBag.Services = new List<Service>
            {
                new Service { Title = "Solar Panel Installation", Description = "We provide end-to-end solar power system installations for residential and commercial properties, ensuring efficient and cost-effective energy solutions." },
                new Service { Title = "Off-Grid Solutions", Description = "For remote areas or clients looking for energy independence, we offer complete off-grid power systems with battery storage and backup options." },
                new Service { Title = "Energy Efficiency Consulting", Description = "Our experts analyze your energy needs and suggest ways to optimize consumption, making the most of your solar power system." },
                new Service { Title = "Maintenance & Support", Description = "We provide ongoing support and maintenance for your solar power system to ensure peak performance throughout its lifetime." }
            };
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
