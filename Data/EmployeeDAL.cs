using CRUDusingentityframework.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUDusingentityframework.Data
{
    public class EmployeeDAL
    {
        ApplicationDbContext db;

        public EmployeeDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Employee> GetAllEmployee()
        {
            return db.Employeedetails.ToList();
        }
        //public IEnumerable<Product> GetAllEmployee()
        //{
        //    return from p in db.Employee select p;
        //}

        /*public IQueryable<Product> GetAllEmployee()
        {
          return from p in db.Employee select p;
        }*/

        public Employee GetEmployeeById(int id)
        {
            Employee e = db.Employeedetails.Where(x => x.Id == id).FirstOrDefault();
            return e;
        }  

        public int AddEmployee(Employee emp)
        {

            // add emp object in the Employeedetails collections
            db.Employeedetails.Add(emp);
            // reflect the change in DB
            int result = db.SaveChanges();
            return result;
        }

        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            // e object hold old data
            Employee e = db.Employeedetails.Where(x => x.Id == emp.Id).FirstOrDefault();
            if (e != null)
            {
                e.Name = emp.Name;
                e.Salary = emp.Salary;
                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            Employee e = db.Employeedetails.Where(x => x.Id == id).FirstOrDefault();
            if (e != null)
            {
                db.Employeedetails.Remove(e);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
