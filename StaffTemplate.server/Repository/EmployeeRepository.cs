using StaffTemplate.server.Data;
using StaffTemplate.server.Models;
using StaffTemplate.server.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace StaffTemplate.server.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;