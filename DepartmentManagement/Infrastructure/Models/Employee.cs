using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentManagement.Models
{
    class Employee                                                                      
    {

        public Employee()
        {
   
        }
          
        public Employee (string section) : this()                                                          
        {
            DepartamentName = section;
            _counter++;      
            EmployeeNo = DepartamentName.Substring(0, 2).ToUpper() + _counter;      // The first two letters of the section will be added in front of employee's number
        }
        private static int _counter = 1000;                                                // emlloyee's number will begin 1000 number
        public string EmployeeNo { get; set; }                                    
        public string FullName { get; set; }
        private string _position;                                                                                                 
        public string Position                                                   
        {
            get
            {
                return _position; 
            }
            set {
                if (CheckPosition(value))                                  // CheckPosition method was used for position consisted of no less than two letters
                {
                    _position = value;
                }
                else
                {
                    Console.WriteLine("      Vezife Daxil Edilmeyib");
                    Console.WriteLine("======================================");
                    Console.WriteLine("Vezife herifle ve ikiden cox olmalidir");
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
                }
                else
                 Console.WriteLine("Emek haqqi 250 azn-den ashagi ola bilmez");
            }
        }
        public string CheckNum { get; set; }
        public string DepartamentName { get; set; }                 
        public override string ToString()                                       // call for return informations
        {
            return $"Ishcinin: nomresi;-{EmployeeNo }adı ve soyadı;-{FullName}vezifesi;-{Position}Emek haqqi;-{Salary}teyin olundugu bolme;-{DepartamentName}";
        }
        private bool CheckPosition(string Name)                                  // This metod for position
        {
            if (Name.Length < 2)
            {
                return false;
            }
            foreach (char item in Name)                                                            
            {
                if (!Char.IsLetter(item))
                {
                    return false; 
                } 
            }return true;
        }
    }
}
