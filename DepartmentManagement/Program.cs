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
        #region Menyu
        static void startPprogram(HumanResourceManagerService departamentService)
        {
            do
            {
                Console.WriteLine(Environment.NewLine);
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
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("-----------Salam Zehmet olmasa-------------");
                Console.WriteLine("-------------seçiminizi edin-------------");
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
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("-----------Iscilerle bagli -------------");
                Console.WriteLine("----------seçiminizi edin--------------");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("2.1 - Iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("2.3 - Isci elave etmek");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departamentden isci silinmesi ");
                Console.WriteLine("2.6 - Esas menyuya qayidin");                                              // this button about return first menu    
                Console.WriteLine(Environment.NewLine);
  
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
        #endregion
        #region Operation side
        static void ShowDepartament(HumanResourceManagerService departamentService)
        {
            Console.WriteLine("------Departamentlerin siyahisini gostermesi----------");

            if (departamentService.Departments.Count > 0)
            {
                foreach (Department item in departamentService.Departments)
                {
                    if (item.Employees.Count > 0)
                    {
                        Console.WriteLine($"Departamentin adi: { item.Name}\nIshcilerin sayi:{ item.WorkerLimit}\nIshcilerin ortalama maaslari:{ item.CalcSalaryAverage()}");
                    }
                    else
                        Console.WriteLine($"Departamentin adi: { item.Name}\nIshcilerin sayi:{ item.WorkerLimit}\nIshcilerin ortalama maaslari:{ item.CalcSalaryAverage()}");
                        Console.WriteLine($"Hal-hazirda {item.Name} departamentinde isci yoxdur");
                }
            }
            else
                Console.WriteLine($"---------Sistemde departament yoxdur------------");
        }      //  Find all Departaments information. Use metod GetDepartments                        
        static void AddDepartment(HumanResourceManagerService departamentService)
        {
            Console.WriteLine("---------Departamenetin yaradılması-----------");
            Department newDepartment = new Department();
            Console.WriteLine("Yeni Departmentin adını daxil edin");
            string DepartName = Console.ReadLine();
            foreach (Department item in departamentService.Departments)
            {
                if (item.Name == DepartName)
                {
                    Console.WriteLine($"Sistemde {DepartName} adda departament movcuddur");
                    return;
                }
            }
            bool check = false;
            while (!check)
            {
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

        }    //  Modifie and change Departament. Finde and Chek information. Use metod EditDepartments, Departament 
        static void ShowAllEmployee(HumanResourceManagerService departamentService)
        {
            Console.WriteLine("\n=====Ishcilerin siyahisi==========");

            if (departamentService.Departments.Count > 0)
            {
                for (int first = 0; first < departamentService.Departments.Count; first++)
                {

                    Department findEmployees = departamentService.Departments[first];
                    for (int second = 0; second < findEmployees.Employees.Count; second++)
                    {
                        Console.WriteLine($"Departmentin adi: {findEmployees.Name}; Iscinin is nomresi: {findEmployees.Employees[second].EmployeeNo}; Iscinin Ad Soyadi: {findEmployees.Employees[second].FullName}; Iscinin vezifesi: {findEmployees.Employees[second].Position}; Iscinin emek haqqi: {findEmployees.Employees[second].Salary}");
                    }
                }
            }
            else
            {
                Console.WriteLine("\n===============================");
                Console.WriteLine("     Sistemde ishci yoxdur");
                Console.WriteLine("===============================\n");
            }
        } //  Shows all employees information in Departaments. Use Employee
        static void ShowEmployeesOfDepartament(HumanResourceManagerService departamentService)
        {
            Console.WriteLine("Iscilerinin siyahisini istediyiniz Departamentin adini daxil edin: ");
            string Department = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            Department findDepartment = departamentService.Departments.Find(p => p.Name.ToLower() == Department.ToLower());

            if (findDepartment != null)
            {
                for (int item = 0; item < findDepartment.Employees.Count; item++)
                {
                    Console.WriteLine($"\n Iscinin is nomresi: {findDepartment.Employees[item].EmployeeNo}\n Iscinin adi ve soyadi: {findDepartment.Employees[item].FullName} \n Iscinin vezifesi: {findDepartment.Employees[item].Position} \n Iscinin emek haqqi: {findDepartment.Employees[item].Salary}");
                }
            }
            else
            {
                Console.WriteLine($"{findDepartment} adinda department yoxdur");
            }
            if (findDepartment.Employees.Count == 0)
            {
                Console.WriteLine($"Sistemde {findDepartment} Departamenti movcuddur, lakin isci elave edilmeyib");
            }
        } //  Shows employees information in Departament which we will search. Use Employee and Departament
        static void AddEmployee(HumanResourceManagerService departamentService)
        {
            Console.WriteLine("----------Isci elave edilmesi---------");

            Console.WriteLine("Yeni ishci barede melumatlari elave edin");

            Console.Write("Daxil edeceyiniz Departamentin adını qeyd edin:");

            string departmentName = Console.ReadLine();
            foreach (Department item in departamentService.Departments)
            {
                if (item.Name != departmentName)
                {
                    Console.WriteLine($"Sistemde {departmentName} adda departament movcud deyil");
                    return;
                }
            }
            Employee employee = new Employee(departmentName);

            Console.Write("Adı ve soyadını daxil edin: ");
            string fullName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Vezifesini daxil edin: ");
            string position = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Emek haqqin daxil edin: ");
            string inputSalary = Console.ReadLine();
            double salary;
            while (!double.TryParse(inputSalary, out salary))
            {
                Console.WriteLine("Zehmet olmasa reqem daxil edin");
                inputSalary = Console.ReadLine();
                double.TryParse(inputSalary, out salary);
            }
            employee.FullName = fullName;
            employee.Position = position;
            employee.Salary = salary;
            departamentService.AddEmployee(employee, departmentName);
        }      //  Added Emploee. Use metod AddDepartments Departament and Employee
        static void EditEmployee(HumanResourceManagerService departamentService)
        {
            {
                Console.WriteLine("--------------Isci barede deyisiklikler---------------");

                Console.WriteLine("Deyisiklik  etmek ucun istediyiniz iscinin nomresini daxil edin!!!");
                string EmpNumbers = Console.ReadLine();

                string employeName = " ";
                string employePosition = " ";
                double employeSalary = 0;

                int resultDepCount = 0;
                int resultEmpCount = 0;

                bool check = false;

                for (int first = 0; first < departamentService.Departments.Count; first++)
                {
                    for (int second = 0; second < departamentService.Departments[second].Employees.Count; second++)
                    {
                        if (EmpNumbers == departamentService.Departments[first].Employees[second].EmployeeNo)
                        {
                            check = true;
                            if (check)
                            {
                                employeName = departamentService.Departments[first].Employees[second].FullName;
                                employePosition = departamentService.Departments[first].Employees[second].Position;
                                employeSalary = departamentService.Departments[first].Employees[second].Salary;

                                resultDepCount = first;
                                resultEmpCount = second;
                            }

                            break;
                        }
                    }
                }
                if (check)
                {
                    Console.WriteLine($"Iscinin adi ve soy adi:{ employeName}; Iscinin vezifesi:{ employePosition}; iscinin emek haqqi:{ employeSalary}");

                    Console.WriteLine("Yeni vezifeni daxil edin");
                    string employeeNewPosition = Console.ReadLine();

                    Console.WriteLine("Yeni emek haqqi daxil edin");
                    string employeeNewSalary = Console.ReadLine();
                    double changeSalary;
                    while (!double.TryParse(employeeNewSalary, out changeSalary))
                    {
                        Console.WriteLine("İsci emek haqqı 250 AZN-den az ola bilmez");
                        employeeNewSalary = Console.ReadLine();
                        double.TryParse(employeeNewSalary, out changeSalary);
                    }

                    departamentService.Departments[resultDepCount].Employees[resultEmpCount].Position = employeeNewPosition;
                    departamentService.Departments[resultDepCount].Employees[resultEmpCount].Salary = changeSalary;
                }
                else
                    Console.WriteLine("Iscinin nomresin duzgun daxil et");
                EditEmployee(departamentService);


            }
        }        //  Modifie and change Employee. Finde and Chek information. Use metod EditEmployee,Find Departament and Emploee 
        static void RemoveEmployee(HumanResourceManagerService departamentService)
        {
            Console.WriteLine("-------------Departamentden iscinin silinmesi------------- ");
            Console.WriteLine("Melumatlarin silmek istediyiniz işçinin nömresin yazin");
            string numEmployee = Console.ReadLine();

            Console.WriteLine("Melumatlarin silmek istediyiniz Departameniinin adini yazin");
            string departamentName = Console.ReadLine();

            Department department = new Department();
            Employee employee = new Employee();

            if (numEmployee != null && departamentName != null)
            {
                employee.EmployeeNo = numEmployee;
                department.Name = departamentName;
                departamentService.RemoveEmployee(numEmployee, departamentName);
            }
        }        //  Delet Employee. Finde and Chek information. Use metod RemoveEmployee, Emploee                       
        #endregion
    }
}



