using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SQLite;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Cryptography;

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
                stations.Add(new Station { id_route = 1, stationName = "Ajka", stopNumber = 1 });
                stations.Add(new Station { id_route = 1, stationName = "Várpalota", stopNumber = 2 });
                stations.Add(new Station { id_route = 1, stationName = "Székesfehérvár", stopNumber = 3 });
                stations.Add(new Station { id_route = 1, stationName = "Velence", stopNumber = 4 });
                stations.Add(new Station { id_route = 1, stationName = "Érd", stopNumber = 5 });
                stations.Add(new Station { id_route = 1, stationName = "Budapest", stopNumber = 6 });

                //route2
                stations.Add(new Station { id_route = 2, stationName = "Ajka", stopNumber = 1 });
                stations.Add(new Station { id_route = 2, stationName = "Székesfehérvár", stopNumber = 2 });
                stations.Add(new Station { id_route = 2, stationName = "Budapest", stopNumber = 3 });

                //route3
                stations.Add(new Station { id_route = 3, stationName = "Ajka", stopNumber = 1 });
                stations.Add(new Station { id_route = 3, stationName = "Devecser", stopNumber = 2 });
                stations.Add(new Station { id_route = 3, stationName = "Boba", stopNumber = 3 });
                stations.Add(new Station { id_route = 3, stationName = "Celldömölk", stopNumber = 4 });
                stations.Add(new Station { id_route = 3, stationName = "Sárvár", stopNumber = 5 });
                stations.Add(new Station { id_route = 3, stationName = "Szombathely", stopNumber = 6 });

                //route4
                stations.Add(new Station { id_route = 4, stationName = "Ajka", stopNumber = 1 });
                stations.Add(new Station { id_route = 4, stationName = "Celldömölk", stopNumber = 2 });
                stations.Add(new Station { id_route = 4, stationName = "Szombathely", stopNumber = 3 });
                for (int i = 0; i < stations.Count; i++)
                {
                    _connection.Insert(stations[i]);
                }
            }
            else
            {
                _connection = new SQLiteConnection(@"database.db3");
            }
        }

        public List<string> getRoutes()
        {
            var routes = _connection.Query<Route>("SELECT firstStation,lastStation from Route GROUP by firstStation,lastStation");
            List<string> r = new List<string>();
            foreach(var route in routes)
            {
                r.Add(route.firstStation + "-" + route.lastStation);
            }
            return r;

        }

        public List<string> getRoutesType(string f, string l)
        {
            var routes = _connection.Query<Route>("SELECT type from Route WHERE firstStation like '" + f + "' and lastStation like '" + l + "'"); 
            List<string> r = new List<string>();
            foreach (var route in routes)
            {
                r.Add(route.type);
            }
            return r;
        }

        public int getRouteId(string f, string l,string t)
        {
            var rid = _connection.Query<Route>("SELECT id from Route WHERE firstStation like '" + f + "' and lastStation like '" + l + "' and type like '"+t+"'");
            if (rid == null) return -1;
            return rid[0].Id;
        }

        public int getTicketPrice(int rid ,int fc, int sc) 
        {
            var ticketPrices = _connection.Query<Route>("SELECT firstClassPrice,secondClassPrice from Route WHERE id="+rid);
            int price = ticketPrices[0].firstClassPrice * fc + ticketPrices[0].secondClassPrice * sc;
            return price;
        }

        public string getRouteById(int rid)
        {
            var route = _connection.Query<Route>("SELECT firstStation,lastStation,type from Route WHERE id=" + rid);
            return route[0].firstStation + "-" + route[0].lastStation+": "+route[0].type+" járat";
        }

        public List<string> getStationsById(int rid)
        {
            List<string> s= new List<string>();
            var stations = _connection.Query<Station>("SELECT stationName,stopNumber from Station WHERE id_route=" + rid+ " ORDER by stopNumber");
            foreach (var station in stations)
            {
                s.Add(station.stopNumber+". állomás: "+station.stationName);
            }
            return s;
        }

        public string getStopsById(int rid)
        {
            var stopNum = _connection.Query<Route>("SELECT stopsNumber from Route WHERE id=" + rid);
            return stopNum[0].stopsNumber.ToString();
        }

        public void insertTicket(int rid,string bName,int fc,int sc,int coupon,bool fullT,int price,List<int> seats)
        {
            _connection.Insert(new Tickets {id_route=rid,buyerName=bName,firstClassTickets=fc,secondClassTickets=sc,coupon=coupon,
                                            fullTicket=fullT,price=price,done=false });
            var ticketId = _connection.Query<Tickets>("SELECT id from Tickets ORDER by id DESC Limit 1");
            foreach(var s in seats) 
            {
                _connection.Insert(new Seats { id_tickets = ticketId[0].Id, seatCode = s });
            }
            MessageBox.Show("Jegy sikeresen meg lett véve!");
        }

        public List<int> getTakenSeats(int rid)
        {
            List<int> s = new List<int>();
            var seats = _connection.Query<Seats>("SELECT seatCode from Seats WHERE id_tickets in (SELECT id from Tickets where id_route='"+ rid+ "')");
            foreach (var seat in seats)
            {
                s.Add(seat.seatCode);
            }
            return s;
        }

        public int getTotalIncome(int rid) 
        {
            int income = 0;
            var inc = _connection.Query<Tickets>("SELECT price from Tickets where id_route=" + rid);
            foreach (var i in inc)
            {
                income += i.price;
            }
            return income;
        }

        public int getTicketId(int rid,int sc)
        {
            var tid = _connection.Query<Tickets>("SELECT id from Tickets where id_route="+rid+" and id in (select id_tickets from Seats where seatCode='"+sc+"')");
            return tid[0].Id;
        }

        public Tickets getTicketsById(int tid)
        {
            var t = _connection.Query<Tickets>("SELECT * from Tickets where id="+tid);
            return t[0];
        }

        public List<int> getTicketSeats(int tid)
        {
            List<int> s = new List<int>();
            var seats = _connection.Query<Seats>("SELECT seatCode from Seats WHERE id_tickets = "+tid);
            foreach (var seat in seats)
            {
                s.Add(seat.seatCode);
            }
            return s;
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
        [Column("seatCode")] public int seatCode { get; set; }
    }

}
