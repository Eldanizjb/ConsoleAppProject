using System;
using System.Text;
using System.Collections.Generic;
using DepartmentManagement.Interfaces;
using DepartmentManagement.Models;

namespace DepartmentManagement.Services
{
    class HumanResourceManagerService : IHumanResourceManager
    {
        public HumanResourceManagerService()                       //
        {
            _departments = new List<Department>();                 //
            _employees = new List<Employee>();
        }
        private List<Department> _departments;                       //       
        public List<Department> Departments => _departments;        //
        //{
        //    get 
        //    {
        //        return _departments;
        //    }
        //}
        private List<Employee> _employees;             
        public List<Employee> Employees => _employees;             
        //{
        //    get 
        //    {
        //        return _employees;
        //    }
        //}
        public void AddDepartment(Department department)                     //
        {
            //Department section = new Department();
            //foreach (var item in Departments)
            //{
            //    if (item == section)
            //    {
            //        Console.WriteLine($"{item} Departament movcuddur!");
            //        Console.WriteLine("Duzgun departament daxil edin");
            //        return;
            //    }
            //}
            _departments.Add(department);
        }                             // Added new Departament create new and chek old Departamens and Departament classes
        public void EditEmploye(string rangeNo, string fullName, double salary, string position, Employee employee)
        {
            Employee editEmployee = new Employee();
            foreach (Department list in _departments)
            {
                for (int item = 0; item < list.Employees.Count; item++)
                {
                    if (list.Employees[item].EmployeeNo != rangeNo)
                    {
                        Console.WriteLine("Axtardiginiz adda isci yoxdur");
                    }
                    else
                    {
                        Console.WriteLine($"Ishcinin adi ve soyadi:{ list.Employees[item].FullName}\nIscinin vezifesi:{ list.Employees[item].Position}\nIscinin emek haqqi:{ list.Employees[item].Salary}");
                        editEmployee.FullName = employee.FullName;
                        editEmployee.Salary = employee.Salary;
                        editEmployee.Position = employee.Position;
                        return;
                    }
                }
            }
        }        //Modifie Employee's return from Employee 
        public void AddEmployee(Employee employee, string deartamentName)                                     
        {
            Employee newemployee = new Employee();
            newemployee.EmployeeNo = employee.EmployeeNo;
            newemployee.FullName = employee.FullName;
            newemployee.Salary = employee.Salary;
            newemployee.Position = employee.Position;
            foreach (Department item in Departments)
            {
                if (item.Name.ToLower() == deartamentName.ToLower())
                {
                    item.Employees.Add(newemployee);
                }
            }
        }//Added Employee's to Departament use Employee and Departament classes
        public List<Department> GetDepartments()
        {
            return Departments;
        }                                     // Find Departaments use Departament class
        public void EditDepartaments(string ancientName, Department newName)                                 
        {
            //   Department editedDepartament = _departments.Find(p => p.Name == ancientName);
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() != ancientName.ToLower())
                {
                    Console.WriteLine("Daxil edilen ada uygun Departament tapilmadi");
                }
                item.Name = newName.Name;
            }
            
        }//Modifie Departament create new Departament and check, use Departament class
        public void RemoveEmployee(string rangeNo, string departamentName)
        {
            foreach (Department list in _departments)
            {
                if (list.Name.ToLower() == departamentName.ToLower())
                {
                    for (int item = 0; item < list.Employees.Count; item++)
                    {
                        if (list.Employees[item].EmployeeNo != rangeNo)
                        {
                            list.Employees.Remove(list.Employees[item]);
                            Console.WriteLine("ishci siyahidan silindi:)");
                        }
                        else
                        {
                            Console.WriteLine("Daxil etdiyiniz isci sistemde yoxdur");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Departamentin adini duzgun daxil edin");
                }
            } // Find check Employee and Departament numbers. If true remove this Employee 
        }
    }
}






