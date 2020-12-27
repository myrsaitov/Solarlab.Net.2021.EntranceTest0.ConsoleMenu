using System;
using System.Collections.Generic;
using Planner;


public class Plan
{
    public string Description { get; set; }
    public double UnixTime { get; set; }
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