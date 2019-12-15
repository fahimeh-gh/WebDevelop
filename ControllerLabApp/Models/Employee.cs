using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ControllerLabApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        //[Required(ErrorMessage ="Enter First Name")]
        [FirstNameValidation]
        public string FirstName { get; set; }
        [StringLength(5,ErrorMessage ="LastName Length should not be greater than 5")]
        public string LastName { get; set; }
        public int Salary { get; set; }
    }

    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value==null)
            {
                return new ValidationResult("Please Provide FirstName");
            }
            else
            {
                if (value.ToString().Contains("@"))
                    return new ValidationResult("First Name should not contain @");
            }

            return ValidationResult.Success;
        }
    }
}