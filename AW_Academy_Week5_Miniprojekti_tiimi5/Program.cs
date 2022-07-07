using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AW_Academy_Week5_Miniprojekti_tiimi5;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            char choice = '0';

            while (choice != '8')
            {
                Console.Clear();
                Otsikko();
                Train();
                Menu();

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();


                switch (choice)
                {
                    case '1':
                        Console.Clear();
                        

                        Station[] stationlist = await TrainApi.GetStations();

                        int i = 0;
                        foreach (Station station in stationlist)
                        {
                            i++;
                            Console.WriteLine($"{i}. {station.stationName}");
                        }


                        Console.WriteLine("\npress any key to exit");
                        Console.ReadKey();
                        Console.WriteLine();

                        break;
                    case '2':
                        Console.Clear();
                        Console.ReadLine();

                        break;
                    case '3':
                        Console.Clear();
                        SpeedAndLocation.Speed();
                        Console.ReadLine();

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
                    default:    // Virheviesti
                        Console.Clear();
                        Console.WriteLine("Virhe. Paina jotain muuta näppäintä");
                        Console.ReadKey();
                        break;

                }
            }



        }

        static void Menu()
        {
            Console.WriteLine(@"    ┌────┬───────────────────────────────────┐
    │ 1  │ Aikatauluhaku aseman perusteella  │
    ├────┼───────────────────────────────────┤
    │ 2  │                                   │
    ├────┼───────────────────────────────────┤
    │ 3  │ Viisi nopeinta junaa juuri nyt    │
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

        // MS
        static void Train()
        {
            Console.WriteLine(@"                    ____
                    |DD|____T_
                    |_ |_____|<
                    @-@-@-oo\");
        }


        // MS
        static void Otsikko()
        {
            Console.WriteLine(@"             __                              
            / /_  ______  ____ _             
       __  / / / / / __ \/ __ `/  ______     
      / /_/ / /_/ / / / / /_/ /  /_____/     
      \____/\__,_/_/ /_/\__,_/ ____          
        / ___/____ _   _____  / / /_  _______
        \__ \/ __ \ | / / _ \/ / / / / / ___/
       ___/ / /_/ / |/ /  __/ / / /_/ (__  ) 
      /____/\____/|___/\___/_/_/\__,_/____/  
                                       ");
        }
    }
}
