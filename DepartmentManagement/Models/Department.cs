using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentManagement.Models
{
    class Department
    {
        public Department (string name)
            {
            Name = name;
            }


        public int SalaryLimit { get; set; }
        public int WorkerLimit { get; set; }
        private Employee [] Employees { get; set; }                             ///+++++++++++++++++++++++++++++
        private string _name; 
        public string Name
        {
            get 
            {
                return _name;            
            }
            set 
            { 


            }
        }

        public Employee[] CalcSalaryAverage(double EmployeeSalary)
        {
            Employee returnSalaryEmploee = new Employee[0];
            foreach (Employee average in Employees)
            {
             //returnSalaryEmpl += average;    
            }
            return ; //resultSalaryEmployes/ Employees; 
        }

        private bool CheckDepartamentName (string name)
        {
            if (name.Length < 2)
                return false;

            foreach (char item in name)
            {
                if (!Char.IsLetter(item))
                    return false;
            }
            return true;
        }


    }
}
