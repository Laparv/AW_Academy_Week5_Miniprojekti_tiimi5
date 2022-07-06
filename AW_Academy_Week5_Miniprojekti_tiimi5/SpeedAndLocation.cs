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




            var filtteriä = getSpeed.Where(train => train.speed > 0);

            foreach (var perkele in filtteriä)
            {
                Console.WriteLine($"{perkele.trainNumber}. {perkele.speed}");
            }

            foreach (var jaa in stationName)
            {
                Console.WriteLine($"{jaa.stationShortCode}");
            }

            foreach (var juu in stationNumber)
            {
                Console.WriteLine($"{juu.timeTableRows}");
            }




            





            //Console.Clear();


            //List<string> testList = new List<string>();

            //foreach (SpeedAndStuff speed in speedlist)
            //{
            //    testList.Add("Train number: " + speed.trainNumber.ToString() + " Speed: " + speed.speed);

            //    //Console.WriteLine($"{speed.trainNumber}. {speed.speed}");
            //}

            //SpeedRootobject[] speedLocList = await TrainApi.GetSpeedStationNumber();

            //foreach (SpeedRootobject loc in speedLocList)
            //{
            //    testList.Add(loc.trainType);
            //    //Console.WriteLine($"{loc.timeTableRows}");
            //}

            //foreach (var test in testList)
            //{
            //    Console.WriteLine(test);
            //}


            //Timetablerow[] testing = await TrainApi.GetSpeedStationName();

            //foreach (Timetablerow testi in testing)
            //{
            //    Console.WriteLine($" Station name: {testi.stationShortCode}");
            //}



            Console.WriteLine("\npress any key to exit");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
