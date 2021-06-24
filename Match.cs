using System;

namespace PassoLeagueSystem
{
    public class Match
    {
        private int id;
        private string team1;
        private string team2;
        private DateTime startDate;
        private DateTime startTime;
        private string place;
        private int hallCapacity;
        private Ticket ticket;

        public Match()
        {
            
        }
        public Match(int id, string team1, string team2, DateTime startDate, DateTime startTime, string place, int hallCapacity, Ticket ticket)
        {
            this.id = id;
            this.team1 = team1;
            this.team2 = team2;
            this.startDate = startDate;
            this.startTime = startTime;
            this.place = place;
            this.hallCapacity = hallCapacity;
            this.ticket = ticket;
        }
        public Ticket Ticket
        {
            get => ticket;
            set => ticket = value;
        }
        
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Team1
        {
            get => team1;
            set => team1 = value;
        }

        public string Team2
        {
            get => team2;
            set => team2 = value;
        }

        public DateTime StartDate
        {
            get => startDate;
            set => startDate = value;
        }

        public DateTime StartTime
        {
            get => startTime;
            set => startTime = value;
        }

        public string Place
        {
            get => place;
            set => place = value;
        }

        public int HallCapacity
        {
            get => hallCapacity;
            set => hallCapacity = value;
        }
        public  void Display()
        {
            Console.WriteLine("Match Info;");
            Console.WriteLine("Match ID: " + Id);
            Console.WriteLine("Team1: " + Team1);
            Console.WriteLine("Team2: " + Team2);
            Console.WriteLine("Start Date: " + StartDate.ToString("MM/dd/yyyy"));
            Console.WriteLine("Start Time: " + StartTime.ToString("HH:mm"));
            Console.WriteLine("Place: " + Place);
            Console.WriteLine("Hall Capacity: " + HallCapacity);
            Ticket.Display();
        }
    }
}