using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AW_Academy_Week5_Miniprojekti_tiimi5;
using System.Linq;

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

                        await GetNextTrainsInfo(); //Lasse

                        Console.WriteLine("\npress any key to exit");
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.ReadLine();
                        Console.WriteLine("\npress any key to exit");
                        Console.ReadKey();
                      
                        Console.WriteLine();
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
                        LiveTrains[] LiveTrainsArray = await TrainApi.GetLiveTrains();
                        LateTrains.TrainsArrivedLate(LiveTrainsArray);
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


        // metodi junien aikataulujen hakemiseen asemalta asemalle - Lasse
        private static async Task GetNextTrainsInfo()
        {
            Console.Write("Mistä lähdet?: ");
            string departureFrom = await GetStationCode();
            Console.Write("Mihin menet?: ");
            string arriveTo = await GetStationCode();

            string departureStationName = await GetStationName(departureFrom);
            string arriveStationName = await GetStationName(arriveTo);


            Console.WriteLine("1) Lähde nyt 2) Anna lähtöaika");
            char choice = Console.ReadKey().KeyChar;
            switch (choice)
            {
                case '1':
                    Console.Clear();
                    string timeNow = DateTime.Now.AddHours(-3).ToString("yyyy-MM-dd'T'HH':'mm':'ss.fff'Z'"); //antaa tämän hetken hakuehtoihin 

                    LiveTrains[] nextTrains = await TrainApi.CheckForTrains(departureFrom, arriveTo, timeNow);

                    Console.WriteLine("Seuraavat junat:");
                    foreach (LiveTrains train in nextTrains)
                    {
                        var departureTime = train.timeTableRows
                            .Where(t => t.stationShortCode == departureFrom && t.type == "DEPARTURE")
                            .Select(s => s.scheduledTime.AddHours(3)).FirstOrDefault();

                        var arrivalTime = train.timeTableRows
                            .Where(t => t.stationShortCode == arriveTo && t.type == "ARRIVAL")
                            .Select(s => s.scheduledTime.AddHours(3)).FirstOrDefault();

                        if (train.trainCategory == "Commuter")
                        {
                            Console.WriteLine($"{train.commuterLineID}-juna asemalta {departureStationName.Replace("asema","")}" +
                                $"lähtee klo {departureTime.ToShortTimeString()} ja saapuu asemalle {arriveStationName.Replace("asema","")}" +
                                $"klo {arrivalTime.ToShortTimeString()}");
                        }
                        else
                        {
                            Console.WriteLine($"{train.trainType + train.trainNumber} asemalta {departureStationName.Replace("asema","")}" +
                                $"lähtee klo {departureTime.ToShortTimeString()} ja saapuu asemalle {arriveStationName.Replace("asema", "")}" +
                                $"klo {arrivalTime.ToShortTimeString()}");
                        }
                    }
                    Console.ReadLine();
                    break;
                case '2':
                    Console.Clear();
                    //kysyy käyttäjältä päivämäärän ja kellonajan
                    while (true)
                    {
                        Console.WriteLine("Minä päivänä lähdet? (d/m/yyyy): ");
                        var departureDate = Convert.ToDateTime(Console.ReadLine()).ToString("yyyy-MM-dd'T'");
                        Console.WriteLine("Mihin aikaan?(hh:mm):");
                        string departureHourAndMinute = Convert.ToDateTime(Console.ReadLine()).AddHours(-3).ToString("HH':'mm':'ss.fff'Z'");
                        string timeFuture = departureDate + departureHourAndMinute;
                        LiveTrains[] futureTrains = await TrainApi.CheckForTrains(departureFrom, arriveTo, timeFuture);
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Juna päivämääränä ja kellonaikana:");
                            foreach (LiveTrains train in futureTrains)
                            {
                                var futureDepartureTime = train.timeTableRows
                                    .Where(t => t.stationShortCode == departureFrom && t.type == "DEPARTURE")
                                    .Select(s => s.scheduledTime.AddHours(3)).FirstOrDefault();
                                var futureArrivalTime = train.timeTableRows
                                    .Where(t => t.stationShortCode == arriveTo && t.type == "ARRIVAL")
                                    .Select(s => s.scheduledTime.AddHours(3)).FirstOrDefault();

                            if (train.trainCategory == "Commuter")
                            {
                                    Console.WriteLine($"{train.commuterLineID}-juna asemalta {departureStationName.Replace("asema", "")}" +
                                        $"lähtee {futureDepartureTime.ToShortDateString()} klo {futureDepartureTime.ToShortTimeString()}" +
                                        $" ja saapuu asemalle {arriveStationName.Replace("asema", "")}klo {futureArrivalTime.ToShortTimeString()}");
                            }
                            else
                            {
                                Console.WriteLine($"{train.trainType + train.trainNumber} asemalta {departureStationName.Replace("asema", "")}" +
                                    $"lähtee {futureDepartureTime.ToShortDateString()} klo {futureDepartureTime.ToShortTimeString()} " +
                                    $"ja saapuu asemalle {arriveStationName.Replace("asema", "")}klo {futureArrivalTime.ToShortTimeString()}");
                            }

                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Väärä syöte. Yritäthän uudelleen.");
                            continue;
                    }
                        Console.ReadLine();
                        break;
                    }
                    break;
                default: break;
            }
            
            
        }

        //Hakee aseman koodin käyttäjän inputin perusteella - Lasse
        private static async Task<string> GetStationCode()
        {
            while (true)
            {

                string userInput = UpperCaseFirstLetter(Console.ReadLine());

                Station[] stationList = await TrainApi.GetStations();
                var stationCode = stationList.Where(station => station.stationName.Replace("asema","").Contains(userInput)).FirstOrDefault();

                if (stationCode == null)
                {
                    Console.WriteLine("Emme löytäneet asemaa näillä tiedoilla. Yritä uudelleen.");
                    continue;
                }
                return stationCode.stationShortCode;
            }
            
        }

        //Hakee aseman nimen koodin perusteella - Lasse
        private static async Task<string> GetStationName(string stationCode)
        {
            Station[] stationList = await TrainApi.GetStations();
            var stationName = stationList.Where(station => station.stationShortCode.Equals(stationCode)).FirstOrDefault();
            return stationName.stationName;
        }
       //Muuttaa käyttäjän syötteen oikeaan muotoon, jotta voidaan hakea asemakoodia
        private static string UpperCaseFirstLetter(string input)
        {
            char[] array = input.ToLower().ToCharArray();
            array[0] = char.ToUpper(array[0]);
            string fixedString = new string(array);
            return fixedString;
        }

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

//asemien listaukseen koodi - Lasse
/* Station[] stationlist = await TrainApi.GetStations();

                        int i = 0;
                        foreach (Station station in stationlist)
                        {
                            i++;
                            Console.WriteLine($"{i}. {station.stationName}");
                        }*/
