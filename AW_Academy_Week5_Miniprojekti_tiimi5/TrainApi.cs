using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIHelpers;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    public static class TrainApi
    {
        const string url = "https://rata.digitraffic.fi/api/";


        public static async Task<List<Station>> GetStations()
        {
            string urlParams = "v1/metadata/stations";
            
            List<Station> response = await ApiHelpers.RunAsync<List<Station>>(url, urlParams);

            return response;
        }
    }
}
