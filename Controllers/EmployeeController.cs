using dotnet_app.Models.Dtos;
using dotnet_app.Models.Entities;
using dotnet_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public EmployeeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // create employee
        [HttpPost]
        public IActionResult AddEmployee(EmployeeDto employeeDto)
        {
            var employeeData = new Employee()
            {
                Email = employeeDto.Email,
                Name = employeeDto.Name,
                Phone = employeeDto.Phone,
                Salary = employeeDto.Salary,
            };

            _dbContext.Add(employeeData);
            // we need to save it to tha database;
            _dbContext.SaveChanges();

            return Ok(new { success = true, message = "Employee created successfuly", employeeData });

        }


        // fetch employee data;
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var allEmployees = _dbContext.Employees.ToList();
            if (allEmployees.Count == 0)
            {
                return NotFound(new { success = false, message = "No employees found" });
            }

            return Ok(new { success = true, message = "Employees data fetched successfully", allEmployees });

        }


        // fetch employee data by id ;
        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
            if(employee is null)
            {
                return NotFound(new { success = false, message = "Employee not found" });
            }

            return Ok(new { success = true, message = "Employee fetched successfully", employee });
        }


        //Update employee details
       [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id , EmployeeDto employeeData)
        {
            var employee = _dbContext.Employees.Find(id);
            if(employee is null)
            {
                return NotFound(new { success = false, message = "employee not found" });
            }

            employee.Email = employeeData.Email;
            employee.Name = employeeData.Name;
            employee.Phone = employeeData.Phone;
            employee.Salary = employeeData.Salary;

            _dbContext.SaveChanges();

            return Ok(new { success = true, message = "Employee data updated", employee });
        }


        // delete employee data from database;
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployeeData(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee is null) return NotFound(new { success = false, message = "employee not found" });

            _dbContext.Employees.Remove(employee);
            int rowsAffected = _dbContext.SaveChanges();
            if (rowsAffected == 0) return NotFound(new { success = false, message = "Unable to delete employee data" });

            return Ok(new { success = true, message = "Employee data deleted" , rowsAffected});
        }


    }
}
