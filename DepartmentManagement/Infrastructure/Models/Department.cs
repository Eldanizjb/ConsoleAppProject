using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentManagement.Models
{
    class Department
    {
        public Department()
        { 
        
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (CheckName(value))                  // CheckPosition method was used for position consisted of no less than two letters
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Deportamentin adi iki herfden cox olmalidir");
                }
            }
        }                                    
        private int _workerLimit;
        public int WorkerLimit
        {
            get
            {
                return _workerLimit;
            }
            set
            {
                if (value >= 1)                                                   //limit for employees in the sections                    
                {
                    _workerLimit = value;
                }
                else
                {
                    Console.WriteLine("Ishcilerin sayi birden cox olmalidir");
                }
            }
        }
        private double _salaryLimit;                                              
        public double SalaryLimit
        {
            get
            {
                return _salaryLimit;
            }
            set
            {
                if (value > 250)                                                   // limit for employee's salary
                {
                    _salaryLimit = value;
                }
                else
                {
                    Console.WriteLine("Emek haqqi 250 azn-den ashagi ola bilmez");
                }
            }
        }
        private List<Employee> _employees;
        public List<Employee> Employees                                   // greated for will use other classes
        {          

            get
            {
                return _employees;
            }
        } 
        public double CalcSalaryAverage()                                // This metod for find average salary of employees
        {
            double SumSalary = 0;
            double AvarageSalary = 0;
           
            foreach (var employee in Employees)
            {
                SumSalary += employee.Salary;
            }
            if (Employees.Count != 0)
            {
                AvarageSalary = SumSalary / Employees.Count;
            }
            else 
            {
                return 0; 
            }
            return AvarageSalary;
        }
        private bool CheckName(string Name)                                // This metod for position
        {
            if (Name.Length >= 2)
            {
                return false;
            }
            foreach (char item in Name)
            {
                if (!Char.IsLetter(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
