using System;

namespace AW_Academy_Week5_Miniprojekti_tiimi5
{
    //public class StationList
    //{
    //    public Station[] Property1 { get; set; }
    //}

    public class Station
    {
        public string stationName { get; set; }
        public string stationShortCode { get; set; }
    }

    //Jutta&Antti
    //Junien myöhästely
    public class LiveTrains
    {
        public int trainNumber { get; set; }
        public string trainType { get; set; }
        public string trainCategory { get; set; }
        public string commuterLineID { get; set; }
        public bool runningCurrently { get; set; }
        public bool cancelled { get; set; }
        public LiveTimetablerow[] timeTableRows { get; set; }
    }
    //Jutta&Antti
    //Junien myöhästely
    public class LiveTimetablerow
    {
        public string stationShortCode { get; set; }
        public string type { get; set; }
        public DateTime scheduledTime { get; set; }
        public int differenceInMinutes { get; set; }
    }

    //Jutta&Antti
    public class CompositionsTrain
    {
        public int trainNumber { get; set; }
        public string trainCategory { get; set; }
        public CompositionsJourneysection[] journeySections { get; set; }
    }
    //Jutta&Antti
    public class CompositionsJourneysection
    {
        public CompositionsLocomotive[] locomotives { get; set; }
    }
    //Jutta&Antti
    public class CompositionsLocomotive
    {
        public string locomotiveType { get; set; }
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




