using System;

class Clock {  
    public string? time;
    public double angle;

    //Inicial value constructor
    public Clock(){
        time = null;
        angle = 0;
    }
    //Constructor to input data 
    public Clock(string? input){
        time = input;
        angle = 0;
    }
    public void End() {
        System.Environment.Exit(0);  
    }
    public void print_angle(){
        Console.WriteLine("The lesser angle between hour and minute handles at the time " + time + " is " + angle +" degrees");
    }
};


class Program{	
    static void Main() {
        while(true){
            //Get user input
            Console.WriteLine("Enter analogue clock hours and minutes, like this 12:30 or enter 'stop' to exit"); 
            Clock clock = new Clock(Console.ReadLine()); 
        
            //Exit the program
            if (clock.time == "stop"){
                clock.End();
            }
        
            if (clock.time != null){
                if (!clock.time.Contains(":")){
                    Console.WriteLine("Invalid data, entered input format is incorrect");
                    continue;
                }
                
                if (int.TryParse(clock.time.Split(':')[0], out int hours) && int.TryParse(clock.time.Split(':')[1], out int minutes)) {
                        if ((hours < 0) || (minutes < 0)) {
                            Console.WriteLine("Invalid data, entered values are negative");
                            continue;
                        }
                }
                else{
                    Console.WriteLine("Invalid data, entered values are not numbers / input format is incorrect");
                    continue;
                }

                //Check if user input is logical (hours are in a range [1;12], minutes [0;59])
                if (( hours > 12 || hours < 1 ) || ( minutes > 59 )){
                    Console.WriteLine("Invalid data, entered values are not suitable for an analogue clock");
                    continue;
                }
                
                //Calculate the angle between clock handles
                //Full circle has 360 degrees, angles for both handles will be calculated from the hour 12 in clockwise direction
                //For the hour handle: 1 hour gap = full circle degrees / by number of clock hours -> (hhg=360/12=30 degrees)
                //And 1 min gap = 1 hour gap degrees / by 60 minutes -> (hmg=30/60=0.5 degrees); 
                //Full hour handle angle formula form 12 o'clock = current hour value * 1 hour gap degrees + 1 min gap degrees,for the hour handle,*current minute value -> (a=hhg*h+hmg*min=30*h+0.5*min) 
                //For the minute handle: 1 minute gap = 1 hour gap degrees / by 5 minutes -> (mg=30/5=6)
                //Full minute handle angle formula form 12 o'clock = current minute value * 1 minute gap, for minute handle, -> (b=min*mg=min*6)
                //Calculate the gap between the handles = |hour handle gap - minute handle gap|  -> (gap1=|gap_h-gap_m|)
                clock.angle = Math.Abs((hours*30 + minutes*0.5) - (minutes*6));

                //Check if the calculated angle is the small one = full circle angle - calculated angle -> (gap2=360-gap1)
                if ( (360 - clock.angle) < clock.angle){
                    clock.angle = 360 - clock.angle;
                }
                //Use only hour and minute values in output string (no values like 2:10:10 ...)
                clock.time = hours.ToString() + ':' + minutes.ToString();
                clock.print_angle();
            }
        }
    }
};