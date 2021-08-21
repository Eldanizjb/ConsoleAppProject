using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentManagement.Models
{
    class Employee
    {
        public Employee(string position)
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
                    Console.WriteLine("      Vezife Daxil Edilmeyib");
                    Console.WriteLine("======================================");
                    Console.WriteLine("Vezife herifle ve ikiden cox olmalidir");
                    return;
                }
            } 
        }
        private double _salary;
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value > 250)
                {
                    _salary = value;
                }else
                 Console.WriteLine("Emek haqqi 250 azn-den ashagi ola bilmez");
            }
        }
        public string CheckNum { get; set; }
        public string DepartamentName { get; set; }                 
        public override string ToString()
        {
            return $"Ishcinin: nomresi;-{EmployeeNo }adı ve soyadı;-{FullName}vezifesi;-{Position}Emek haqqi;-{Salary}teyin olundugu bolme;-{DepartamentName}";
        }
        private bool CheckPosition(string Name)
        {
            foreach (char letter in Name)                                                             /////////////// deligate
            {
                if ((!Char.IsLetter(letter)) && (Name.Length < 2))
                    return false;
            }return true;
        }
    }
}
