using System;
using System.Collections.Generic;


public class Plan
{
    public string Description { get; set; }
    public double UnixTime { get; set; }
}

public class MyList
{
    int Selected = 0;
    int EditIndex = 0;
    double AddedUnixTime = 0;

    List<Plan> ListOfPlans;
    public MyList()
    {
        this.ListOfPlans = new List<Plan>()
        {
            new Plan() { Description = "Deadline for submitting a test task", UnixTime = 1581580800},
            new Plan() { Description = "Registration for Solar Lab courses", UnixTime = 1580821200},
            new Plan() { Description = "First lesson", UnixTime = 1581962400},
            new Plan() { Description = "Last lesson", UnixTime = 1587664800},
        };
    }

    static DateTime ConvertFromUnixTimestamp(double timestamp)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return origin.AddSeconds(timestamp);
    }
    static double ConvertToUnixTimestamp(DateTime date)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan diff = date - origin;
        return Math.Floor(diff.TotalSeconds);
    }
    public static int CompareUnixTime(Plan plan1, Plan plan2)
    {
        return plan1.UnixTime.CompareTo(plan2.UnixTime);
    }
    public void Show()
    {
        Console.WriteLine("My List of plans:");
        Console.WriteLine();

        this.ListOfPlans.Sort(CompareUnixTime);

        if (this.ListOfPlans.Count == 1) { this.Selected = 0; }

        if (this.AddedUnixTime > 0)
        {
            for (int i = 0; i < this.ListOfPlans.Count; i++)
            {
                if (this.AddedUnixTime == this.ListOfPlans[i].UnixTime)
                { this.Selected = i; }
            }

            this.AddedUnixTime = 0;
        }

        for (int i = 0; i < this.ListOfPlans.Count; i++)
        {
            if (i == Selected)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ConvertFromUnixTimestamp(this.ListOfPlans[i].UnixTime).ToString("yyyy/MM/dd HH:mm:ss") + " " + this.ListOfPlans[i].Description);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ConvertFromUnixTimestamp(this.ListOfPlans[i].UnixTime).ToString("yyyy/MM/dd HH:mm:ss") + " " + this.ListOfPlans[i].Description);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        //foreach (Plan plan in ListOfPlans)
        //Console.WriteLine(ConvertFromUnixTimestamp(plan.UnixTime).ToString("yyyy/MM/dd HH:mm:ss") + " " + plan.Description);

    }
    public void SelectedShow() { Console.WriteLine(this.Selected); }
    public void SelectUp()
    {
        if (this.Selected > 0) { this.Selected--; }
    }

    public void SelectDown()
    {
        if (this.Selected < this.ListOfPlans.Count - 1) { this.Selected++; }
    }

    public void Add()
    {
        Console.Clear();
        Console.WriteLine("Add new Item:");
        Console.WriteLine();

        Console.Write("Description: ");
        string AddDescription = Console.ReadLine();

        string Input;
        bool RES = true;

        Console.Write("Year: ");
        Input = Console.ReadLine();
        int Year = -1;
        RES &= Int32.TryParse(Input, out Year);

        Console.Write("Month: ");
        Input = Console.ReadLine();
        int Month = -1;
        RES &= Int32.TryParse(Input, out Month);

        Console.Write("Day: ");
        Input = Console.ReadLine();
        int Day = -1;
        RES &= Int32.TryParse(Input, out Day);

        Console.Write("Hour: ");
        Input = Console.ReadLine();
        int Hour = -1;
        RES &= Int32.TryParse(Input, out Hour);

        Console.Write("Minute: ");
        Input = Console.ReadLine();
        int Minute = -1;
        RES &= Int32.TryParse(Input, out Minute);

        Console.Write("Second: ");
        Input = Console.ReadLine();
        int Second = -1;
        RES &= Int32.TryParse(Input, out Second);

        if (!RES) 
        {
            Console.WriteLine();
            Console.WriteLine("Error!");
            Console.WriteLine("USE Only 0 ... 9 Symbols!: ");
            Console.WriteLine();
            Console.WriteLine("Press ANY key to Continue!");
            ConsoleKeyInfo cki1;
            int num1 = 0;
            do
            {
                cki1 = Console.ReadKey(true);
                num1 = Convert.ToInt32(cki1.Key);
                if (num1 != null) break;

            } while (true);

        }
        else
        {


            int Test = 0;

            Console.WriteLine();

            if ((Year >= 1970) && (Year <= 2100))
            {
                Test++;
            }
            else { Console.WriteLine("TimeStamp Input Error: Invalid Year!"); }

            if ((Month >= 1) && (Month <= 12))
            {
                Test++;
            }
            else { Console.WriteLine("TimeStamp Input Error: Invalid Month!"); }

            if ((Day >= 1) && (Day <= 31))
            {
                Test++;
            }
            else { Console.WriteLine("TimeStamp Input Error: Invalid Day!"); }

            if ((Hour >= 1) && (Hour <= 23))
            {
                Test++;
            }
            else { Console.WriteLine("TimeStamp Input Error: Invalid Hour!"); }

            if ((Minute >= 1) && (Minute <= 59))
            {
                Test++;
            }
            else { Console.WriteLine("TimeStamp Input Error: Invalid Minute!"); }

            if ((Second >= 1) && (Second <= 59))
            {
                Test++;
            }
            else { Console.WriteLine("TimeStamp Input Error: Invalid Second!"); }

            if (Test == 6)
            {
                DateTime NewDateTime = new DateTime(Year, Month, Day, Hour, Minute, Second);
                double NewUnixTime = ConvertToUnixTimestamp(NewDateTime);
                this.ListOfPlans.Add(new Plan() { Description = AddDescription, UnixTime = NewUnixTime });
                this.AddedUnixTime = NewUnixTime;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Press ANY key to Continue!");
                ConsoleKeyInfo cki;
                int num = 0;
                do
                {
                    cki = Console.ReadKey(true);
                    num = Convert.ToInt32(cki.Key);
                    if (num != null) break;

                } while (true);
            }
        }   
    }
    public void Remove()
    {
        if (this.ListOfPlans.Count > 0)
        {
            Console.Clear();
            this.ListOfPlans.RemoveAt(Selected);
            Console.WriteLine("Succesfully removed!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Nothing to remove!");
        }


        Console.WriteLine();
        Console.WriteLine("Press ANY key to Continue!");
        ConsoleKeyInfo cki;
        int num = 0;
        do
        {
            cki = Console.ReadKey(true);
            num = Convert.ToInt32(cki.Key);
            if (num != null) break;

        } while (true);

    }
    public void Edit()
    {
        DateTime DT = ConvertFromUnixTimestamp(this.ListOfPlans[this.Selected].UnixTime);
        string AddDescription = this.ListOfPlans[this.Selected].Description;
        Console.Clear();
        Console.WriteLine(DT.ToString("yyyy/MM/dd HH:mm:ss") + " " + AddDescription);
        Console.WriteLine();
        Console.WriteLine("Press to Edit:");
        Console.WriteLine("1.  Year");
        Console.WriteLine("2.  Month");
        Console.WriteLine("3.  Day");
        Console.WriteLine("4.  Hours");
        Console.WriteLine("5.  Minutes");
        Console.WriteLine("6.  Secons");
        Console.WriteLine("D.  Description");
        Console.WriteLine();
        Console.WriteLine("X.  Abort and Exit");
        Console.WriteLine();


        string Input;
        bool RES = true;
        int Year = Int32.Parse(DT.ToString("yyyy"));
        int Month = Int32.Parse(DT.ToString("MM"));
        int Day = Int32.Parse(DT.ToString("dd"));
        int Hour = Int32.Parse(DT.ToString("HH"));
        int Minute = Int32.Parse(DT.ToString("mm"));
        int Second = Int32.Parse(DT.ToString("ss"));

        while (true)
        {
            ConsoleKeyInfo Key = Console.ReadKey(true);

            if (Key.Key == ConsoleKey.D1)
            {
                Console.Write("New Year: ");
                Input = Console.ReadLine();
                RES &= Int32.TryParse(Input, out Year);
                if (!RES) 
                {
                    Console.WriteLine("Input Error: Use only 0...9 symbols"); 
                }
                else if ((Year >= 1970) && (Year <= 2100))
                {
                    if (this.ListOfPlans.Count > 0)
                    {
                        this.ListOfPlans.RemoveAt(Selected);
                    }

                    DateTime NewDateTime = new DateTime(Year, Month, Day, Hour, Minute, Second);
                    double NewUnixTime = ConvertToUnixTimestamp(NewDateTime);
                    this.ListOfPlans.Add(new Plan() { Description = AddDescription, UnixTime = NewUnixTime });
                    this.AddedUnixTime = NewUnixTime;
                }
                else { Console.WriteLine("TimeStamp Input Error: Invalid Year!"); }

                break;
            }

            if (Key.Key == ConsoleKey.D2)
            {
                Console.Write("New Month: ");
                Input = Console.ReadLine();
                RES &= Int32.TryParse(Input, out Month);
                if (!RES)
                {
                    Console.WriteLine("Input Error: Use only 0...9 symbols");
                }
                else if ((Month >= 1) && (Month <= 12))
                {
                    if (this.ListOfPlans.Count > 0)
                    {
                        this.ListOfPlans.RemoveAt(Selected);
                    }

                    DateTime NewDateTime = new DateTime(Year, Month, Day, Hour, Minute, Second);
                    double NewUnixTime = ConvertToUnixTimestamp(NewDateTime);
                    this.ListOfPlans.Add(new Plan() { Description = AddDescription, UnixTime = NewUnixTime });
                    this.AddedUnixTime = NewUnixTime;
                }
                else { Console.WriteLine("TimeStamp Input Error: Invalid Month!"); }

                break;
            }

            if (Key.Key == ConsoleKey.D3)
            {
                Console.Write("New Day: ");
                Input = Console.ReadLine();
                RES &= Int32.TryParse(Input, out Day);
                if (!RES)
                {
                    Console.WriteLine("Input Error: Use only 0...9 symbols");
                }
                else if ((Day >= 1) && (Day <= 31))
                {
                    if (this.ListOfPlans.Count > 0)
                    {
                        this.ListOfPlans.RemoveAt(Selected);
                    }

                    DateTime NewDateTime = new DateTime(Year, Month, Day, Hour, Minute, Second);
                    double NewUnixTime = ConvertToUnixTimestamp(NewDateTime);
                    this.ListOfPlans.Add(new Plan() { Description = AddDescription, UnixTime = NewUnixTime });
                    this.AddedUnixTime = NewUnixTime;
                }
                else { Console.WriteLine("TimeStamp Input Error: Invalid Day!"); }

                break;
            }

            if (Key.Key == ConsoleKey.D4)
            {
                Console.Write("New Hour: ");
                Input = Console.ReadLine();
                RES &= Int32.TryParse(Input, out Hour);
                if (!RES)
                {
                    Console.WriteLine("Input Error: Use only 0...9 symbols");
                }
                else if ((Hour >= 0) && (Hour <= 23))
                {
                    if (this.ListOfPlans.Count > 0)
                    {
                        this.ListOfPlans.RemoveAt(Selected);
                    }

                    DateTime NewDateTime = new DateTime(Year, Month, Day, Hour, Minute, Second);
                    double NewUnixTime = ConvertToUnixTimestamp(NewDateTime);
                    this.ListOfPlans.Add(new Plan() { Description = AddDescription, UnixTime = NewUnixTime });
                    this.AddedUnixTime = NewUnixTime;
                }
                else { Console.WriteLine("TimeStamp Input Error: Invalid Hour!"); }

                break;
            }

            if (Key.Key == ConsoleKey.D5)
            {
                Console.Write("New Minutes: ");
                Input = Console.ReadLine();
                RES &= Int32.TryParse(Input, out Minute);
                if (!RES)
                {
                    Console.WriteLine("Input Error: Use only 0...9 symbols");
                }
                else if ((Minute >= 0) && (Minute <= 59))
                {
                    if (this.ListOfPlans.Count > 0)
                    {
                        this.ListOfPlans.RemoveAt(Selected);
                    }

                    DateTime NewDateTime = new DateTime(Year, Month, Day, Hour, Minute, Second);
                    double NewUnixTime = ConvertToUnixTimestamp(NewDateTime);
                    this.ListOfPlans.Add(new Plan() { Description = AddDescription, UnixTime = NewUnixTime });
                    this.AddedUnixTime = NewUnixTime;
                }
                else { Console.WriteLine("TimeStamp Input Error: Invalid Minutes!"); }

                break;
            }

            if (Key.Key == ConsoleKey.D6)
            {
                Console.Write("New Seconds: ");
                Input = Console.ReadLine();
                RES &= Int32.TryParse(Input, out Second);
                if (!RES)
                {
                    Console.WriteLine("Input Error: Use only 0...9 symbols");
                }
                else if ((Second >= 0) && (Second <= 59))
                {
                    if (this.ListOfPlans.Count > 0)
                    {
                        this.ListOfPlans.RemoveAt(Selected);
                    }

                    DateTime NewDateTime = new DateTime(Year, Month, Day, Hour, Minute, Second);
                    double NewUnixTime = ConvertToUnixTimestamp(NewDateTime);
                    this.ListOfPlans.Add(new Plan() { Description = AddDescription, UnixTime = NewUnixTime });
                    this.AddedUnixTime = NewUnixTime;
                }
                else { Console.WriteLine("TimeStamp Input Error: Invalid Seconds!"); }

                break;
            }

            if (Key.Key == ConsoleKey.D)
            {
                Console.Write("New Description: ");
                AddDescription = Console.ReadLine();

                if (this.ListOfPlans.Count > 0)
                {
                    this.ListOfPlans.RemoveAt(Selected);
                }

                DateTime NewDateTime = new DateTime(Year, Month, Day, Hour, Minute, Second);
                double NewUnixTime = ConvertToUnixTimestamp(NewDateTime);
                this.ListOfPlans.Add(new Plan() { Description = AddDescription, UnixTime = NewUnixTime });
                this.AddedUnixTime = NewUnixTime;
  
                break;
            }

            if (Key.Key == ConsoleKey.X)
            {
                break;
            }
        }
    }
}

