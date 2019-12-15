using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControllerLabApp.DataAccessLayer;

namespace ControllerLabApp.Models
{
    public class EmployeeBusinessLayer
    {
        //public List<Employee> GetEmployees()
        //{
        //    List<Employee> employees = new List<Employee>();
        //    Employee emp = new Employee();
        //    emp.FirstName = "Mahsa";
        //    emp.LastName = "Gholipour";
        //    emp.Salary = 14000;
        //    employees.Add(emp);

        //    emp = new Employee();
        //    emp.FirstName = "Niloufar";
        //    emp.LastName = "Azimi";
        //    emp.Salary = 16000;
        //    employees.Add(emp);


        //    emp = new Employee();
        //    emp.FirstName = "Mohadese";
        //    emp.LastName = "Gholipour";
        //    emp.Salary = 20000;
        //    employees.Add(emp);

        //    return employees;                 
        //}

        public List<Employee> GetEmployees()
        {
            SalesERPDAL SalesDal = new SalesERPDAL();
            return SalesDal.Employees.ToList();

        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL SalesDal = new SalesERPDAL();
            SalesDal.Employees.Add(e);
            SalesDal.SaveChanges();
            return e;
        }

        public bool IsValidUser(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}