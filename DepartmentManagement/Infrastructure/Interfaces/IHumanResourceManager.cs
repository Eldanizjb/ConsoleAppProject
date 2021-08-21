using System;
using System.Collections.Generic;
using System.Text;
using DepartmentManagement.Models;


namespace DepartmentManagement.Interfaces
{
    interface IHumanResourceManager
    {
        List<Department> Departments { get; }
        void AddDepartment(Department department);
        List<Department> GetDepartments();
        public void EditDepartaments(string ancientName, Department newName);
        void AddEmployee(Employee employee, string deartamentName);
        void RemoveEmployee(string rangeNo, string departamentName);
        List<Employee> EditEmploye(string rangeNo, string fullName, double salary, string position);
       

    }

}
