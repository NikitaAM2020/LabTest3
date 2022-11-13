using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTTest.Model
{
    public class BookingDates
    {
        public string checkin { get; set; }
        public string checkout { get; set; }
    }

    public class PostsModel

    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public BookingDates bookingdates { get; set; }
        public string additionalneeds { get; set; }
    }
    public class PostsModels
    {
        public string id { get; set; }
        public string title { get; set; }
        public string original_title { get; set; }
        public string original_title_romanised { get; set; }
        public string image { get; set; }
        public string movie_banner { get; set; }
        public string description { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public string running_time { get; set; }
        public string rt_score { get; set; }
        public List<string> people { get; set; }
        public List<string> species { get; set; }
        public List<string> locations { get; set; }
        public List<string> vehicles { get; set; }
        public string url { get; set; }

    }
}
