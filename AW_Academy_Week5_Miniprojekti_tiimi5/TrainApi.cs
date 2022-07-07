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
        
        //checks next 5 trains
        public static async Task<LiveTrains[]> CheckSoonTrains(string departure_station, string arrival_station, string startDate)
        {
            string urlParams = $"live-trains/station/{departure_station}/{arrival_station}?include_nonstopping=false&limit=5&startDate={startDate}";

            var response = await ApiHelper.RunAsync<LiveTrains[]>(url, urlParams);
            return response;
        }

        //Jutta&Antti
        public static async Task<LiveTrains[]> GetLiveTrains(string depDate)
        {
            string urlParams = "trains/" + depDate;

            var response = await ApiHelper.RunAsync<LiveTrains[]>(url, urlParams);
            return response;
        }

        //Jutta&Antti
        public static async Task<CompositionsTrain[]> GetLocomotiveData(string depDate)
        {
            string urlParams = "compositions/" + depDate;

            var response = await ApiHelper.RunAsync<CompositionsTrain[]>(url, urlParams);
            return response;
        }

    }

}
