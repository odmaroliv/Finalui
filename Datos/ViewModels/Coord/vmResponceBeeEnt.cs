using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ViewModels.Coord
{
   
        public class vmResponceBeeEnt
        {
            public string status { get; set; }
            public Dispatch response { get; set; }
        }

        public class Dispatch
        {
            public int id { get; set; }
            public int dispatch_id { get; set; }
            public string identifier { get; set; }
            public string contact_name { get; set; }
            public string contact_address { get; set; }
            public string contact_phone { get; set; }
            public string contact_id { get; set; }
            public string contact_email { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public int route_id { get; set; }
            public string status { get; set; }
            public int status_id { get; set; }
            public string substatus { get; set; }
            public string substatus_code { get; set; }
            public List<Tag> tags { get; set; }
            public bool? is_trunk { get; set; }
            public bool? is_pickup { get; set; }
            public bool? delivered_in_client { get; set; }
            public string arrived_at { get; set; }
            public string estimated_at { get; set; }
            public object min_delivery_time { get; set; }
            public object max_delivery_time { get; set; }
            public string beecode { get; set; }
            public bool locked { get; set; }
            public int end_type { get; set; }
            public int number_of_retries { get; set; }
            public List<Item> items { get; set; }
            public List<EvaluationAnswer> evaluation_answers { get; set; }
            public Place place { get; set; }
            public Destination destination { get; set; }
        }

        public class Tag
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class Item
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int quantity { get; set; }
            public int original_quantity { get; set; }
            public int delivered_quantity { get; set; }
            public string code { get; set; }
            public List<object> extras { get; set; }
        }

        public class EvaluationAnswer
        {
            public AnswerId _id { get; set; }
            public string cast { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public string value { get; set; }
            public bool web { get; set; }
        }

        public class AnswerId
        {
            public string oid { get; set; }
        }

        public class Place
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Destination
        {
            public int id { get; set; }
            public string name { get; set; }
        }

    }
