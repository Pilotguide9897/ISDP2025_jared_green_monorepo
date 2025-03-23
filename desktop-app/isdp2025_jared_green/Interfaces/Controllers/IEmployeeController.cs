using idsp2025_jared_green.Entities;

namespace idsp2025_jared_green.Interfaces.Controllers
{
    public interface IEmployeeController
    {
        public Task<bool> AddEmployee(string firstName, string lastName, string username, string email, string password, int positionID, int siteID, sbyte active);

        public Task<bool> UpdateEmployee(Employee employee, string firstName, string lastName, string username, string email, bool resetPassword, int positionID, int siteID, sbyte active, sbyte locked);

        public Task SaveChanges();

        public Task<Employee?> GetEmployeeByUsername(string username);

        public Task<bool> UpdateEmployeePassword(Employee employee, string password);
    }


}