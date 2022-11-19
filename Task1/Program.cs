using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*1.    Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  
             * частотой  работы  процессора,  объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, 
             * стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии. Создать список, 
             * содержащий 6-10 записей с различным набором значений характеристик.
            Определить:
            - все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            - все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
            - вывести весь список, отсортированный по увеличению стоимости;
            - вывести весь список, сгруппированный по типу процессора;
            - найти самый дорогой и самый бюджетный компьютер;
            - есть ли хотя бы один компьютер в количестве не менее 30 штук?
             */

            List<Computer> computers = new List<Computer>()
            {
            new Computer(){Code="1",Mark="Acer",CPU_Name="Ryzen5900x",CPU_Frequency=3900,RAM_Capacity=64,HDD_Capacity=1024,GPU_Memory=20,Price=200000,Count=10},
            new Computer(){Code="1",Mark="Asus",CPU_Name="i5-3570",CPU_Frequency=3570,RAM_Capacity=16,HDD_Capacity=300,GPU_Memory=16,Price=80000,Count=100},
            new Computer(){Code="1",Mark="Dell",CPU_Name="i9-12900K",CPU_Frequency=3200,RAM_Capacity=32,HDD_Capacity=512,GPU_Memory=20,Price=150000,Count=20},
            new Computer(){Code="1",Mark="MSI",CPU_Name="Ryzen5900x",CPU_Frequency=3900,RAM_Capacity=12,HDD_Capacity=400,GPU_Memory=16,Price=160000,Count=50},
            new Computer(){Code="1",Mark="GIGABYTE",CPU_Name="i3-10100",CPU_Frequency=3600,RAM_Capacity=8,HDD_Capacity=200,GPU_Memory=4,Price=50000,Count=150},
            new Computer(){Code="1",Mark="HP",CPU_Name="Athlon 3000G",CPU_Frequency=3500,RAM_Capacity=8,HDD_Capacity=250,GPU_Memory=8,Price=65000,Count=130},
            new Computer(){Code="2",Mark="GIGABYTE",CPU_Name="i9-12900K",CPU_Frequency=3000,RAM_Capacity=18,HDD_Capacity=300,GPU_Memory=18,Price=100000,Count=40},
            new Computer(){Code="2",Mark="Acer",CPU_Name="Ryzen5900x",CPU_Frequency=5900,RAM_Capacity=64,HDD_Capacity=1024,GPU_Memory=20,Price=250000,Count=5}
            };

            Console.Write("Введите название процессора ");
            string cpu_name = Convert.ToString(Console.ReadLine());
            List<Computer> computers1 = computers.Where(d => d.CPU_Name == cpu_name).ToList();
            WriteComp(computers1);

            Console.Write("Введите объём ОЗУ ");
            int ram_capacity = Convert.ToInt32(Console.ReadLine());
            List<Computer> computers2 = computers.Where(d => d.RAM_Capacity >= ram_capacity).ToList();
            WriteComp(computers2);

            Console.Write("Отсортированный список по увеличению стоимости\n");
            List<Computer> computers3 = computers.OrderBy(d => d.Price).ToList();
            WriteComp(computers3);

            IEnumerable<IGrouping<string, Computer>> computers4 = computers.GroupBy(d => d.CPU_Name).ToList();

            Console.WriteLine("Cписок сгруппированный по типу процессора\n");
            foreach (IGrouping<string, Computer> gr in computers4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer c in gr)
                {
                    Console.WriteLine($"\t{c.Code,3} {c.Mark,10} {c.CPU_Name,12} {c.CPU_Frequency,6} {c.RAM_Capacity,2} {c.HDD_Capacity,4} {c.GPU_Memory,2} {c.Price,8} {c.Count,3}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Cамый дорогой компьютер:");
            Computer epxComp = computers.OrderByDescending(d => d.Price).FirstOrDefault();
            WriteComp(epxComp);

            Console.WriteLine("Cамый дешевый компьютер:");
            Computer cheapCom = computers.OrderBy(d => d.Price).FirstOrDefault();
            WriteComp(cheapCom);


            Console.WriteLine("Есть ли хотя бы один компьютер в количестве не менее 30 штук?");
            Console.WriteLine(computers.Any(d => d.Count >= 30));

            Console.ReadKey();
        }

        //Методы
        public static void WriteComp(List<Computer> computers)
        {
            Console.WriteLine();
            foreach (Computer c in computers)
                Console.WriteLine($"{c.Code,3} {c.Mark,10} {c.CPU_Name,12} {c.CPU_Frequency,6} {c.RAM_Capacity,2} {c.HDD_Capacity,4} {c.GPU_Memory,2} {c.Price,8} {c.Count,3}");
            Console.WriteLine();
        }
        public static void WriteComp(Computer c)
        {
            Console.WriteLine($"{c.Code} {c.Mark} {c.CPU_Name} {c.CPU_Frequency} {c.RAM_Capacity} {c.HDD_Capacity} {c.GPU_Memory} {c.Price} {c.Count}\n");
        }
    }
}
