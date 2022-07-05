using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AW_Academy_Week5_Miniprojekti_tiimi5;

namespace AzureFullStackDev_Week5__Miniprojekti
{
    class Program
    {
        static void Main(string[] args)
        {
            char choice = '0';

            while (choice != '8')
            {
                Console.Clear();
                Train();
                Console.WriteLine("\nThe ultimate train app\n");
                Menu();

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();


                switch (choice)
                {
                    case '1':
                        Console.Clear();
                        GetStationInfo().GetAwaiter().GetResult();

                        

                        //Console.WriteLine(TrainApi.GetSingleFruit().ToString());
                        //TrainApi.GetSingleFruit().ToString();
                        Console.WriteLine("+++++++++++++++++++++++");
                        Console.ReadLine();

                        Console.WriteLine();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine();
                        break;
                    case '4':
                        Console.Clear();
                        Console.WriteLine();
                        break;
                    case '5':
                        Console.Clear();
                        Console.WriteLine();
                        break;
                    case '6':
                        Console.Clear();
                        Console.WriteLine();
                        break;
                    case '7':
                        Console.Clear();
                        Console.WriteLine();
                        break;
                    case '8':
                        Console.Clear();
                        break;
                    default:    // Error message
                        Console.Clear();
                        Console.WriteLine("Error. Press any key to choose another action.");
                        Console.ReadKey();
                        break;

                }
            }



        }

        static void Menu()
        {
            Console.WriteLine(@"┌────┬───────────────────────────────────┐
│ 1  │ Aikatauluhaku aseman perusteella  │
├────┼───────────────────────────────────┤
│ 2  │ Print Ids And Titles              │
├────┼───────────────────────────────────┤
│ 3  │ Ratatyötilanne tietyllä välillä   │
├────┼───────────────────────────────────┤
│ 4  │ Maksiminopeus tietyllä välillä    │
├────┼───────────────────────────────────┤
│ 5  │ Junien myöhästymisprosentti       │
├────┼───────────────────────────────────┤
│ 6  │ Myöhästeleekö veturityyppi        │
├────┼───────────────────────────────────┤
│ 7  │ Jotain muuta?                     │
├────┼───────────────────────────────────┤
│ 8  │ Exit                              │
└────┴───────────────────────────────────┘
");
        }

        static void Train()
        {
            Console.WriteLine(@"____
|DD|____T_
|_ |_____|<
  @-@-@-oo\");
        }

        private static async Task GetStationInfo()
        {
            List<Station> stationList = await TrainApi.GetStations();

            if (stationList == null)
                Console.WriteLine("\n  Station not found :(");
            else
            {
                foreach (var station in stationList)
                {
                    Console.WriteLine(station.stationName);
                }
            }


            //if (fruit == null)
            //    Console.WriteLine("\n  Fruit not found :(");
            //else
            //    PrintFruitData(fruit);
        }
    }


}
