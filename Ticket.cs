using System;

namespace PassoLeagueSystem
{
    public class Ticket
    {
        private int ticketID;
        private int matchID;
        private string status;
        private int price;

        public Ticket()
        {
            
        }
        public Ticket(int ticketId, int matchId, string status, int price)
        {
            ticketID = ticketId;
            matchID = matchId;
            this.status = status;
            this.price = price;
        }
        
        public int TicketId
        {
            get => ticketID;
            set => ticketID = value;
        }

        public int MatchId
        {
            get => matchID;
            set => matchID = value;
        }

        public string Status
        {
            get => status;
            set => status = value;
        }

        public int Price
        {
            get => price;
            set => price = value;
        }

        public void Display()
        {
            Console.WriteLine("Ticket Info; ");
            Console.WriteLine("Ticket ID: " + TicketId);
            Console.WriteLine("Match ID: " + MatchId);
            Console.WriteLine("Status: " + Status);
            Console.WriteLine("Price: " + Price);
            
        }
    }
}