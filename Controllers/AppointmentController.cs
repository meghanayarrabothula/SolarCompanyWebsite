using Microsoft.AspNetCore.Mvc;
using SolarCompanyWebsite.Models;
using SolarCompanyWebsite.Services;

namespace SolarCompanyWebsite.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: /Appointments - Display all appointments
        public IActionResult Index()
        {
            var appointments = _appointmentService.GetAllAppointments();
            return View(appointments);
        }

       

        // GET: /Appointments/Create - Show form to create a new appointment
        public IActionResult Create()
        {
            return View(new Appointment());
        }

        // POST: /Appointments/Create - Add a new appointment
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _appointmentService.CreateAppointment(appointment);
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: /Appointments/Edit/{id} - Show form to edit an appointment
        public IActionResult Edit(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: /Appointments/Edit/{id} - Update an existing appointment
        [HttpPost]
        public IActionResult Edit(int id, Appointment updatedAppointment)
        {
            if (ModelState.IsValid)
            {
                bool success = _appointmentService.UpdateAppointment(id, updatedAppointment);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(updatedAppointment);
        }

        // GET: /Appointments/Delete/{id} - Show confirmation for deleting an appointment
        public IActionResult Delete(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: /Appointments/Delete/{id} - Confirm and delete an appointment
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            bool success = _appointmentService.DeleteAppointment(id);
            if (success)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
