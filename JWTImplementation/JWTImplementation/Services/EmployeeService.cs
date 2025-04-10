using JWTImplementation.DatabaseContext;
using JWTImplementation.Interfaces;
using JWTImplementation.Models;

namespace JWTImplementation.Services
{
    public class EmployeeService : IEmployeeService

    {
        private readonly JwtDbContext _jwtDbContext;
        public EmployeeService(JwtDbContext jwtContext)
        {
            _jwtDbContext = jwtContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            var emp = _jwtDbContext.Employees.Add(employee);
            _jwtDbContext.SaveChanges();
            return emp.Entity;
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var emp = _jwtDbContext.Employees.SingleOrDefault(s => s.Id == id);
                if (emp == null)
                    throw new Exception("user not found");
                else
                {
                    _jwtDbContext.Employees.Remove(emp);
                    _jwtDbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Employee> GetEmployeeDetails()
        {
            var employees = _jwtDbContext.Employees.ToList();
            return employees;
        }

        public Employee GetEmployeeDetails(int id)
        {
            var emp = _jwtDbContext.Employees.SingleOrDefault(s => s.Id == id);
            return emp;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var updated = _jwtDbContext.Employees.Update(employee);
            _jwtDbContext.SaveChanges();
            return updated.Entity;
        }
    }
}