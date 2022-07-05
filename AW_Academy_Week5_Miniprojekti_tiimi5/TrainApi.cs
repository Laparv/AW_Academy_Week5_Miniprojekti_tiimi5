using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using APIHelpers;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    public static class TrainApi
    {
        const string url = "https://rata.digitraffic.fi/";


        public static async Task<List<Station>> GetSingleFruit()
        {
            string urlParams = "api/v1/metadata/stations";
            
            var response = await ApiHelper.RunAsync<List<Station>>(url, urlParams);

            return response;
        }
    }
}
