using System;
using System.Collections.Generic;
using System.Linq;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    //Jutta&Antti
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
                int? trainNum = train.trainNumber;
                if (trainNum != null)
                {
                    var helpervar = compositions.Where(comp => comp.trainNumber == trainNum && (comp.trainCategory == "Commuter" || comp.trainCategory == "Long-distance"));
                    if (helpervar.Any())
                    {
                        if (helpervar.First().journeySections.Any())
                        {
                            if (helpervar.First().journeySections.First().locomotives.Any())
                            {
                                if (helpervar.First().journeySections.First().locomotives.First().locomotiveType != null)
                                {
                                    string alllocoString = helpervar.First().journeySections.First().locomotives.First().locomotiveType;
                                    if (!String.IsNullOrWhiteSpace(alllocoString))
                                        allLocoList.Add(alllocoString);
                                }
                            }
                        }
                    }
                }
            }

            List<string> lateTypes = locoLate.Distinct().ToList();

            List<double> locoAmountLate = new List<double>();
            foreach (var locoType in lateTypes)
                locoAmountLate.Add(locoLate.Where(x => x == locoType).Count());
            

            List<double> locoAmountAll = new List<double>();
            foreach (var locoType in lateTypes)
                locoAmountAll.Add(allLocoList.Where(x => x == locoType).Count());

            List<double> locoPercentage = new List<double>();
            for (int i = 0; i < locoAmountLate.Count; i++)
                locoPercentage.Add(locoAmountLate[i] / (locoAmountAll[i] / 100));

            List<LocomotiveInfo> listOfLoco = new List<LocomotiveInfo>();
            for (int i = 0; i < lateTypes.Count; i++)
            {
                listOfLoco.Add(new LocomotiveInfo
                {
                    LocoType = lateTypes[i], AmountAll = locoAmountAll[i], AmountLate = locoAmountLate[i],
                    Percentage = locoPercentage[i]
                });
            }

            double largestPersentage = listOfLoco.Where(x => x.AmountAll > 2).Select(y => y.Percentage).Max();

            string largestLoco = listOfLoco.Where(x => x.AmountAll > 2 && x.Percentage == largestPersentage).Single().LocoType;

            Console.WriteLine($"\nUseimmin myöhästynyt veturityypi (jolla ajettiin vähintään 3 kertaa) oli: {largestLoco}\n{largestPersentage}% matkoista oli myöhässä tällä veturityypillä.");
        }

        public static List<string> LateLocomotive(IEnumerable<LiveTrains> lateTrains, CompositionsTrain[] compositions)
        {
            List<string> lateLocoList = new List<string>();
            
            foreach (var train in lateTrains)
            {

                int? trainNum = train.trainNumber;
                if (trainNum != null)
                {
                    var helpervar = compositions.Where(comp => comp.trainNumber == trainNum && (comp.trainCategory == "Commuter" || comp.trainCategory == "Long-distance"));
                    if (helpervar.Any())
                    {
                        if (helpervar.First().journeySections.Any())
                        {
                            if (helpervar.First().journeySections.First().locomotives.Any())
                            {
                                if (helpervar.First().journeySections.First().locomotives.First().locomotiveType != null)
                                {
                                    
                                    string latelocoString = helpervar.First().journeySections.First().locomotives.First().locomotiveType;
                                    if (!String.IsNullOrWhiteSpace(latelocoString))
                                        lateLocoList.Add(latelocoString);
                                }
                            }
                        }
                    }
                }
            }
            return lateLocoList;
        }
    }
    //Jutta&Antti
    public class LocomotiveInfo
    {
        public string LocoType { get; set; }
        public double AmountLate { get; set; }
        public double AmountAll { get; set; }
        public double Percentage { get; set; }
    }
}