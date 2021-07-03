# PassoLeagueSystem
 IEU - Software Engineering Department
SE 307 – Concepts of Object-Oriented
Programming
Passo League System
(PLS)
Ayberk Ortancalar
Sıla Tekcan
Cem Uzay
24.06.2021Passo League System
Project Explanation
Passo League System is a console application for selling electronic tickets for league 
matches.
There are two type of users which are admin and customer. Admin has username and password, 
each customer has a customer id, username, password, customer name, customer surname, customer 
age. They both need to Login to access the system. When the system is started, data is 
automatically loading from text files.
Basically, Admin is able to:
• Add new match information.
• Remove match information.
• Display all matches.
• Search specific matches from the system and display them.
• Display available matches.
• Display non-available matches.
• Search ticket for a match.
Customer is able to:
• Display the incoming matches.
• Search for a ticket to buy.
• Display bought tickets.
System also has Match and Ticket classes in it. Match has id, team1, team2, start date, start 
time, place, hall capacity and Ticket. Ticket has ticket id, match id, status and price. We store 
the data in text files. When the system is started, that data is loading to Lists in the program in 
order to take better advantage of OOP. We implemented all the requirements and operations 
to the system. As I mentioned text files, we have customerLogs.txt, Matches.txt and Tickets.txt. 
We use every line as an attribute. For example, in Match.txt every seven row represents a 
match. In Ticket.txt and customerLogs.txt, every 4 row represents a ticket. Every match is 
loading to Matches list in Program. Then system using this data to operate required processes.Class Diagram:Some Example Outputs
