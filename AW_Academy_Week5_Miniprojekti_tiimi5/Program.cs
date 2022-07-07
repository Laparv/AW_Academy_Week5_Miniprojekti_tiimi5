﻿using System;
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
                Train();
                Console.WriteLine("\nThe ultimate train app\n");
                Menu();

                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();


                switch (choice)
                {
                    case '1':
                        Console.Clear();

                        await GetScheduleInfo(); //Lasse

                        Console.WriteLine("\npress any key to exit");
                        Console.ReadKey();
                        Console.WriteLine();

                        break;
                    case '2':
                        Console.Clear();

                        Console.WriteLine("\npress any key to exit");
                        Console.ReadKey();
                        Console.WriteLine();
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

                        Console.WriteLine("Give date to look for delayed trains and locomotives (YYYY,MM,DD)");
                        string depDate = Convert.ToDateTime(Console.ReadLine()).ToString("yyyy-MM-dd");

                        LiveTrains[] LiveTrainsArray = await TrainApi.GetLiveTrains(depDate);
                        CompositionsTrain[] CompositionsArray = await TrainApi.GetLocomotiveData(depDate);

                        LateTrains.TrainsArrivedLate(LiveTrainsArray, CompositionsArray);

                        Console.WriteLine("\npress any key to exit");
                        Console.ReadKey();

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
│ 5  │ Junien/veturien myöhästely        │
├────┼───────────────────────────────────┤
│ 6  │ -                                 │
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

        //private static async Task GetStationInfo()
        //{
        //    //List<Station> stationList = await TrainApi.GetStations();

        //    if (stationList == null)
        //        Console.WriteLine("\n  Station not found :(");
        //    else
        //    {
        //        foreach (var station in stationList)
        //        {
        //            Console.WriteLine(station.stationName);
        //        }
        //    }
        //    //if (fruit == null)
        //    //    Console.WriteLine("\n  Fruit not found :(");
        //    //else
        //    //    PrintFruitData(fruit);
        //}

        // metodi seuraavien junien hakemiseen asemalta asemalle - Lasse
        private static async Task GetScheduleInfo()
        {
            Console.Write("\nGive departure station: ");
            string departureFrom = Console.ReadLine();
            Console.WriteLine("Where do you want to go?");
            string arriveTo = Console.ReadLine();
            string timeNow = DateTime.Now.ToString("yyyy-MM-dd'T'HH':'mm':'ss.fff'Z'");

            LiveTrains[] nextTrains = await TrainApi.CheckSoonTrains(departureFrom, arriveTo, timeNow);

            foreach (LiveTrains train in nextTrains)
            {
                Console.WriteLine(train.trainNumber);
            }
            
        }
    }


}
//asemien listaukseen koodi - Lasse
/* Station[] stationlist = await TrainApi.GetStations();

                        int i = 0;
                        foreach (Station station in stationlist)
                        {
                            i++;
                            Console.WriteLine($"{i}. {station.stationName}");
                        }*/