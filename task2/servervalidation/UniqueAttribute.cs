using System.ComponentModel.DataAnnotations;
using task2.Migrations;
using task2.Models;
using task2.ViewModels;
namespace task2.servervalidation
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            EmployeeVM employee = (EmployeeVM)validationContext.ObjectInstance;
            CompanyContext context = new();

            int departmentId = (int)employee.dno;

            
            var result = context.Employees.Any(e=>e.fname == value.ToString() && e.dno == departmentId);

            if (result)
            {
                return new ValidationResult("Not unique within the department");
            }

            return ValidationResult.Success;
        }
    }
}
