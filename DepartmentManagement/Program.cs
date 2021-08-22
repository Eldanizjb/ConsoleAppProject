using System;
using System.Text;
using DepartmentManagement.Services;
using System.Collections.Generic;
using DepartmentManagement.Models;

namespace DepartmentManagement
{
    class Program
    {
        private static HumanResourceManagerService _newHumanResourse = new HumanResourceManagerService();
        public Program()
        {
            _newHumanResourse = new HumanResourceManagerService();
        }
        static void Main(string[] args)
        {
            HumanResourceManagerService departamentService = new HumanResourceManagerService();
            do
            {
                Console.WriteLine("-----------Salam Zehmet olmasa-------------");
                Console.WriteLine("-------------seçiminizi Edin-------------");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("1.1 - Departameantlerin siyahisini gostermek");
                Console.WriteLine("1.2 - Departamenet yaratmaq");
                Console.WriteLine("1.3 - Departmanetde deyisiklik etmek");

                string choos = Console.ReadLine();

                switch (choos)
                {
                    case "1.1":
                        ShowDepartament(ref departamentService);
                        break;
                    case "1.2":
                        AddDepartment(ref departamentService);
                        break;
                    case "1.3":
                        EditDepartment(ref departamentService);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun secim etmeyinizi xahis edirik!");
                        break;
                }
            } while (true);
        }
        static void EmployeeOperation(HumanResourceManagerService departamentService)
        {
            do
            {
                Console.WriteLine("2.1 - Iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("2.3 - Isci elave etmek");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departamentden isci silinmesi ");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Zehmet olmasa reqem ve noqte isaresinden istifade edin");

                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "2.1":
                        ShowAllEmployee(ref departamentService);
                        break;
                    case "2.2":
                        ShowEmployeesOfDepartament(ref departamentService);
                        break;
                    case "2.3":
                        AddEmployee(ref departamentService);
                        break;
                    case "2.4":
                        EditEmployee(ref departamentService);
                        break;
                    case "2.5":
                        RemoveEmployee(ref departamentService);
                        return;
                    default:
                        Console.WriteLine("Duzgun secim etmeyinizi xahis edirik!");
                        break;
                }
            } while (true);
        }                                                             
        static void ShowDepartament(ref HumanResourceManagerService departamentService)
        {
            Console.WriteLine("------Departameantlerin siyahisini gostermesi----------");

            foreach (var item in departamentService.GetDepartments())
            {
                Console.WriteLine($"Ishcinin adi: {item.Name} - Ishcilerin sayi: {item.WorkerLimit}- Ishcilerin ortalama maaslari: {item.CalcSalaryAverage()}");
            }
        }      //  Find all Departaments information. Use metod GetDepartments                        
        static void AddDepartment(ref HumanResourceManagerService departamentService)
        {
            Console.WriteLine("---------Departamenetin yaradılması-----------");
            Department newDepartment = new Department();
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Yeni Departmentin adını daxil edin");
                string DepartName = Console.ReadLine();

                Console.WriteLine("Departamentdə statda olacaq isci sayını daxil edin");
                string limitEmployee = Console.ReadLine();
                int limitWorker;

                while (!int.TryParse(limitEmployee, out limitWorker))
                {
                    Console.WriteLine("İsci sayını bir ve birden cox daxil edin");
                    limitEmployee = Console.ReadLine();
                    int.TryParse(limitEmployee, out limitWorker);
                }
                Console.WriteLine("Departamentdə statda olacaq isci əmək haqqını daxil edin");

                string limitSalary = Console.ReadLine();
                int countSalary;

                while (!int.TryParse(limitSalary, out countSalary))
                {
                    Console.WriteLine("İsci əmək haqqı 250 AZN-dən az ola bilməz");
                    limitSalary = Console.ReadLine();
                    int.TryParse(limitSalary, out countSalary);
                }
                newDepartment.Name = DepartName;
                newDepartment.SalaryLimit = countSalary;
                newDepartment.WorkerLimit = limitWorker;
                departamentService.AddDepartment(newDepartment);
                check = true;

            }
        } //  Added Departament. Chek from while for take true information. Use metod AddDepartments, Departament 
        static void EditDepartment(ref HumanResourceManagerService departamentService)
        {
            Console.WriteLine("--------------Departmanetde deyisikliklər---------------");

            Console.WriteLine("Əlavələr edəcəyiniz və ya dəyişəcəyiniz Departamentin adını daxil edin");
            string name = Console.ReadLine();

            Department changedepartment = departamentService.Departments.Find(h => h.Name.ToLower() == name.ToLower());
            if (changedepartment == null)
            {
                Console.WriteLine("Sistemdə Daxil etdiyiniz adda department tapılmadı.");
                return;
            }
            Console.WriteLine($"Departmentin adi: { changedepartment.Name} Deparmentin ortalama əmək haqqı: { changedepartment.SalaryLimit} Ştat üzrə işçi: {changedepartment.WorkerLimit}");
            Console.WriteLine("Departmentin yeni adını daxil edin:");
            string newDepartament = Console.ReadLine();
            Console.WriteLine("Departamentdə statda olacaq isci əmək haqqını daxil edin");
            string salaryLimit = Console.ReadLine();
            int limitSalary;
            while (!int.TryParse(salaryLimit, out limitSalary))
            {
                Console.WriteLine("Departamentdə statda olacaq isci əmək haqqını daxil edin:");
                salaryLimit = Console.ReadLine();
                int.TryParse(salaryLimit, out limitSalary);
            }
            Console.WriteLine("İsci əmək haqqı 250 AZN-dən az ola bilməz");

            string limitEmployee = Console.ReadLine();
            int limitWorker;
            while (!int.TryParse(limitEmployee, out limitWorker))
            {
                Console.WriteLine("İsci sayını bir ve birden cox daxil edin");
                limitEmployee = Console.ReadLine();
                int.TryParse(limitEmployee, out limitWorker);
            }
            changedepartment.Name = newDepartament;
            changedepartment.SalaryLimit = limitSalary;
            changedepartment.WorkerLimit = limitWorker;

            Console.WriteLine("Deyisiklikler bitdi.");
        }    //  Modifie and change Departament. Finde and Chek information. Use metod EditDepartments, Departament 
        static void ShowAllEmployee(ref HumanResourceManagerService departamentService)
            {
            Console.WriteLine("\n=============Ishcilerin siyahisi==================");
            if (departamentService.Employees.Count > 0)
            {
                foreach (var item in departamentService.Employees)
                {
                    Console.WriteLine($"Ishcinin nomresi: {item.EmployeeNo} - Ishcilerin adi ve soyadi: {item.FullName}- Ishcilerin vezifesi: {item.Position}- Ishcilerin maasi: {item.Salary}  ");
                }
                Console.WriteLine("===============================\n");
            }
            else
            {
                Console.WriteLine("\n===============================");
                Console.WriteLine("Sistemde ishci yoxdur!");
                Console.WriteLine("===============================\n");
            }
        } //  Shows all employees information in Departaments. Use Employee
        static void ShowEmployeesOfDepartament(ref HumanResourceManagerService departamentService)
            {
            Console.Write("Iscilerinin siyahisini istediyiniz Departamentin adini daxil edin: ");
            string departmentName = Console.ReadLine();
            Console.WriteLine();

            foreach (Employee item in _newHumanResourse.Employees)
            {
                if (departmentName.ToLower().Equals(item.DepartamentName))
                {
                    Console.WriteLine($"Nomres{ item.CheckNum} Adi ve SoyAdi{ item.FullName} Vezifesi{ item.Position} Emek haqqi{ item.Salary}");
                }
                Console.WriteLine($"{departmentName } departamenti movcud deyil!");
            }
        } //  Shows employees information in Departament which we will search. Use Employee and Departament
        static void AddEmployee(ref HumanResourceManagerService departamentService)
            {
            Console.WriteLine("----------Isci elave edilməsi---------");
            Employee employee = new Employee();

                Console.WriteLine("Yeni ishci barede melumatlari elave edin ");

                Console.Write("Daxil edeceyiniz Departamentin adını qeyd edin: ");
                string departmentName = Console.ReadLine();
                employee.DepartamentName = departmentName;
                Console.WriteLine();

                Console.Write("Adı, Soyadını daxil edin: ");
                string fullName = Console.ReadLine();
                employee.FullName = fullName;
                Console.WriteLine();

                Console.Write("Vəzifəsini daxil edin: ");
                string position = Console.ReadLine();
                employee.Position = position;
                Console.WriteLine();

                Console.Write("Emek haqqin daxil edin: ");

                string inputSalary = Console.ReadLine();
                double salary;

                while (!double.TryParse(inputSalary, out salary))
                {
                    Console.WriteLine("Zehmet olmasa reqem daxil edin");
                    inputSalary = Console.ReadLine();
                }

                employee.Salary = salary;
            employee.CheckNum = employee.CheckNum;
               departamentService.AddEmployee(employee,departmentName);      
        }      //  Added Emploee. Use metod AddDepartments Departament and Employee
        static void EditEmployee(ref HumanResourceManagerService departamentService)
        {
            Console.WriteLine("-----------Isci uzerinde deyisiklik edilməsi--------------");

            Employee employee = new Employee();
            Console.Write("Deyiseceyiniz Iscinin adını daxil edin: ");
            string nameEmployee = Console.ReadLine();
            Console.WriteLine();

            if (nameEmployee.ToLower().Equals(employee.FullName.ToLower()))
            {
                Console.Write("Yeni iscinin melumatlrin daxil edin: ");
                Console.Write("Adı, Soyadını daxil edin: ");
                string fullName = Console.ReadLine();
                employee.FullName = fullName;
                Console.WriteLine();

                Console.Write("Vəzifəsini daxil edin: ");
                string position = Console.ReadLine();
                employee.Position = position;
                Console.WriteLine();

                Console.Write("Emek haqqin daxil edin: ");
                string inputSalary = Console.ReadLine();
                double salary;

                while (!double.TryParse(inputSalary, out salary))
                {
                    Console.WriteLine("Zehmet olmasa reqem daxil edin");
                    inputSalary = Console.ReadLine();
                }
                employee.Salary = salary;
                employee.CheckNum = employee.EmployeeNo;
                departamentService.EditEmploye(employee, nameEmployee);
            }
        }    //  Modifie and change Employee. Finde and Chek information. Use metod EditEmployee, Emploee 
        static void RemoveEmployee(ref HumanResourceManagerService departamentService)
        {
            Console.WriteLine("-------------Departamentden iscinin silinmesi------------- ");
            Console.WriteLine("***Melumatlarin silmek istediyiniz işçinin nömrəsin yazin***");
                string no = Console.ReadLine();
                string departmentName = Console.ReadLine();
                _newHumanResourse.RemoveEmployee(no, departmentName);
        }  //  Delet Employee. Finde and Chek information. Use metod RemoveEmployee, Emploee                             
    }
}


