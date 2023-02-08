using System;

class Clock 
{  
    private string? _time;
    private double _angle;

    //Inicial value constructor
    public Clock()
    {
        _time = null;
        _angle = 0;
    }
    //Constructor to input data 
    public Clock(string input)
    {
        _time = input;
        _angle = 0;
    }

    //Get private field time value
    public string GetTime()
    {
        if(_time != null)
        {
             return _time;
        }
        else
        {
            return "\0";
        }
    }
    //Set private field time value
    public void SetTime(string? input)
    {
        _time = input;
    }

     //Get private field angle value
     public double GetAngle()
     {
        return _angle;
     }
     //Set private field time value
     public void SetAngle(double input)
     {
        _angle = input;
     }

    public void End()
    {
        System.Environment.Exit(0);  
    }

    public void PrintAngle()
    {
        Console.WriteLine("The lesser angle between hour and minute handles at the time " + _time + " is " + _angle +" degrees");
    }
};


class Program
{	
    static Clock CreateClock()
    {
        return new Clock();
    }

    static void Main()
    {
        //Create an object
        Clock clock = CreateClock();
            while(true)
            {
                //Get user input
                Console.WriteLine("Enter analogue clock hours and minutes, like this 12:30 or enter 'stop' to exit"); 
                clock.SetTime(Console.ReadLine());
            
                //Exit the program
                if (clock.GetTime() == "stop")
                {
                    clock.End();
                }
            
                if (clock.GetTime() != null)
                {
                    if (!clock.GetTime().Contains(":"))
                    {
                        Console.WriteLine("Invalid data, entered input format is incorrect");
                        continue;
                    }
                    
                    if (int.TryParse(clock.GetTime().Split(':')[0], out int hours) && int.TryParse(clock.GetTime().Split(':')[1], out int minutes))
                    {
                            if ((hours < 0) || (minutes < 0))
                            {
                                Console.WriteLine("Invalid data, entered values are negative");
                                continue;
                            }
                    }
                    else
                    {
                        Console.WriteLine("Invalid data, entered values are not numbers / input format is incorrect");
                        continue;
                    }

                    //Check if user input is logical (hours are in a range [1;12], minutes [0;59])
                    if ((hours > 12 || hours < 1) || (minutes > 59))
                    {
                        Console.WriteLine("Invalid data, entered values are not suitable for an analogue clock");
                        continue;
                    }
                    
                    /*
                    Calculate the angle between clock handles
                    Full circle has 360 degrees, angles for both handles will be calculated from the hour 12 in clockwise direction
                    For the hour handle: 1 hour gap = full circle degrees / by number of clock hours -> (hhg=360/12=30 degrees)
                    And 1 min gap = 1 hour gap degrees / by 60 minutes -> (hmg=30/60=0.5 degrees); 
                    Full hour handle angle formula form 12 o'clock = current hour value * 1 hour gap degrees + 1 min gap degrees,for the hour handle,*current minute value -> (a=hhg*h+hmg*min=30*h+0.5*min) 
                    For the minute handle: 1 minute gap = 1 hour gap degrees / by 5 minutes -> (mg=30/5=6)
                    Full minute handle angle formula form 12 o'clock = current minute value * 1 minute gap, for minute handle, -> (b=min*mg=min*6)
                    Calculate the gap between the handles = |hour handle gap - minute handle gap|  -> (gap1=|gap_h-gap_m|)
                    */
                    clock.SetAngle( Math.Abs((hours*30 + minutes*0.5) - (minutes*6)) );

                    //Check if the calculated angle is the small one = full circle angle - calculated angle -> (gap2=360-gap1)
                    if ((360 - clock.GetAngle()) < clock.GetAngle())
                    {
                        clock.SetAngle( 360 - clock.GetAngle() );
                    }
                    //Use only hour and minute values in output string (no values like 2:10:10 ...)
                    clock.SetTime(hours.ToString() + ':' + minutes.ToString());
                    clock.PrintAngle();
                }
            }
    }
};

