using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StaffTemplate.server.Repository.IRepository;
using StaffTemplate.server.Services;

namespace StaffTemplate.server.Controllers
{
    [Route("/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeRepository = _employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEmployeeList()
        {

            var employees = _employeeService.GetEmployees();
            return Ok(employees);}
    }
}
