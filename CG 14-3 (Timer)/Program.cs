using System;
using System.Linq;
using System.Timers;

namespace CG_14_3__Timer_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a basic timer application that lets the user 
            //    set a timer in minutes, seconds, hours or a 
            //    combination thereof.Think of it as a command line 
            //    version of setting a timer through Siri or an Amazon 
            //    Echo.Try to make it as flexible as possible to all 
            //    kinds of crazy input command.Make sure to document 
            //    your program well with comments and create the proper 
            //    classes and objects. Don’t forget your new error 
            //    handling skills.


            Console.WriteLine("Timer program");

            Console.Write("Type the length of time between now and when you would like the timer to go off in hours, minutes, and seconds \n" +
                "(example: type 5:41:19 to have the timer go off in 5 hours 41 minutes and 19 seconds): ");

            string timeString = Console.ReadLine();

            

            

            Timer timer = new Timer(TotalMilliseconds(timeString));
            timer.Elapsed += Timer_Elapsed;
            
            timer.Start();


            Console.ReadLine();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Elapsed: {0:HH:mm:ss}", e.SignalTime);
        }

        public static int TotalMilliseconds(string timeString)
        {
            string[] timestringSplit = timeString.Split(":");

            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            int totalMinutes = 0;
            int totalSeconds = 0;
            



            for (int i = 0; i < timestringSplit.Length; i++)
            {
                if (i == 0)
                    hours = int.Parse(timestringSplit[i]);

                else if (i == 1)
                    minutes = int.Parse(timestringSplit[i]);

                else
                    seconds = int.Parse(timestringSplit[i]);

            }


            totalMinutes = (hours * 60) + minutes;
            totalSeconds = (totalMinutes * 60) + seconds;
            return totalSeconds * 1000;
            

        }
        

}
}
