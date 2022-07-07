using System;
using System.Collections.Generic;
using System.Linq;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    public class LateTrains
    {
        public static IEnumerable<LiveTrains> TrainsArrivedLate (LiveTrains[] liveArray, CompositionsTrain[] compositions) //valikoidaan ne matkustajajunat jotka perillä, antaa niiden määrän ja tulostaa 24h sisällä myöhästyneiden prosentin
        {   
            var filter1 = liveArray.Where(train => train.runningCurrently == false && train.cancelled == false); 
            var filter2 = filter1.Where(train => train.trainCategory == "Long-distance" || train.trainCategory == "Commuter");
            var lateTrains = filter2.Where(juna => juna.timeTableRows.Last().differenceInMinutes > 3);
            int lateAmount = lateTrains.Count();
            int allArrivedTrains = filter2.Count();
            int percentageLate = lateAmount / (allArrivedTrains / 100);
            Console.WriteLine("Kaikki perille päässeet matkustajajunat 24h ajalta: " + allArrivedTrains);
            Console.WriteLine("Joista yli 3 min myöhässä oli " + percentageLate + "%");
            var lateLoco = LateLocomotive(lateTrains, compositions);
            LocomotiveLatePercent(filter2, lateLoco, compositions);

            return lateTrains;
        }

        public static void LocomotiveLatePercent(IEnumerable<LiveTrains> filter2, List<string> locoLate, CompositionsTrain[] compositions)
        {
            List<string> allLocoList = new List<string>();

            foreach (var train in filter2)
            {
                int trainNum = train.trainNumber;
                
                string allLocoString = compositions.Where(comp => comp.trainNumber == trainNum).First().journeySections[0].locomotives[0].locomotiveType;
                if (!String.IsNullOrWhiteSpace(allLocoString))
                    allLocoList.Add(allLocoString);
            }

            List<string> lateTypes = locoLate.Distinct().ToList();

            List<int> locoAmountLate = new List<int>();
            foreach (var locoType in lateTypes)
                locoAmountLate.Add(locoLate.Where(x => x == locoType).Count());

            List<int> locoAmountAll = new List<int>();
            foreach (var locoType in lateTypes)
                locoAmountAll.Add(allLocoList.Where(x => x == locoType).Count());

            List<int> locoPercentage = new List<int>();
            for (int i = 0; i < locoAmountLate.Count; i++)
                locoPercentage.Add(locoAmountLate[i] / (locoAmountAll[i] / 100)); // !pyöristyy nollaan pitää vaihtaa doubleksi!

            var wantedIndex = locoPercentage.IndexOf(locoPercentage.Max());

            Console.WriteLine($"Most late trips were done with locomotivetype: {lateTypes[wantedIndex]}, {locoPercentage.Max()}% of trips were late with this locomotive.");
        }

        public static List<string> LateLocomotive(IEnumerable<LiveTrains> lateTrains, CompositionsTrain[] compositions)
        {
            List<string> lateLocoList = new List<string>();
            
            foreach (var train in lateTrains)
            {
                int trainNum = train.trainNumber;

                string locoString = compositions.Where(comp => comp.trainNumber == trainNum).First().journeySections[0].locomotives[0].locomotiveType;
                if (!String.IsNullOrWhiteSpace(locoString))
                    lateLocoList.Add(locoString);
            }

            return lateLocoList;

            //foreach (var locoType in locoInfoList)
            //    Console.WriteLine(locoType);



            // jotta voidaan verrata mikä veturityyppi myöhästeli suhteellisesti eniten pitää hakea kuinka monta lähtöä kyseisellä veturilla tehtiin nyt tehdyn metodin lisäksi
            // kun verrataan montako lähtöä veturilla tehtiin ja montako verutin lähtöä myöhästyi saadaan jokaiselle veturille myöhästymisprosentti


            //var test = compositions.Join(lateTrains, comp => comp, train => train,
            //    (comp, train) => new { TrainNum = train.trainNumber, LocoType = comp.journeySections[0].locomotives[0].locomotiveType });
        }
    }
}