using System;
using System.Collections.Generic;
using System.Text;
using DepartmentManagement.Models;

namespace DepartmentManagement.Interfaces
{
    interface IHumanResourceManager
    {
        public List<Department> Departments { get; }                                             // these are interfaces for use Services
        public void AddDepartment(Department department);                             
        public List<Department> GetDepartments();
        public void EditDepartaments(string ancientName, Department newName);
        public void AddEmployee(Employee employee, string deartamentName);
        public void RemoveEmployee(string rangeNo, string departamentName);
        public void EditEmploye(string rangeNo, string fullName, double salary, string position, Employee employee );
    }
}
