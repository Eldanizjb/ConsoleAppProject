using System;

namespace DepartmentManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            DepartmentManagement.Services departamentService = new DepartmentManagement.Services();
            do
            {
                Console.WriteLine("Seçiminizi Edin");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("1.1 - Departameantlerin siyahisini gostermek");
                Console.WriteLine("1.2 - Departamenet yaratmaq");
                Console.WriteLine("1.3 - Departmanetde deyisiklik etmek");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("2.1 - Iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("2.3 - Isci elave etmek");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departamentden isci silinmesi ");

                string ans = Console.ReadLine();

                switch (ans)
                {
                    case "1.1":
                        ShowGroups(ref courseService);
                        break;
                    case "1.2":
                        AddGroup(ref courseService);
                        break;
                    case "1.3":
                        EditGroup(ref courseService);
                        break;
                    case "2.1":
                        ShowStudentsOfGroup(ref courseService);
                        break;
                    case "2.2":
                        ShowAllStudents(ref courseService);
                        break;
                    case "2.3":
                        ShowSearchedStudents(ref courseService);
                        break;
                    case "2.4":
                        AddStudent(ref courseService);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Secdiyiniz emeliyyat movcud deyil, tekrar secin!!!");
                        break;
                }


            } while (true);
  
        }
    }
    
}
