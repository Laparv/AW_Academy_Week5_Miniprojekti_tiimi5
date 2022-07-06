﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    public class LateTrains
    {
        public static int TrainsArrivedLate(List<LiveTrains> liveList)
        {
            var test = liveList.Where(train => train.runningCurrently == false && train.cancelled == false);
            var test2 = test.Where(train => train.trainCategory == "Long-distance" || train.trainCategory == "Commuter");
            int lateAmount = test2.Where(juna => juna.timeTableRows.Last().differenceInMinutes > 0).Count();
            int allArrivedTrains = liveList.Where(train => train.runningCurrently == false).Count();
            int percentageLate = lateAmount / (allArrivedTrains / 100);
            return percentageLate;
        }
    }
}