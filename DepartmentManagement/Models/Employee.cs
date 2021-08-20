using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentManagement.Models
{
    class Employee
    {
        public Employee(string position,double salary)
        {
            Position = position;

            _counter++;
            EmployeeNo = DepartamentName.Substring(0, 2).ToUpper() + _counter; 
        }
        private static int _counter = 1000;
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }

        private string _position;
        public string Position 
        {

            get {
                return _position; 
            }

            set {
                if (CheckPosition(value))
                {
                    _position = value;
                }
                else
                {
                    Console.WriteLine("Vezife Daxil Edilmeyib");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Vezife herifle ve ikiden cox olmalidir");
                    return;
                }
            } 
        }
        public double Salary { get; set; }
        public string DepartamentName { get; set; }

        public override string ToString()
        {
            return $"Ishcinin: nomresi;-{EmployeeNo }adı ve soyadı;-{FullName}vezifesi;-{Position}Emek haqqi;-{Salary}teyin olundugu bolme;-{DepartamentName}";
        }
        private bool CheckPosition(string position)
        {
            if (position.Length < 2)
                return false;

            foreach (char item in position)
            {
                if (!Char.IsLetter(item))
                    return false;
            }
            return true;
        }
    }

}
