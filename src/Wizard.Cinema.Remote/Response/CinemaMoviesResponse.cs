namespace Wizard.Cinema.Remote.Response
{
    /// <summary>
    /// 影院场次
    /// </summary>
    public class CinemaMoviesResponse
    {
        public string cinemaId { get; set; }
        public Showdata showData { get; set; }
        public int movieIndex { get; set; }
        public int channelId { get; set; }

        public class Showdata
        {
            public int cinemaId { get; set; }
            public string cinemaName { get; set; }

            public Movie[] movies { get; set; }
            public int poiId { get; set; }
        }

        public class Movie
        {
            public Show[] shows { get; set; }
        }

        public class Show
        {
            public Plist[] plist { get; set; }
        }

        public class Plist
        {
            public string seqNo { get; set; }
        }
    }
}