using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StaffTemplate.server.Repository;
using StaffTemplate.server.Repository.IRepository;
using StaffTemplate.server.Services;

namespace StaffTemplate.server.Controllers
{
    [Route("/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeRepository = _employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEmployeeList()
        {

            var employees = _employeeRepository.GetEmployees();
            return Ok(employees);}
    }
}
