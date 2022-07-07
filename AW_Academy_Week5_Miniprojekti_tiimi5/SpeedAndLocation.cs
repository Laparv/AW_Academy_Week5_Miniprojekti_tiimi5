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

            Timetablerow[] stationName = await TrainApi.GetSpeedStationName();

            RootobjectCompositions[] theStations = await TrainApi.TheStations();




            var filtteriä = getSpeed.Where(train => train.speed > 0);
            //var order = filtteriä.OrderByDescending(x => x.speed);

            foreach (var trying in filtteriä)
            {
                var testailua = stationNumber.Where(x => x.trainNumber == trying.trainNumber);

                //var järjestys = filtteriä.OrderBy(y => y.speed);



                foreach (var testingAgain in testailua)
                {
                    Console.WriteLine($"Lähtöasema: {theStations[0].journeySections[0].beginTimeTableRow.stationShortCode}");
                    Console.WriteLine($"Pääteasema: {theStations[0].journeySections[0].endTimeTableRow.stationShortCode}");
                    Console.WriteLine($"Nopeus: {trying.speed} Km/h\n");


                    //Console.WriteLine($"{trying.trainNumber}. {testingAgain.timeTableRows[0].stationShortCode}. {trying.speed}");
                }
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
