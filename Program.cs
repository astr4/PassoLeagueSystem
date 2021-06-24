using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace PassoLeagueSystem
{
    class Program
    {
        private static List<Match> matches;

        public static List<Match> Matches
        {
            get => matches;
            set => matches = value;
        }

        static void Main(string[] args)
        {
            Matches = new List<Match>();
            string customerUsernameList =
                @"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\customerUsernameList.txt";
            string customerPasswordList =
                @"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\customerPasswordList.txt";
            string matchesFile = @"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Matches.txt";
            string ticketsFile = @"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Tickets.txt";
            string[] matchesFiles =
                File.ReadAllLines(@"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Matches.txt");
            string[] ticketsFiles =
                File.ReadAllLines(@"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Tickets.txt");
            int matchNumber = matchesFiles.Length / 7;
            for (int i = 0; i < matchNumber; i++)
            {
                Matches.Add(new Match());
            }
            List<Customer> customers = new List<Customer>();
            List<Admin> admins = new List<Admin>();
            
            Admin admin = new Admin("admin", 12345);
            Admin admin2 = new Admin("Arda", 142536);
            
            Customer cust = new Customer(12345, "AliT", 123456, "Ali", "Tomar", 28);
            Customer cust2 = new Customer(12345, "KemalD", 123456, "Kemal", "Demirci", 32);
            Customer cust3 = new Customer(12345, "NeclaS", 123456, "Necla", "Semen", 45);
            Customer cust4 = new Customer(12345, "CemU", 123456, "Cem", "Uzay", 25);
            Customer cust5 = new Customer(12345, "AyberkO", 123456, "Ayberk", "Ortancalar", 23);
            Customer cust6 = new Customer(12345, "SilaT", 123456, "Sila", "Tekcan", 23);
            
            admins.Add(admin);
            admins.Add(admin2);

            customers.Add(cust);
            customers.Add(cust2);
            customers.Add(cust3);
            customers.Add(cust4);
            customers.Add(cust5);
            customers.Add(cust6);
            
            LoadMatchesAndTickets();
            
            while (true)
            {
                Console.WriteLine("Welcome to Passo League System");
                Console.WriteLine("Press 0 For Terminate the System");
                Console.WriteLine("Press 1 For Customer");
                Console.WriteLine("Press 2 For Admin");
                int selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 0:
                        Environment.Exit(-1);
                        break;
                    case 1:
                        bool isUserVerified = false;
                        Console.WriteLine("Please Enter your Username: ");
                        string username = Console.ReadLine();
                        foreach (var customer in customers)
                        {
                            if (customer.UserName.Equals(username))
                            {
                                Console.WriteLine("Please Enter your password: ");
                                int password = Convert.ToInt32(Console.ReadLine());
                               
                                if (customer.Password == password) {
                                    isUserVerified = true;
                                }
                            }
                        }
                        if (!isUserVerified)
                        {
                            Console.WriteLine("Wrong Username or Password!");
                        }
                        while (isUserVerified)
                        {
                            Console.WriteLine("Press 0 for Log-out");
                            Console.WriteLine("Press 1 for Display the incoming matches");
                            Console.WriteLine("Press 2 for Searching for a ticket to buy");
                            Console.WriteLine("Press 3 for Displaying bought tickets");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 0:
                                    isUserVerified = false;
                                    break;
                                case 1:
                                    cust.displayIncoming();
                                    break;
                                case 2:
                                    Console.WriteLine("Please Enter Match ID: ");
                                    cust.searchFromIDAndDisplayTicket(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case 3:
                                    cust.displayBoughtTickets();
                                    break;
                            }
                        }
                        break;
                    case 2:
                        bool isAdminVerified = false;
                        Console.WriteLine("Please Enter your Username: ");
                        string adminName = Console.ReadLine();
                        foreach (var admn in admins)
                        {
                            if (admn.UserName.Equals(adminName))
                            {
                                Console.WriteLine("Please Enter your password: ");
                                int password = Convert.ToInt32(Console.ReadLine());
                               
                                if (admn.Password == password) {
                                    isAdminVerified = true;
                                }
                            }
                        }
                        if (!isAdminVerified)
                        {
                            Console.WriteLine("Wrong Username or Password!");
                        }

                        while (isAdminVerified)
                        {
                            Console.WriteLine("Press 0 for Log-out");
                            Console.WriteLine("Press 1 for adding new Match Info");
                            Console.WriteLine("Press 2 for removing Match Info");
                            Console.WriteLine("Press 3 for Display Match");
                            Console.WriteLine("Press 4 for search Match");
                            Console.WriteLine("Press 5 for display avaible matches");
                            Console.WriteLine("Press 6 for display non-avaible matches: ");
                            Console.WriteLine("Press 7 for search ticket for a match: ");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 0:
                                    isAdminVerified = false;
                                    break;
                                case 1:
                                    admin.addMatch();
                                    break;
                                case 2:
                                    LoadMatchesAndTickets();
                                    foreach (var match in Matches)
                                    {
                                        match.Display();
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine("Please enter the match ID: ");
                                    admin.removeMatch(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case 3:
                                    LoadMatchesAndTickets();
                                    foreach (var match in Matches)
                                    {
                                        match.Display();
                                        Console.WriteLine();
                                    }

                                    break;
                                case 4:
                                    Console.WriteLine("To search from ID Press 1");
                                    Console.WriteLine("To search from Start Date Press 2");
                                    Console.WriteLine("To search from Place Press 3");
                                    Console.WriteLine("To search from Team Press 4: ");
                                    switch (Convert.ToInt32(Console.ReadLine()))
                                    {
                                        case 1:
                                            Console.WriteLine("Please enter the Match ID: ");
                                            admin.searchFromID(Convert.ToInt32(Console.ReadLine()));
                                            break;
                                        case 2:
                                            Console.WriteLine("Please enter the Start Date: ");
                                            admin.searchFromDate(Convert.ToDateTime(Console.ReadLine()));
                                            break;
                                        case 3:
                                            Console.WriteLine("Please enter the Place: ");
                                            admin.searchFromPlace(Console.ReadLine());
                                            break;
                                        case 4:
                                            Console.WriteLine("Please enter the Team: ");
                                            admin.searchFromTeam(Console.ReadLine());
                                            break;
                                    }

                                    break;
                                case 5:
                                    admin.displayAvaibleMatches();
                                    break;
                                case 6:
                                    admin.displayNon_AvaibleMatches();
                                    break;
                                case 7:
                                    Console.WriteLine("Enter Match ID: ");
                                    admin.searchFromIDAndDisplayTicket(Convert.ToInt32(Console.ReadLine()));
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
            }
        }
        public static void LoadMatchesAndTickets()
        {
            string[] matchesFile =
                File.ReadAllLines(@"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Matches.txt");
            string[] ticketsFile =
                File.ReadAllLines(@"C:\\Users\\astr4moon\\Desktop\\PassoLeagueSystem\\PassoLeagueSystem\\Tickets.txt");
            int ticketLine = 0;
            int matchLine = 0;
            foreach (var match in Matches)
            {
                match.Id = Convert.ToInt32(matchesFile[matchLine]);
                matchLine++;
                match.Team1 = matchesFile[matchLine];
                matchLine++;
                match.Team2 = matchesFile[matchLine];
                matchLine++;
                match.StartDate = Convert.ToDateTime(matchesFile[matchLine]);
                matchLine++;
                match.StartTime = Convert.ToDateTime(matchesFile[matchLine]);
                matchLine++;
                match.Place = matchesFile[matchLine];
                matchLine++;
                match.HallCapacity = Convert.ToInt32(matchesFile[matchLine]);
                matchLine++;
                match.Ticket = new Ticket();
                match.Ticket.TicketId = Convert.ToInt32(ticketsFile[ticketLine]);
                ticketLine++;
                match.Ticket.MatchId = Convert.ToInt32(ticketsFile[ticketLine]);
                ticketLine++;
                match.Ticket.Status = ticketsFile[ticketLine];
                ticketLine++;
                match.Ticket.Price = Convert.ToInt32(ticketsFile[ticketLine]);
                ticketLine++;
            }
        }
    }
}