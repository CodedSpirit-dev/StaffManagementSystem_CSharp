﻿using StaffTemplate.server.Data;
using StaffTemplate.server.Models;
using StaffTemplate.server.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace StaffTemplate.server.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public bool CreateEmployee(Employee employee, Address address, EmergencyContact emergencyContact, ContactInfo contactInfo, EmploymentDetails employmentDetails)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    // Insertar empleado
                    _db.Employees.Add(employee);
                    _db.SaveChanges();

                    // Asignar el SocialSecurityNumber del empleado a la dirección y al contacto de emergencia
                    address.SocialSecurityNumber = employee.SocialSecurityNumber;
                    contactInfo.SocialSecurityNumber = employee.SocialSecurityNumber;
                    emergencyContact.SocialSecurityNumber = employee.SocialSecurityNumber;
                    employmentDetails.SocialSecurityNumber = employee.SocialSecurityNumber;

                    // Insertar dirección
                    _db.Addresses.Add(address);
                    _db.SaveChanges();

                    // Insertar contacto de emergencia
                    _db.EmergencyContacts.Add(emergencyContact);
                    _db.SaveChanges();

                    // Insertar contacto
                    _db.ContactInfos.Add(contactInfo);
                    _db.SaveChanges();

                    // Commit de la transacción
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    // Rollback de la transacción en caso de error
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public ICollection<Employee> GetEmployees()
        {
            return _db.Employees.ToList();
        }

        internal bool EmployeeExists(int socialSecurityNumber)
        {
            return _db.Employees.Any(a => a.SocialSecurityNumber == socialSecurityNumber);
        }
    }
}