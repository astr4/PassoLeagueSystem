using System;
using System.IO;

namespace PassoLeagueSystem
{
    public class Customer : User
    {
        private int customerID;
        private string customerName;
        private string customerSurName;
        private int customerAge;
        private Ticket ticket;
        
        public Customer(int customerId, string userName, int password, string customerName, string customerSurName, int customerAge) : base(userName,password)
        {
            customerID = customerId;
            this.customerName = customerName;
            this.customerSurName = customerSurName;
            this.customerAge = customerAge;
        }

        public int CustomerId
        {
            get => customerID;
            set => customerID = value;
        }
        public string CustomerName
        {
            get => customerName;
            set => customerName = value;
        }

        public string CustomerSurName
        {
            get => customerSurName;
            set => customerSurName = value;
        }

        public int CustomerAge
        {
            get => customerAge;
            set => customerAge = value;
        }
        public Ticket Ticket
        {
            get => ticket;
            set => ticket = value;
        }

        public void displayIncoming()
        {
            foreach (var match in Program.Matches)
            {
                if (match.StartDate > DateTime.Today)
                {
                    match.Display();
                    Console.WriteLine();
                }
            }
        }
        public override void searchFromIDAndDisplayTicket(int ID)
        {
            foreach (var match in Program.Matches)
            {
                if (match.Id.Equals(ID))
                {
                    match.Ticket.Display();
                    Console.WriteLine();
                    if (match.Ticket.Status.Equals("available"))
                    {
                        Console.WriteLine("Do you want to buy the ticket? (y/n): ");
                        if (Console.ReadLine().Equals("y"))
                        {
                            buyTicket(match);
                        }
                        else
                        {
                            Console.WriteLine("Returning to Menu....");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, there is no available ticket!");
                    }
                }
            }
        }
        public void buyTicket(Match match)
        {
            Ticket = (match.Ticket);
            
            string customerLogs = @"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\customerLogs.txt";
            using (StreamWriter sw = File.AppendText(customerLogs))
            {
                sw.WriteLine("");
                sw.WriteLine(match.Ticket.TicketId);
                sw.WriteLine(match.Ticket.MatchId);
                sw.WriteLine(match.Ticket.Status);
                sw.Write(match.Ticket.Price);
            }
        }
        public void displayBoughtTickets()
        {
            string[] customerLogs = File.ReadAllLines(@"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\customerLogs.txt");
            int line = 0;
            foreach (var log in customerLogs)
            {
                Console.WriteLine(log);
            }
        }
    }
}