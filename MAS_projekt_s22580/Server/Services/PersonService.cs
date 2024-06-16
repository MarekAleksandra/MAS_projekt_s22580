using System;
using System.Threading.Tasks;
using MAS_projekt_s22580.Models.Employees;
using MAS_projekt_s22580.Context;
using Microsoft.EntityFrameworkCore;

namespace MAS_projekt_s22580.Server.Services
{
    public interface IPersonService
    {
        /// <summary>
        /// Validates employment date of Employee
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="date">The date to set for the employee.</param>
        public Task ValidateEmploymentDate(int id, DateTime date);

        /// <summary>
        /// Validates salary of Employee
        /// </summary>
        /// <param name="salary">The salary to set for the employee.</param>
        public Task ValidateSalary(double salary);
    }

    public class PersonService : IPersonService
    {
        private readonly DatabaseContext _context;

        public PersonService(DatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task ValidateEmploymentDate(int id, DateTime date)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("Employee not found.");
            }

            if (date < employee.Person.Birthdate)
            {
                throw new ArgumentException("Employment date cannot be before birth date.");
            }
        }

        /// <inheritdoc />
        public async Task ValidateSalary(double salary)
        {
            if (salary < Employee.MinSalary)
            {
                throw new ArgumentException($"Salary must be greater than the minimum salary of {Employee.MinSalary}.");
            }
        }
    }
}
