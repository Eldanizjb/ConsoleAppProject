using System;
using System.Collections.Generic;
using System.Text;
using DepartmentManagement.Models; 


namespace DepartmentManagement.Interfaces
{
    interface IHumanResourceManager
    {
        public Department[] Departments { get; set; }

        public void AddDepartment();
        public void GetDepartments(Department department);
        public void EditDepartaments(string deportamentNo, string newdepartamentNo);
        public Employee[] AddEmployee(string EmployeeNo);
        public Employee[] RemoveEmployee(string EmployeeNo, string Name);
        public Employee[] EditEmploye(string EmployeeNo, string FullName, double Salary, string Position);


    }

}
