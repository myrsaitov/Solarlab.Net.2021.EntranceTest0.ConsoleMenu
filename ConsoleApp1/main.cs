using System;
using System.Collections.Generic;
using Planner;


public class Plan
{
    public string Description { get; set; }
    public double UnixTime { get; set; }
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