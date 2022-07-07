using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    class SpeedAndLocation
    {
        public static async Task Speed()
        {

            SpeedAndStuff[] getSpeed = await TrainApi.GetSpeed();

            SpeedRootobject[] stationNumber = await TrainApi.GetSpeedStationNumber();


            RootobjectCompositions[] theStations = await TrainApi.TheStations();

            Station[] Stationnames = await TrainApi.GetStations();



            //foreach (var asdlol in Stationnames)
            //{
            //    Console.WriteLine($"{asdlol.stationName}. {asdlol.stationShortCode}");
            //}

            var filtteriä = getSpeed.Where(train => train.speed > 0);
            var order = filtteriä.OrderByDescending(x => x.speed);

            var i = 1;

            foreach (var trying in order)
            {

                if (i <= 5)
                {
                    var testailua2 = theStations
                        .Where(x => x.trainNumber == trying.trainNumber);


                    foreach (var testingAgain in testailua2)
                    {
                        Console.WriteLine($"Lähtöasema: {testingAgain.journeySections[0].beginTimeTableRow.stationShortCode} {Stationnames[0].stationName}");
                        Console.WriteLine($"Pääteasema: {testingAgain.journeySections[0].endTimeTableRow.stationShortCode}");
                        Console.WriteLine($"Nopeus: {trying.speed} Km/h\n");

                    }
                }

                i += 1;
            }

            //foreach (var newTest in theStations)
            //{
            //    Console.WriteLine($"Start: {newTest.journeySections[0].beginTimeTableRow.stationShortCode}");
            //    Console.WriteLine($"End: {newTest.journeySections[0].endTimeTableRow.stationShortCode}");
            //}

            //foreach (var test in theStations)
            //{
            //    Console.WriteLine($"{test.operatorShortCode}");
            //}




            //var newFilter = getSpeed.Where(x => x.speed > 0);

            //foreach (var abc in newFilter)
            //{
            //    var asd = theStations.Where(x => x.trainNumber == abc.trainNumber);

            //    foreach (var qwe in asd)
            //    {
            //        Console.WriteLine($"{abc.trainNumber}. {qwe.journeySections[0].beginTimeTableRow.stationShortCode}. " +
            //                          $"{qwe.journeySections[0].endTimeTableRow.stationShortCode}. {abc.speed}");
            //    }
            //}







            Console.WriteLine("\npress any key to exit");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
