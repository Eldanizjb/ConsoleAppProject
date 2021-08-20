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
                        break;
                    case "1.2":
                        break;
                    case "1.3":
                        break;
                    case "2.1":
                        break;
                    case "2.2":
                        break;
                    case "2.3":
                        break;
                    case "2.4":
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Duzgun secim etmeyinizi xahis edirik!");
                        break;
                }


            } while (true);
  
        }
    }
    
}
