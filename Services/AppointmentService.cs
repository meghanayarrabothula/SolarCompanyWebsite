using SolarCompanyWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolarCompanyWebsite.Services
{
    public class AppointmentService
    {
        private readonly AppointmentData _appointmentData;

        public AppointmentService()
        {
            // Initialize with an empty list of appointments
            _appointmentData = new AppointmentData();
        }

        // Retrieve all appointments
        public List<Appointment> GetAllAppointments()
        {
            return _appointmentData.AppointmentList;
        }

        // Retrieve a specific appointment by ID
        public Appointment GetAppointmentById(int id)
        {
            return _appointmentData.AppointmentList.FirstOrDefault(a => a.Id == id);
        }

        // Add a new appointment
        public void CreateAppointment(Appointment newAppointment)
        {
            // Assign a new ID to the appointment
            newAppointment.Id = _appointmentData.AppointmentList.Count > 0
                ? _appointmentData.AppointmentList.Max(a => a.Id) + 1
                : 1;
            _appointmentData.AppointmentList.Add(newAppointment);
        }

        // Update an existing appointment
        public bool UpdateAppointment(int id, Appointment updatedAppointment)
        {
            var appointment = GetAppointmentById(id);
            if (appointment == null) return false;

            // Update appointment properties
            appointment.Name = updatedAppointment.Name;
            appointment.Address = updatedAppointment.Address;
            appointment.PhoneNumber = updatedAppointment.PhoneNumber;
            appointment.Email = updatedAppointment.Email;
            appointment.AppointmentDate = updatedAppointment.AppointmentDate;
            appointment.AvailableFrom = updatedAppointment.AvailableFrom;
            appointment.AvailableUntil = updatedAppointment.AvailableUntil;
            appointment.IsBooked = updatedAppointment.IsBooked;
            appointment.IsPrimaryHouse = updatedAppointment.IsPrimaryHouse;
            appointment.Details = updatedAppointment.Details;

            return true;
        }

        // Delete an appointment by ID
        public bool DeleteAppointment(int id)
        {
            var appointment = GetAppointmentById(id);
            if (appointment == null) return false;

            _appointmentData.AppointmentList.Remove(appointment);
            return true;
        }
    }
}
