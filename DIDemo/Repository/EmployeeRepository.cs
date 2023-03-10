using DIDemo.Data;
using DIDemo.Models;

namespace DIDemo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext db;
        public EmployeeRepository(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public int AddEmployee(Employee emp)
        {
            int result = 0;
            db.Employees.Add(emp);
            result= db.SaveChanges();
            return result;
        }

        public int DeleteEmployee(int id)
        {
            int result = 0;
            var emp=db.Employees.Where(x=>x.Id==id).FirstOrDefault();
            if (emp != null) 
            {
                db.Employees.Remove(emp);
                result= db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            var emp=db.Employees.Where(x=>x.Id==id).FirstOrDefault();
            return emp;
        }

        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            var e=db.Employees.Where(x=>x.Id==emp.Id).FirstOrDefault();
            if (e != null) 
            {
                e.Name=emp.Name;
                e.Dept_Name=emp.Dept_Name;
                e.Salary=emp.Salary;
                result=db.SaveChanges();
            }
            return result;
        }
    }
}
