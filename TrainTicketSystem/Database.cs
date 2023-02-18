using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SQLite;

namespace TrainTicketSystem
{
    public class DatabaseHandler
    {
        private readonly SQLiteConnection _connection;
        public DatabaseHandler() {
            if (!System.IO.File.Exists(@"database.db3"))
            {
                _connection = new SQLiteConnection(@"database.db3");
                _connection.CreateTable<Route>();
                _connection.CreateTable<Station>();
                _connection.CreateTable<Tickets>();
                _connection.CreateTable<Seats>();
                List<Route> routes = new List<Route>();
                routes.Add(new Route { firstStation = "Ajka", lastStation = "Budapest", type = "normál", firstClassPrice = 1000, secondClassPrice = 1500, stopsNumber = 6 });
                routes.Add(new Route { firstStation = "Ajka", lastStation = "Budapest", type = "gyors", firstClassPrice = 2000, secondClassPrice = 2500, stopsNumber = 3 });
                routes.Add(new Route { firstStation = "Ajka", lastStation = "Szombathely", type = "normál", firstClassPrice = 1000, secondClassPrice = 1500, stopsNumber = 6 });
                routes.Add(new Route { firstStation = "Ajka", lastStation = "Szombathely", type = "gyors", firstClassPrice = 2000, secondClassPrice = 2500, stopsNumber = 3 });
                for (int i = 0; i < routes.Count; i++)
                {
                    _connection.Insert(routes[i]);
                }
                List<Station> stations = new List<Station>();
                //route1
                //stations.Add(new Station { id_route = 1, stationName = "Ajka", stopNumber = 1 });
                stations.Add(new Station { id_route = 1, stationName = "Várpalota", stopNumber = 2 });
                stations.Add(new Station { id_route = 1, stationName = "Székesfehérvár", stopNumber = 3 });
                stations.Add(new Station { id_route = 1, stationName = "Velence", stopNumber = 4 });
                stations.Add(new Station { id_route = 1, stationName = "Érd", stopNumber = 5 });
                //stations.Add(new Station { id_route = 1, stationName = "Budapest", stopNumber = 6 });

                //route2
                //stations.Add(new Station { id_route = 2, stationName = "Ajka", stopNumber = 1 });
                stations.Add(new Station { id_route = 2, stationName = "Székesfehérvár", stopNumber = 2 });
                //stations.Add(new Station { id_route = 2, stationName = "Budapest", stopNumber = 3 });

                //route3
                //stations.Add(new Station { id_route = 3, stationName = "Ajka", stopNumber = 1 });
                stations.Add(new Station { id_route = 3, stationName = "Devecser", stopNumber = 2 });
                stations.Add(new Station { id_route = 3, stationName = "Boba", stopNumber = 3 });
                stations.Add(new Station { id_route = 3, stationName = "Celldömölk", stopNumber = 4 });
                stations.Add(new Station { id_route = 3, stationName = "Sárvár", stopNumber = 5 });
                //stations.Add(new Station { id_route = 3, stationName = "Szombathely", stopNumber = 6 });

                //route4
                //stations.Add(new Station { id_route = 4, stationName = "Ajka", stopNumber = 1 });
                stations.Add(new Station { id_route = 4, stationName = "Celldömölk", stopNumber = 2 });
                //stations.Add(new Station { id_route = 4, stationName = "Szombathely", stopNumber = 3 });
                for (int i = 0; i < stations.Count; i++)
                {
                    _connection.Insert(stations[i]);
                }
            }
        }

    }

    [Table("Route")]
    public class Route
    {
        [PrimaryKey, AutoIncrement][Column("id")] public int Id { get; set; }
        [Column("firstStation")] public string firstStation { get; set; }
        [Column("lastStation")] public string lastStation { get; set; }
        [Column("type")] public string type { get; set; }
        [Column("firstClassPrice")] public int firstClassPrice { get; set; }
        [Column("secondClassPrice")] public int secondClassPrice { get; set;}
        [Column("stopsNumber")] public int stopsNumber { get; set; }
    }

    [Table("Station")]
    public class Station
    {
        [PrimaryKey, AutoIncrement][Column("id")]public int Id { get; set; }
        [Column("id_route")] public int id_route { get; set; }
        [Column("stationName")]public string stationName { get; set; }
        [Column("stopNumber")]public int stopNumber { get; set; }
    }

    [Table("Tickets")]
    public class Tickets
    {
        [PrimaryKey, AutoIncrement][Column("id")] public int Id { get; set; }
        [Column("id_route")] public int id_route { get; set; }
        [Column("buyerName")] public string buyerName { get; set; }
        [Column("firstClassTickets")] public int firstClassTickets { get; set; }
        [Column("secondClassTickets")] public int secondClassTickets { get; set; }
        [Column("coupon")] public int coupon { get; set; }
        [Column("fullTicket")] public bool fullTicket { get; set; }
        [Column("price")] public int price { get; set; }
        [Column("done")] public bool done { get; set; }
    }

    [Table("Seats")]
    public class Seats
    {
        [PrimaryKey, AutoIncrement][Column("id")] public int Id { get; set; }
        [Column("id_tickets")] public int id_tickets { get; set; }
        [Column("classType")] public string classType { get; set; }
        [Column("seatCode")] public string seatCode { get; set; }
    }

}
