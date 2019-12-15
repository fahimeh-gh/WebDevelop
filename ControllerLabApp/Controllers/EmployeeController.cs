using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControllerLabApp.Models;
using ControllerLabApp.ViewModels;

namespace ControllerLabApp.Controllers
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return this.CustomerName + "|" + this.Address;
        }

    }

    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Test
        public string GetString()
        {
            return "Hello World is old now. It's time to learn.";
        }

        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.CustomerName = "Fahimeh";
            c.Address = "Hamburg";

            return c;
        }

        [NonAction]
        public string SimpleMethod()
        {
            return "Hi, I'm a non action method.";
        }

        //public ActionResult GetView()
        //{
        //    Employee emp = new Employee();
        //    emp.FirstName = "Fahimeh";
        //    emp.LastName = "Gholipour";
        //    emp.Salary = 20000;

        ////    ViewData["Employee"] = emp;

        ////    ViewBag.Employee = emp;

        //    return View("MyView", emp);
        //}

        //public ActionResult GetView()
        //{
        //    Employee emp = new Employee();
        //    emp.FirstName = "Fahimeh";
        //    emp.LastName = "Gholipour";
        //    emp.Salary = 20000;

        //    EmployeeViewModel evm = new EmployeeViewModel();
        //    evm.EmployeeName = emp.FirstName + " " + emp.LastName;
        //    evm.Salary = emp.Salary.ToString("C");

        //    if (emp.Salary > 15000)
        //    {
        //        evm.SalaryColor = "yellow";

        //    }
        //    else
        //    {
        //        evm.SalaryColor = "green";
        //    }

        //    evm.UserName = "Admin";

        //    return View("MyView2", evm);
        //}

        //public ActionResult GetView2()
        //{
        //    int i = 1;

        //    if (i == 1)
        //        return View("MyView");
        //    else
        //        return View("YourView");

        //}

        
        //[Authorize]
        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();

            List<Employee> employees = empBal.GetEmployees();
           
            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();

                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if(emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "Green";
                }

                empViewModels.Add(empViewModel);
            }

            employeeListViewModel.Employees = empViewModels;
            //employeeListViewModel.UserName = "Administrator";
            employeeListViewModel.UserName = User.Identity.Name;

            return View("Index", employeeListViewModel);

        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        //public string SaveEmployee(Employee e, string FirstName)
        //{
        //    return e.FirstName + "|" + e.LastName + "|" + e.Salary + "|" + FirstName ;
        //}

        //public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        //{
        //    switch(BtnSubmit)
        //    {
        //        case "Save Employee":
        //            return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
        //        case "Cancel":
        //            return RedirectToAction("Index");
        //    }

        //    return new EmptyResult();
        //}

        //public ActionResult SaveEmployee()
        //{
        //    Employee emp = new Employee();
        //    emp.FirstName = Request.Form["FName"];
        //    emp.LastName = Request.Form["LName"];
        //    emp.Salary = int.Parse(Request.Form["Salary"]);

        //    return new EmptyResult();
        //}

        //public ActionResult SaveEmployee(string FName, string LName, string Salary)
        //{
        //    Employee emp = new Employee();
        //    emp.FirstName = FName;
        //    emp.LastName = LName;
        //    emp.Salary = int.Parse(Salary);

        //    return new EmptyResult();
        //}

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary != 0)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee", vm);

                    }

                case "Cancel":
                    return RedirectToAction("Index");
            }

            return new EmptyResult();
        }

    }
}