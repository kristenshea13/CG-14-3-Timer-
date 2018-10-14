using System;
using System.Timers;

namespace CG_14_3__Timer_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Timer program");

            Console.Write("Type the length of time between now and when you would like the timer to go off in hours, minutes, and seconds \n" +
                "(example: type 5:41:19 to have the timer go off in 5 hours 41 minutes and 19 seconds): ");

            string timeString = Console.ReadLine();

            //if/else to handle exception thrown from the try/can in the SetTime.TotalMilliseconds method.
            //if TotalMilliseconds method returns 0, it means it was not
            //input in proper format and will print an error message to user.
            //if TotalMilliseconds method does not return 0, the rest of the program will run.

            if (SetTime.TotalMilliseconds(timeString) == 0)
            {
                Console.WriteLine("Error. Set time not in proper format.");
            }

        
            else
            {
                Timer timer = new Timer(SetTime.TotalMilliseconds(timeString));

                timer.Elapsed += TimedEvent;
                //start timer
                timer.Start();
                //timer will stop and program will close when user hits enter
                Console.ReadLine();
                timer.Stop();
            }

            Console.ReadLine();
        }

        /// <summary>
        /// print elapsed time when timer goes off.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void TimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Time's Up: {0:HH:mm:ss}. Hit enter to stop timer.", e.SignalTime);
            
        }
    }
}