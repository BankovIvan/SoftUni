using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i, j, speed, N;
        string[] s;
        char[] separator = new char[] {':', ',', ' '};
        List<ParkingZone> parkingZones = new List<ParkingZone>();
        ParkingSpot spot, mall;
        ParkingZone result;

        Console.Write("    ");
        N = int.Parse(Console.ReadLine());

        for(i = 0; i < N; i++)
        {
            Console.Write("    ");
            s = Console.ReadLine().Split(separator);
            parkingZones.Add(new ParkingZone(int.Parse(s[2]), int.Parse(s[4]), int.Parse(s[6]), int.Parse(s[8]), double.Parse(s[10]), s[0]));
        }

        Console.Write("    ");
        s = Console.ReadLine().Split(';');

        foreach (var item in s)
        {
            i = int.Parse(item.Split(',')[0]);
            j = int.Parse(item.Split(',')[1]);

            spot = new ParkingSpot(i, j);

            foreach(var zone in parkingZones)
            {
                if (zone.AddSpot(spot))
                {
                    break;
                }
            }
        }

        Console.Write("    ");
        s = Console.ReadLine().Split(',');

        mall = new ParkingSpot(int.Parse(s[0]), int.Parse(s[1]));

        foreach (var zone in parkingZones)
        {
            zone.SetSpotDistances(mall);
        }

        Console.Write("    ");
        speed = int.Parse(Console.ReadLine());

        foreach (var zone in parkingZones)
        {
            zone.UpdatePrices(speed);
        }

        result = parkingZones.Min();
        spot = result.places.Min();

        Console.WriteLine("Zone Type: {0}; X: {1}; Y: {2}; Price: {3:F2}", result.name, spot.left, spot.top, result.totalPrice);

        return;
    }
}

public class ParkingSpot : IComparable<ParkingSpot>
{
    public int left;
    public int top;
    public int distance;

    public ParkingSpot(int left, int top)
    {
        this.left = left;
        this.top = top;
        this.distance = int.MaxValue;
    }

    public int CompareTo(ParkingSpot other)
    {
        return this.distance.CompareTo(other.distance);
    }

    public override string ToString()
    {
        return "<" + left.ToString().PadLeft(3) + "," + top.ToString().PadLeft(3) + ":" + distance.ToString() + ">";
    }

    public void CalculateDistance(int left, int top)
    {
        this.distance = Math.Abs(this.left - left) + Math.Abs(this.top - top) - 1;
    }
}

public class ParkingZone : IComparable<ParkingZone>
{
    public int left;
    public int top;
    public int width;
    public int height;
    public double price;    // lv / minute
    public string name;
    public List<ParkingSpot> places;

    public int travelTime;  // seconds
    public double totalPrice;  // lv

    public ParkingZone(int left, int top, int width, int height, double price, string name)
    {
        this.left = left;
        this.top = top;
        this.width = width;
        this.height = height;
        this.price = price;
        this.name = name;
        places = new List<ParkingSpot>();

        travelTime = int.MaxValue;
        totalPrice = double.MaxValue;
    }

    public int CompareTo(ParkingZone other)
    {
        //return other.price.CompareTo(this.price);

        int result;

        result = this.totalPrice.CompareTo(other.totalPrice);

        if(result == 0)
        {
            result = this.travelTime.CompareTo(other.travelTime);
        }

        return result;
        
    }

    public override string ToString()
    {
        return "<" + this.left.ToString().PadLeft(3) + "," + this.top.ToString().PadLeft(3) + ":" + string.Format("{0:F2}", this.price) + ":" + this.name.PadLeft(10) + ">";
    }

    public bool CheckSpot(ParkingSpot spot)
    {
        return (spot.left >= this.left) && (spot.left <= (this.left + this.width)) && (spot.top >= this.top) && (spot.top <= (this.top + this.height));
    }

    public bool AddSpot(ParkingSpot spot)
    {
        if(CheckSpot(spot))
        {
            this.places.Add(spot);
            //places.Sort();
            return true;
        }

        return false;
    }

    public void SetSpotDistances(ParkingSpot mall)
    {
        foreach (var item in places)
        {
            item.CalculateDistance(mall.left, mall.top);
        }

        //this.places.Sort();

    }

    public void UpdatePrices(int speed)
    {
        int timeMinutes;

        this.travelTime = this.places.Min().distance * 2 * speed;
        timeMinutes = (this.travelTime / 60) + ((this.travelTime % 60) > 0 ? 1 : 0);
        this.totalPrice = (double)timeMinutes * this.price;

    }
}