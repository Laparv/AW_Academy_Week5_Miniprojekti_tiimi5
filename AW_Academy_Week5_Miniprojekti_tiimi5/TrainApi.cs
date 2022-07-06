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
            string urlParams = "v1/metadata/stations";
            
            var response = await ApiHelper.RunAsync<List<Station>>(url, urlParams);

            var response = await ApiHelper.RunAsync<Station[]>(url, urlParams);
            return response;
        }


    }
}