public class MyInterface
{

    public MyInterface()
    { 
    
    }

    public void MainScreen(MyList MyListObj) 
    {
        Console.Clear();
        Console.WriteLine("Wellcome to Planner!");
        //MyListObj.SelectedShow();
        Console.WriteLine("________________________________________________");
        Console.WriteLine();
        MyListObj.Show();


        Console.WriteLine();
        Console.WriteLine("________________________________________________");
        Console.WriteLine("Press Cursor Key \"UP\" or \"DOWN\" to Select Note");
        Console.WriteLine("Press \"A\" to Add Note");
        Console.WriteLine("Press \"R\" to Remove Note");
        Console.WriteLine("Press \"E\" to Edit Note");
        Console.WriteLine("Press \"S\" to Save File (not implemeted in this version)");
        Console.WriteLine("Press \"L\" to Load File (not implemeted in this version)");
        Console.WriteLine();
        Console.WriteLine("Press \"X\" to Exit");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("_____________________________________________");
        Console.WriteLine("https://github.com/myrsaitov/planner"); 
    }


    public void MyReadKey(MyList MyListObj)
    {
        while (true)
        {
            ConsoleKeyInfo Key = Console.ReadKey(true);

            if (Key.Key == ConsoleKey.UpArrow)
            {
                MyListObj.SelectUp();
                MainScreen(MyListObj);
            }

            if (Key.Key == ConsoleKey.DownArrow)
            {
                MyListObj.SelectDown();
                MainScreen(MyListObj);
            }

            if (Key.Key == ConsoleKey.A)
            {
                MyListObj.Add();
                MainScreen(MyListObj);
            }

            if (Key.Key == ConsoleKey.R)
            {
                MyListObj.Remove();
                MainScreen(MyListObj);
            }

            if (Key.Key == ConsoleKey.E)
            {
                MyListObj.Edit();
                MainScreen(MyListObj);
            }



            


            if (Key.Key == ConsoleKey.X)
            {
                Console.Write("Exit Program!");
                break;
            }
        }
    }
}

namespace Planner
{
    class Program
    {
        static void Main(string[] args)
        {

            MyInterface MI = new MyInterface();
            MyList ML = new MyList();

            MI.MainScreen(ML);
            MI.MyReadKey(ML);





            //TimeStamp TS = new TimeStamp(2000, 02, 13, 01, 62, 63);

        }



    }
}