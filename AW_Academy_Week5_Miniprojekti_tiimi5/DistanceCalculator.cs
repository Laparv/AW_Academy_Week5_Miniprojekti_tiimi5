using System;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    public class DistanceCalculator
    {
        public static double LatLonPointsDistance(double lat1, double lon1, double lat2, double lon2) //returns distance in kilometers
        {
            double R = 6371e3f;
            double fii1 = lat1 * Math.PI / 180;
            double fii2 = lat2 * Math.PI / 180;
            double deltaFii = (lat2 - lat1) * Math.PI / 180;
            double deltaAlpha = (lon2 - lon1) * Math.PI / 180;

            double a = Math.Sin(deltaFii / 2) * Math.Sin(deltaFii) + Math.Cos(fii1) * Math.Cos(fii2) *
                Math.Sin(deltaAlpha / 2) * Math.Sin(deltaAlpha / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c / 1000;
        }
    }
}