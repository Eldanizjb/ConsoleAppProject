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
        }
        public List<Employee> EditEmploye(string rangeNo, string fullName, double salary, string position)
        {
            return _employees.FindAll(p => p.CheckNum.ToLower() == rangeNo.ToLower() && p.FullName.ToLower() == fullName.ToLower() && p.Salary == salary && p.Position.ToLower() == position.ToLower()).ToList();
        }
        public void AddEmployee(Employee employee, string deartamentName)                  
        {
            _employees.Add(employee);
         }
        public List<Department> GetDepartments()
        {
            return Departments;
        }
        public void RemoveEmployee(string rangeNo, string departamentName)
        {
            var EmployeeList = _employees.ToList();
            var RemovedItem = _employees.Find(p => p.CheckNum.ToLower() == rangeNo.ToLower() && p.DepartamentName.ToLower() == departamentName.ToLower());
            _employees.Remove(RemovedItem);
        }
        public void EditDepartaments(string ancientName, Department newName)
        {
            Department editedDepartament = _departments.Find(p => p.Name == ancientName);

            if (editedDepartament == null)
            {
                Console.WriteLine("Daxil edilen ada uygun Departament tapilmadi");
                return;
            }
            editedDepartament.Name = newName.Name;
        }
    }
}






