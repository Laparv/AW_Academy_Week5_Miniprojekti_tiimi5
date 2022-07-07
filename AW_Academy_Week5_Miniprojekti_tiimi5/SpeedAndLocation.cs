using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    class SpeedAndLocation
    {

        // Lassen koodi
        private static async Task<string> GetStationName(string stationCode)
        {
            Station[] stationList = await TrainApi.GetStations();
            var stationName = stationList.Where(station => station.stationShortCode.Equals(stationCode)).FirstOrDefault();
            return stationName.stationName;

        }

        // Miikka S
        public static async Task Speed()
        {

            SpeedAndStuff[] getSpeed = await TrainApi.GetSpeed();
            RootobjectCompositions[] theStations = await TrainApi.TheStations();



            // Valitaan junat joiden nopeus on enemmän kuin 0 km/h
            var filttering = getSpeed.Where(train => train.speed > 0);

            // Järjestetään junat nopeuden mukaan laskevasti
            var order = filttering.OrderByDescending(x => x.speed);

            // Kirjoitetaan otsikko
            Console.WriteLine("Viisi nopeinta junaa tällä hetkellä:\n");


            // Asetetaan i:lle arvo 1
            var i = 1;


            foreach (var speed in order)
            {
                // Jatketaan niin kauan kuin i on alle tai yhtäsuuri kuin 5
                if (i <= 5)
                {

                    // Valitaan junat joissa Compositionin ja SpeenAndStuffin junanumerot täsmää
                    var compositionsEnumerable = theStations
                        .Where(x => x.trainNumber == speed.trainNumber);


                    foreach (var choice in compositionsEnumerable)
                    {
                        // Muutetaan asemien lyhennykset aseman koko nimeksi
                        string departure =
                            await GetStationName(choice.journeySections[0].beginTimeTableRow.stationShortCode);
                        string arrival =
                            await GetStationName(choice.journeySections[0].endTimeTableRow.stationShortCode);

                        // Tulostetaan konsoliin lähtöasema, pääteasema sekä junan tämän hetkinen nopeus
                        Console.WriteLine($"Lähtöasema: " + departure);
                        Console.WriteLine($"Pääteasema: " + arrival);
                        Console.WriteLine($"Nopeus nyt: {speed.speed} Km/h\n");
                    }
                }

                // Lisätään i:hin 1
                i += 1;
            }
            
        }
    }
}
