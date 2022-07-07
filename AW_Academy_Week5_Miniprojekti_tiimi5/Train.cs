using System;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    public class StationList
    {
        public Station[] Property1 { get; set; }
    }

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




    // Speed     |
    //           |
    // Miikka  \  /
    //   S      \/
    public class SpeedAndStuff
    {
        public int trainNumber { get; set; }
        public int speed { get; set; }
    }

    public class RootobjectCompositions
    {
        public int trainNumber { get; set; }
        public Journeysection[] journeySections { get; set; }
    }

    public class Journeysection
    {
        public Begintimetablerow beginTimeTableRow { get; set; }
        public Endtimetablerow endTimeTableRow { get; set; }
    }

    public class Begintimetablerow
    {
        public string stationShortCode { get; set; }
    }

    public class Endtimetablerow
    {
        public string stationShortCode { get; set; }
    }
    // Miikka    /\
    //   S      /  \
    //           |
    // Speed     |    

}



