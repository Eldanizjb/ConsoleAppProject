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
        }                                //complected full
        static void ShowDepartament(ref HumanResourceManagerService departamentService)
        {
            foreach (var item in departamentService.GetDepartments())
            {
                Console.WriteLine($"Ishcinin adi: {item.Name} - Ishcilerin sayi: {item.WorkerLimit}- Ishcilerin ortalama maaslari: {item.CalcSalaryAverage()}");
            }
        }                              //complected full  1
        static void AddDepartment(ref HumanResourceManagerService departamentService)
        {
            Console.WriteLine("Departamentin Adini Daxil Edin:");
            string departamentName = Console.ReadLine();
            Console.WriteLine("Ishcilerin Emek haqqin Daxil Et");
            string Salary = Console.ReadLine();
            double departamentSalary;
            while (!double.TryParse(Salary, out departamentSalary))
            {
                Console.WriteLine("Ishcilerin Emek haqqin Duzgun Daxil Et");
                Salary = Console.ReadLine();
                double.TryParse(Salary, out departamentSalary);
            }
            Console.WriteLine("Ishcilerin Sayini Daxil Et");
            string count = Console.ReadLine();
            int employeeCount;
            while (!int.TryParse(count, out employeeCount))
            {
                Console.WriteLine("Iscilerin Sayini Duzgun Daxil Et");
                count = Console.ReadLine();
                int.TryParse(count, out employeeCount);
            }

            Department department = new Department
            {
                Name = departamentName,
                WorkerLimit = employeeCount,
                SalaryLimit = departamentSalary,
            };
            departamentService.AddDepartment(department);

        }                                 //complected full 4       
        static void EditDepartment(ref HumanResourceManagerService departamentService)
        {
            Department department = new Department();
            Console.Write("Deyiseceyiniz Departamentin adını daxil edin: ");
            string nameDepartament = Console.ReadLine();
            Console.WriteLine();

            if (nameDepartament.ToLower().Equals(department.Name.ToLower()))
            {
                Console.Write("Departamentin yeni adını daxil edin: ");
                string changingName = Console.ReadLine();
                department.Name = changingName;

                departamentService.EditDepartaments(nameDepartament, department);
            }
        }                                //complected
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
        }                               //complected 5
        static void ShowEmployeesOfDepartament(ref HumanResourceManagerService departamentService)
            {
            Console.Write("Iscilerinin siyahisini istediyiniz Departamentin adini daxil edin: ");
            string departmentName = Console.ReadLine();
            Console.WriteLine();

            if (departamentService.EditDepartaments == null)
            {
                Console.WriteLine($"{group} nomreli qrup movcud deyil!");
                return;
            }

            foreach (Employee item in _newHumanResourse.Employees)
            {
                if (departmentName.ToLower().Equals(item.DepartamentName))
                {
                    Console.WriteLine($"Nomres{ item.CheckNum} Adi ve SoyAdi{ item.FullName} Vezifesi{ item.Position} Emek haqqi{ item.Salary}");
                }
            }
        }
        static void AddEmployee(ref HumanResourceManagerService departamentService)
            {
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
                employee.CheckNum = employee.EmployeeNo;
            }                                 //complected full  2
        static void EditEmployee(ref HumanResourceManagerService departamentService)
            {
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
                //departamentService.EditEmploye(employee, nameEmployee);
            }
        }
        static void RemoveEmployee(ref HumanResourceManagerService departamentService)
            {
                Console.WriteLine("***Melumatlarin silmek istediyiniz işçinin nömrəsin yazin***");
                string no = Console.ReadLine();
                string departmentName = Console.ReadLine();
                _newHumanResourse.RemoveEmployee(no, departmentName);
            }                               //complected full  3
    }
}

