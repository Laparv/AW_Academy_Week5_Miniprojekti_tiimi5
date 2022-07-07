using System;
using System.Collections.Generic;
using System.Linq;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    public class LateTrains
    {
        async public static void TrainsArrivedLate (LiveTrains[] liveArray) //valikoidaan ne matkustajajunat jotka perillä, antaa niiden määrän ja tulostaa 24h sisällä myöhästyneiden prosentin
        {   
            var filter1 = liveArray.Where(train => train.runningCurrently == false && train.cancelled == false); 
            var filter2 = filter1.Where(train => train.trainCategory == "Long-distance" || train.trainCategory == "Commuter");
            int lateAmount = filter2.Where(juna => juna.timeTableRows.Last().differenceInMinutes > 0).Count();
            int allArrivedTrains = filter2.Count();
            int percentageLate = lateAmount / (allArrivedTrains / 100);
            Console.WriteLine("Kaikki perille päässeet matkustajajunat 24h ajalta: " + allArrivedTrains);
            Console.WriteLine("Joista myöhässä oli " + percentageLate + "%");
        }

        
    }
}