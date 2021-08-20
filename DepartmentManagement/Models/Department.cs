using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentManagement.Models
{
    class Department
    {
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




    }
}
