using System;

class TicketNode
{
    public int TicketId;
    public string CustomerName;
    public string MovieName;
    public string SeatNumber;
    public DateTime BookingTime;

    public TicketNode Next;

    public TicketNode(int id, string customer, string movie, string seat)
    {
        TicketId = id;
        CustomerName = customer;
        MovieName = movie;
        SeatNumber = seat;
        BookingTime = DateTime.Now;
        Next = null;
    }
}

class TicketReservationSystem
{
    private TicketNode tail;

    // Add ticket at end
    public void AddTicket(int id, string customer, string movie, string seat)
    {
        TicketNode newNode = new TicketNode(id, customer, movie, seat);

        if (tail == null)
        {
            tail = newNode;
            tail.Next = tail;
            return;
        }

        newNode.Next = tail.Next;
        tail.Next = newNode;
        tail = newNode;
    }

    // Remove ticket by ID
    public void RemoveTicket(int ticketId)
    {
        if (tail == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode current = tail.Next;
        TicketNode prev = tail;

        do
        {
            if (current.TicketId == ticketId)
            {
                if (current == tail && current.Next == tail)
                {
                    tail = null;
                }
                else
                {
                    prev.Next = current.Next;
                    if (current == tail)
                        tail = prev;
                }

                Console.WriteLine("Ticket removed successfully.");
                return;
            }

            prev = current;
            current = current.Next;
        } while (current != tail.Next);

        Console.WriteLine("Ticket not found.");
    }

    // Display all tickets
    public void DisplayTickets()
    {
        if (tail == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = tail.Next;

        Console.WriteLine("Current Booked Tickets:");
        do
        {
            Console.WriteLine($"Ticket ID: {temp.TicketId}");
            Console.WriteLine($"Customer: {temp.CustomerName}");
            Console.WriteLine($"Movie: {temp.MovieName}");
            Console.WriteLine($"Seat: {temp.SeatNumber}");
            Console.WriteLine($"Booking Time: {temp.BookingTime}");
            Console.WriteLine("---------------------------");

            temp = temp.Next;
        } while (temp != tail.Next);
    }

    // Search by customer or movie
    public void SearchTicket(string keyword)
    {
        if (tail == null)
        {
            Console.WriteLine("No tickets booked.");
            return;
        }

        TicketNode temp = tail.Next;
        bool found = false;

        do
        {
            if (
                temp.CustomerName.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                || temp.MovieName.Equals(keyword, StringComparison.OrdinalIgnoreCase)
            )
            {
                Console.WriteLine(
                    $"Ticket ID: {temp.TicketId}, Customer: {temp.CustomerName}, Movie: {temp.MovieName}"
                );
                found = true;
            }

            temp = temp.Next;
        } while (temp != tail.Next);

        if (!found)
            Console.WriteLine("No matching ticket found.");
    }

    // Count total tickets
    public int CountTickets()
    {
        if (tail == null)
            return 0;

        int count = 0;
        TicketNode temp = tail.Next;

        do
        {
            count++;
            temp = temp.Next;
        } while (temp != tail.Next);

        return count;
    }
}

class Program
{
    static void Main()
    {
        TicketReservationSystem system = new TicketReservationSystem();

        system.AddTicket(101, "Alice", "Inception", "A1");
        system.AddTicket(102, "Bob", "Avatar", "B2");
        system.AddTicket(103, "Charlie", "Inception", "C3");

        system.DisplayTickets();

        Console.WriteLine("Search by Movie:");
        system.SearchTicket("Inception");

        Console.WriteLine("Total Tickets: " + system.CountTickets());

        system.RemoveTicket(102);
        system.DisplayTickets();
    }
}
