using System;
using System.Text;
using DepartmentManagement.Services;
using System.Collections.Generic;
using DepartmentManagement.Models;

namespace DepartmentManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManagerService departamentService = new HumanResourceManagerService();
            startPprogram(departamentService);
        }
        static void startPprogram(HumanResourceManagerService departamentService)
        {
            do
            {
                Console.WriteLine("===Aparilacaq emeliyyatlarla bagli===");
                Console.WriteLine("----------seçiminizi edin------------");
                Console.WriteLine("1.1 Departmentle bagli emeliyyatlar");
                Console.WriteLine("1.2 Iscilerle bagli emeliyyatlar");                                     //Added new menu

                string choos = Console.ReadLine();

                switch (choos)
                {
                    case "1.1":
                        DepartamentOperation(departamentService);
                        break;

                    case "1.2":
                        EmployeeOperation(departamentService);
                        break;
                    default:
                        Console.Clear();
                        break;
                }

            } while (true);
        }
        static void DepartamentOperation(HumanResourceManagerService departamentService)
        {
            do                
            {
                    Console.WriteLine("-----------Salam Zehmet olmasa-------------");
                    Console.WriteLine("-------------seçiminizi Edin-------------");
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("1.1 - Departamentlerin siyahisini gostermek");
                    Console.WriteLine("1.2 - Departamenet yaratmaq");
                    Console.WriteLine("1.3 - Departamnetde deyisiklik etmek");
                    Console.WriteLine("1.4 - Esas menyuya qayidin");

                    string choos = Console.ReadLine();

                    switch (choos)
                    {
                        case "1.1":
                            ShowDepartament(departamentService);
                            break;
                        case "1.2":
                            AddDepartment(departamentService);
                            break;
                        case "1.3":
                            EditDepartment(departamentService);
                            break;
                        case "1.4":
                            startPprogram(departamentService);
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
                    Console.WriteLine("-----------Iscilerle bagli -------------");
                    Console.WriteLine("-----------seçiminizi Edin--------------");
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("2.1 - Iscilerin siyahisini gostermek");
                    Console.WriteLine("2.2 - Departamentdeki iscilerin siyahisini gostermrek");
                    Console.WriteLine("2.3 - Isci elave etmek");
                    Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                    Console.WriteLine("2.5 - Departamentden isci silinmesi ");
                    Console.WriteLine("2.6 - Esas menyuya qayidin");                                              // this button about return first menu    

                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Zehmet olmasa reqem ve noqte isaresinden istifade edin");

                    string choose = Console.ReadLine();

                    switch (choose)
                    {
                        case "2.1":
                            ShowAllEmployee(departamentService);
                            break;
                        case "2.2":
                            ShowEmployeesOfDepartament(departamentService);
                            break;
                        case "2.3":
                            AddEmployee(departamentService);
                            break;
                        case "2.4":
                            EditEmployee(departamentService);
                            break;
                        case "2.5":
                            RemoveEmployee(departamentService);
                            return;
                        case "2.6":
                            startPprogram(departamentService);                                      // this button about return first menu
                        return;
                         default:
                            Console.WriteLine("Duzgun secim etmeyinizi xahis edirik!");
                            break;
                    }
             } while (true);
        }
        static void ShowDepartament(HumanResourceManagerService departamentService)
        {
                Console.WriteLine("------Departameantlerin siyahisini gostermesi----------");

                foreach (var item in departamentService.GetDepartments())
                {
                    Console.WriteLine($"Ishcinin adi: {item.Name} - Ishcilerin sayi: {item.WorkerLimit}- Ishcilerin ortalama maaslari: {item.CalcSalaryAverage()}");
                }
        }      //  Find all Departaments information. Use metod GetDepartments                        
        static void AddDepartment(HumanResourceManagerService departamentService)
        {
                Console.WriteLine("---------Departamenetin yaradılması-----------");
                Department newDepartment = new Department();
                bool check = false;
                while (!check)
                {
                    Console.WriteLine("Yeni Departmentin adını daxil edin");
                    string DepartName = Console.ReadLine();

                    Console.WriteLine("Departamentde statda olacaq isci sayını daxil edin");
                    string limitEmployee = Console.ReadLine();
                    int limitWorker;

                while (!int.TryParse(limitEmployee, out limitWorker))
                    {
                        Console.WriteLine("İsci sayını bir ve birden cox daxil edin");
                        limitEmployee = Console.ReadLine();
                        int.TryParse(limitEmployee, out limitWorker);
                    }
                    Console.WriteLine("Departamentde statda olacaq isci emek haqqını daxil edin");

                    string limitSalary = Console.ReadLine();                                            // find miktake change int type to double
                    double countSalary;                                                               

                    while (!double.TryParse(limitSalary, out countSalary))
                    {
                        Console.WriteLine("İsci emek haqqı 250 AZN-den az ola bilmez");
                        limitSalary = Console.ReadLine();
                        double.TryParse(limitSalary, out countSalary);
                    }
                    newDepartment.Name = DepartName;
                    newDepartment.SalaryLimit = countSalary;
                    newDepartment.WorkerLimit = limitWorker;
                    departamentService.AddDepartment(newDepartment);
                    check = true;

                }
        } //  Added Departament. Chek from while for take true information. Use metod AddDepartments, Departament 
        static void EditDepartment(HumanResourceManagerService departamentService)
        {
                Console.WriteLine("--------------Departmanetde deyisiklikler---------------");

                Console.WriteLine("Elaveler edeceyiniz ve ya deyişeceyiniz Departamentin adını daxil edin");
                string name = Console.ReadLine();

                Department changedepartment = departamentService.Departments.Find(h => h.Name.ToLower() == name.ToLower());
                if (changedepartment == null)
                {
                    Console.WriteLine("Sistemde Daxil etdiyiniz adda department tapılmadı.");
                    return;
                }
                Console.WriteLine($"Departmentin adi: { changedepartment.Name} Deparmentin ortalama emek haqqı: { changedepartment.SalaryLimit} Ştat üzre işçi: {changedepartment.WorkerLimit}");
               
                Console.WriteLine("Departmentin yeni adını daxil edin:");
            string newDepartament = Console.ReadLine();

            Console.WriteLine("Departamentde statda olacaq isci sayını daxil edin");
            string limitEmployee = Console.ReadLine();
            int limitWorker;
            while (!int.TryParse(limitEmployee, out limitWorker))
            {
                Console.WriteLine("İsci sayını bir ve birden cox daxil edin");
                limitEmployee = Console.ReadLine();
                int.TryParse(limitEmployee, out limitWorker);
            }

            Console.WriteLine("Departamentde statda olacaq isci emek haqqını daxil edin");
                string salaryLimit = Console.ReadLine();
                double limitSalary;

                while (!double.TryParse(salaryLimit, out limitSalary))
                {
                Console.WriteLine("İsci emek haqqı 250 AZN-den az ola bilmez");
                salaryLimit = Console.ReadLine();
                double.TryParse(salaryLimit, out limitSalary);
                }
                 changedepartment.Name = newDepartament;
                changedepartment.SalaryLimit = limitSalary;
                changedepartment.WorkerLimit = limitWorker;
                
                Console.WriteLine("Deyisiklikler bitdi.");
        }    //  Modifie and change Departament. Finde and Chek information. Use metod EditDepartments, Departament 
        static void ShowAllEmployee(HumanResourceManagerService departamentService)
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
        static void ShowEmployeesOfDepartament(HumanResourceManagerService departamentService)
        {
                Console.Write("Iscilerinin siyahisini istediyiniz Departamentin adini daxil edin: ");
                string departmentName = Console.ReadLine();
                Console.WriteLine();

                foreach (Employee item in departamentService.Employees)
                {
                    if (departmentName.ToLower().Equals(item.DepartamentName))
                    {
                        Console.WriteLine($"Nomres{ item.CheckNum} Adi ve SoyAdi{ item.FullName} Vezifesi{ item.Position} Emek haqqi{ item.Salary}");
                    }
                    Console.WriteLine($"{departmentName } departamenti movcud deyil!");
                }
            } //  Shows employees information in Departament which we will search. Use Employee and Departament
        static void AddEmployee(HumanResourceManagerService departamentService)
        {
                Console.WriteLine("----------Isci elave edilmesi---------");
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

                Console.Write("Vezifesini daxil edin: ");
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
                departamentService.AddEmployee(employee, departmentName);
        }      //  Added Emploee. Use metod AddDepartments Departament and Employee
        static void EditEmployee(HumanResourceManagerService departamentService)
        {
                Console.WriteLine("-----------Isci uzerinde deyisiklik edilmesi--------------");

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

                    Console.Write("Vezifesini daxil edin: ");
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
                   // departamentService.EditEmploye(employee, nameEmployee);
                }
        }    //  Modifie and change Employee. Finde and Chek information. Use metod EditEmployee, Emploee 
        static void RemoveEmployee(HumanResourceManagerService departamentService)
        {
                Console.WriteLine("-------------Departamentden iscinin silinmesi------------- ");
                Console.WriteLine("***Melumatlarin silmek istediyiniz işçinin nömresin yazin***");
                string num = Console.ReadLine();
                string departmentName = Console.ReadLine();
                Department department = departamentService.Departments.Find (p => p.Name == departmentName);
                for (int item = 0; item < department.Employees.Count; item++)
                {
                    if (department.Employees[item].EmployeeNo == num)
                    {
                            department.Employees.Remove(department.Employees[item]);
                            Console.WriteLine("Isci sistemden silindi");
                            return;
                    }
                }
        }  //  Delet Employee. Finde and Chek information. Use metod RemoveEmployee, Emploee                             
        
    }
}



