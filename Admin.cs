using System;
using System.IO;

namespace PassoLeagueSystem
{
    public class Admin
    {
        private string userName;
        private int password;

        public Admin(string userName, int password)
        {
            this.userName = userName;
            this.password = password;
        }

        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        public int Password
        {
            get => password;
            set => password = value;
        }

        public void searchFromIDAndDisplayTicket(int ID)
        {
            foreach (var match in Program.Matches)
            {
                if (match.Id.Equals(ID))
                {
                    match.Ticket.Display();
                    Console.WriteLine();
                }
            }
        }
        public void searchFromID(int ID)
        {
            foreach (var match in Program.Matches)
            {
                if (match.Id.Equals(ID))
                {
                    match.Display();
                    Console.WriteLine();
                }
            }
        }
        public void searchFromTeam(string team)
        {
            foreach (var match in Program.Matches)
            {
                if (match.Team1.Equals(team) || match.Team2.Equals(team))
                {
                    match.Display();
                    Console.WriteLine();
                }
            }
        }
        public void searchFromDate(DateTime date)
        {
            foreach (var match in Program.Matches)
            {
                if (match.StartDate.Equals(date))
                {
                    match.Display();
                    Console.WriteLine();
                }
            }
        }
        public void searchFromPlace(string place)
        {
            foreach (var match in Program.Matches)
            {
                if (match.Place.Equals(place))
                {
                    match.Display();
                    Console.WriteLine();
                }
            }
        }
        public void displayAvaibleMatches()
        {
            foreach (var match in Program.Matches)
            {
                if (match.Ticket.Status.Equals("available"))
                {
                    match.Display();
                    Console.WriteLine();
                }
            }
        }
        public void displayNon_AvaibleMatches()
        {
            foreach (var match in Program.Matches)
            {
                if (match.Ticket.Status.Equals("non-available"))
                {
                    match.Display();
                    Console.WriteLine();
                }
            }
        }
        public void addMatch()
        {
            string matchesFile = @"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Matches.txt";
            string ticketsFile = @"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Tickets.txt";
            using (StreamWriter sw = File.AppendText(matchesFile)) 
            {
                sw.WriteLine("");
                Console.WriteLine("Enter Match ID: ");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Enter Team1: ");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Enter Team2: ");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Enter Start Date (MM/dd/yyyy): ");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Enter Start Time (HH:mm): ");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Enter Place: ");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Enter Hall Capacity: ");
                sw.Write(Console.ReadLine()); 
            }
            
            using (StreamWriter sw = File.AppendText(ticketsFile))
            {
                sw.WriteLine("");
                Console.WriteLine("Enter Ticket ID: ");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Enter Match ID: ");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Enter Status: ");
                sw.WriteLine(Console.ReadLine());
                Console.WriteLine("Enter Price: ");
                sw.Write(Console.ReadLine());
            }
            Program.Matches.Add(new Match());
            Program.LoadMatchesAndTickets();
        }
        public void removeMatch(int matchID)
        {
            string[] matchesFiles =
                File.ReadAllLines(@"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Matches.txt");
            string[] ticketsFiles =
                File.ReadAllLines(@"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Tickets.txt");
            string matchesFile = @"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Matches.txt";
            string ticketsFile = @"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Tickets.txt";

            Program.Matches.RemoveAt(0);
            for (int i = 0; i < matchesFiles.Length; i++)
            {
                var matches = matchesFiles;

                if (matches[i].Equals(matchID.ToString()))
                {
                    matches[i] = null;
                    matches[i + 1] = null;
                    matches[i + 2] = null;
                    matches[i + 3] = null;
                    matches[i + 4] = null;
                    matches[i + 5] = null;
                    matches[i + 6] = null;
                    
                    var tickets = ticketsFiles;
                    
                    for (int j = 0; j < ticketsFiles.Length; j++)
                    {
                        if (tickets[j].Equals(matchID.ToString()))
                        {
                            tickets[j] = null;
                            tickets[j+1] = null;
                            tickets[j+2] = null;
                            tickets[j+3] = null;
                            break;
                        }
                    }
                    int ticketLine = 0;
                    int matchLine = 0;
                    
                    using (StreamWriter sw = new StreamWriter(matchesFile, false)) 
                    {
                        for (int j = 0; j < matches.Length; j++)
                        {
                            if (j==0)
                            {
                                sw.Write(matches[j]);
                                continue;
                            }
                            
                            if (matches[j] != null && matches[j].Equals(matches[matches.Length - 1]))
                            {
                                sw.Write(matches[j]);
                                break;
                            }

                            if (matches[j] != null)
                            {
                                sw.WriteLine();
                                sw.Write(matches[j]);
                            }
                              
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(ticketsFile, false)) 
                    {
                        for (int j = 0; j < tickets.Length; j++)
                        {
                            if (j==0)
                            {
                                sw.Write(tickets[j]);
                                continue;
                            }
                            if (tickets[j] != null && tickets[j].Equals(tickets[tickets.Length - 1]))
                            {
                                sw.Write(tickets[j]);
                                break;
                            }

                            if (tickets[j] != null)
                            {
                                sw.WriteLine();
                                sw.Write(tickets[j]);
                            }
                                
                        }
                    }
                    foreach (var match in Program.Matches)
                    {
                        if (matches[matchLine] == null)
                        {
                            matchesFile = matchesFile + 7;
                        }
                        match.Id = Convert.ToInt32(matches[matchLine]);
                        matchLine++;
                        match.Team1 = matches[matchLine];
                        matchLine++;
                        match.Team2 = matches[matchLine];
                        matchLine++;
                        match.StartDate = Convert.ToDateTime(matches[matchLine]);
                        matchLine++;
                        match.StartTime = Convert.ToDateTime(matches[matchLine]);
                        matchLine++;
                        match.Place = matches[matchLine];
                        matchLine++;
                        match.HallCapacity = Convert.ToInt32(matches[matchLine]);
                        matchLine++;
                        
                        match.Ticket = new Ticket();
                        if (tickets[ticketLine] == null)
                        {
                            ticketLine = ticketLine + 4;
                        }
                        match.Ticket.TicketId = Convert.ToInt32(tickets[ticketLine]);
                        ticketLine++;
                        match.Ticket.MatchId = Convert.ToInt32(tickets[ticketLine]);
                        ticketLine++;
                        match.Ticket.Status = tickets[ticketLine];
                        ticketLine++;
                        match.Ticket.Price = Convert.ToInt32(tickets[ticketLine]);
                        ticketLine++;
                    }
                    break;
                }
            }
        }
    }
}