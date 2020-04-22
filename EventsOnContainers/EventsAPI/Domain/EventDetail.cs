using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAPI.Domain
{
    public class EventDetail
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string EventName { get; set; }
        public string Venue { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public int Occupancy { get; set;}
        public string Age { get; set; }
        public int EventTypeID { get; set; } // foregin key, is primary key in eventtype class
        public string PictureUrl { get; set;  }
        public virtual EventType EventType { get; set; }  // navigational propety, to relate to the other class

    }
}
