namespace Wizard.Cinema.Remote.Spider.Response
{
    public class CinemaResponse
    {
        public Cinema[] cinemas { get; set; }

        public class Cinema
        {
            public int id { get; set; }
            public int mark { get; set; }
            public string nm { get; set; }
            public string sellPrice { get; set; }
            public string addr { get; set; }
            public string distance { get; set; }
        }
    }
}