using System;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    public class Station
    {
        public bool passengerTraffic { get; set; }
        public string type { get; set; }
        public string stationName { get; set; }
        public string stationShortCode { get; set; }
        public int stationUICCode { get; set; }
        public string countryCode { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
    }

    //Junien myöhästely
    public class LiveTrains
    {
        public int trainNumber { get; set; }
        public string departureDate { get; set; }
        public int operatorUICCode { get; set; }
        public string operatorShortCode { get; set; }
        public string trainType { get; set; }
        public string trainCategory { get; set; }
        public string commuterLineID { get; set; }
        public bool runningCurrently { get; set; }
        public bool cancelled { get; set; }
        public long version { get; set; }
        public string timetableType { get; set; }
        public DateTime timetableAcceptanceDate { get; set; }
        public LiveTimetablerow[] timeTableRows { get; set; }
    }

    //Junien myöhästely
    public class LiveTimetablerow
    {
        public string stationShortCode { get; set; }
        public int stationUICCode { get; set; }
        public string countryCode { get; set; }
        public string type { get; set; }
        public bool trainStopping { get; set; }
        public bool commercialStop { get; set; }
        public string commercialTrack { get; set; }
        public bool cancelled { get; set; }
        public DateTime scheduledTime { get; set; }
        public DateTime actualTime { get; set; }
        public int differenceInMinutes { get; set; }
        public LiveCaus[] causes { get; set; }
        public LiveTrainready trainReady { get; set; }
        public DateTime liveEstimateTime { get; set; }
        public string estimateSource { get; set; }
    }

    //Junien myöhästely (turha)
    public class LiveTrainready
    {
        public string source { get; set; }
        public bool accepted { get; set; }
        public DateTime timestamp { get; set; }
    }

    //Junien myöhästely (turha)
    public class LiveCaus
    {
        public string categoryCode { get; set; }
        public string detailedCategoryCode { get; set; }
        public string thirdCategoryCode { get; set; }
        public int detailedCategoryCodeId { get; set; }
        public int categoryCodeId { get; set; }
        public int thirdCategoryCodeId { get; set; }
    }


}


