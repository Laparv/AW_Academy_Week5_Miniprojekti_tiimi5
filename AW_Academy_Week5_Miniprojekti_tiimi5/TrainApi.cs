using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using AW_Academy_Week5_Miniprojekti_tiimi5;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    public static class TrainApi
    {
        const string url = "https://rata.digitraffic.fi/api/v1/";

        public static async Task<Station[]> GetStations()
        {
            string urlParams = "metadata/stations";

            var response = await ApiHelper.RunAsync<Station[]>(url, urlParams);
            return response;
        }


        // Speed, MS
        public static async Task<SpeedAndStuff[]> GetSpeed()
        {
            string urlParams = "train-locations/latest";

            var response = await ApiHelper.RunAsync<SpeedAndStuff[]>(url, urlParams);
            return response;
        }

        public static async Task<SpeedRootobject[]> GetSpeedStationNumber()
        {
            string urlParams = "live-trains";

            var response = await ApiHelper.RunAsync<SpeedRootobject[]>(url, urlParams);
            return response;
        }

        public static async Task<Timetablerow[]> GetSpeedStationName()
        {
            string urlParams = "live-trains";

            var response = await ApiHelper.RunAsync<Timetablerow[]>(url, urlParams);
            return response;
        }

        
        public static async Task<RootobjectCompositions[]> TheStations()
        {

            DateTime tänään = DateTime.Now;

            string urlParams = "compositions/2022-07-07"/* + tänään.ToString("yyyy-mm-dd")*/;

            var response = await ApiHelper.RunAsync<RootobjectCompositions[]>(url, urlParams);
            return response;
        }
    }
}
