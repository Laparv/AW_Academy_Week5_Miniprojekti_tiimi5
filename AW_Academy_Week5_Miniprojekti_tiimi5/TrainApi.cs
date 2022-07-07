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
        public static async Task<LiveTrains[]> CheckForTrains(string departure_station, string arrival_station, string startDate)
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

        // Speed     |
        //           |
        // Miikka  \  /
        //   S      \/
        public static async Task<SpeedAndStuff[]> GetSpeed()
        {
            // Valitaan https://rata.digitraffic.fi/api/v1/train-locations/latest josta saa napattua junan numeron ja nopeuden
            string urlParams = "train-locations/latest";

            var response = await ApiHelper.RunAsync<SpeedAndStuff[]>(url, urlParams);
            return response;
        }

        public static async Task<RootobjectCompositions[]> TheStations()
        {

            DateTime tänään = DateTime.Now;

            // Valitaan https://rata.digitraffic.fi/api/v1/compositions/ + Tämä päivä, esimerkiksi 2022-07-07.
            // Täältä saadaan lähtö- ja pääteasemat sekä junan numero

            string urlParams = "compositions/" + tänään.ToString("yyyy-MM-dd");
            var response = await ApiHelper.RunAsync<RootobjectCompositions[]>(url, urlParams);
            return response;
        }

        // Miikka    /\
        //   S      /  \
        //           |
        // Speed     |    

    }

}
