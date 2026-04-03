using System;

class HotelBooking
{
    string guestName;
    string roomType;
    int nights;

    public HotelBooking()
    {
        guestName = "Guest";
        roomType = "Standard";
        nights = 1;
    }

    public HotelBooking(string name, string room, int nights)
    {
        guestName = name;
        roomType = room;
        this.nights = nights;
    }

    public HotelBooking(HotelBooking hb)
    {
        guestName = hb.guestName;
        roomType = hb.roomType;
        nights = hb.nights;
    }

    public void Display()
    {
        Console.WriteLine($"{guestName} | {roomType} | {nights} nights");
    }

    static void Main()
    {
        HotelBooking h1 = new HotelBooking();
        HotelBooking h2 = new HotelBooking("Amit", "Deluxe", 3);
        HotelBooking h3 = new HotelBooking(h2);

        h3.Display();
    }
}
