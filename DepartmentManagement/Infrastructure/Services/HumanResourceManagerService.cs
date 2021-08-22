using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using DepartmentManagement.Interfaces;
using DepartmentManagement.Models;

namespace DepartmentManagement.Services
{
    class HumanResourceManagerService : IHumanResourceManager
    {
        public HumanResourceManagerService()                       
        {
            _departments = new List<Department>();
            _employees = new List<Employee>();
        }
        private List<Department> _departments;                            
        public List<Department> Departments => _departments;     
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
        public void AddDepartment(Department department)
        {
            Department section = new Department();
            foreach (var item in Departments)
            {
                if (item == section)
                {
                    Console.WriteLine($"{item} Departament movcuddur!");
                    Console.WriteLine("Duzgun departament daxil edin");
                    return;
                }
            }
            _departments.Add(department);
        }                             // Added new Departament create new and chek old Departamens and Departament classes
        public List<Employee> EditEmploye(string rangeNo, string fullName, double salary, string position)
        {
            return _employees.FindAll(p => p.CheckNum.ToLower() == rangeNo.ToLower() && p.FullName.ToLower() == fullName.ToLower() && p.Salary == salary && p.Position.ToLower() == position.ToLower()).ToList();
        }        //Modifie Employee's return from Employee 
        public void AddEmployee(Employee employee, string deartamentName)                                     
        {
            Employee newemployee = new Employee();
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
            Department editedDepartament = _departments.Find(p => p.Name == ancientName);

            if (editedDepartament == null)
            {
                Console.WriteLine("Daxil edilen ada uygun Departament tapilmadi");
                return;
            }
            editedDepartament.Name = newName.Name;
        }//Modifie Departament create new Departament and check, use Departament class
        public void RemoveEmployee(string rangeNo, string departamentName)
        {
            var EmployeeList = _employees.ToList();
            var RemovedItem = _employees.Find(p => p.CheckNum.ToLower() == rangeNo.ToLower() && p.DepartamentName.ToLower() == departamentName.ToLower());
            _employees.Remove(RemovedItem);
        } // Find check Employee and Departament numbers. If true remove this Employee 
        internal void EditEmploye(Employee employee, string nameEmployee)
        {
            throw new NotImplementedException();
        }
    }
}






