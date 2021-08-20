using DepartmentManagement.Interfaces;
using DepartmentManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentManagement.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments;
        public Department[] Departments => _departments;

        public void AddDepartment()
        {
            
        }

        public Employee[] AddEmployee(string EmployeeNo)
        {
            
        }

        public void EditDepartaments(string deportamentNo, string newdepartamentNo)
        {
            
        }

        public Employee[] EditEmploye(string EmployeeNo, string FullName, double Salary, string Position)
        {
            
        }

        public void GetDepartments(Department department)
        {
            
        }

        public Employee[] RemoveEmployee(string EmployeeNo, string Name)
        {
            
        }
    }
}
