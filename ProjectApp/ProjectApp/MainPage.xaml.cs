using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace ProjectApp
{
    public partial class MainPage : ContentPage
    {
        Stopwatch stopwatch;



        public MainPage() //constructor
        {
            InitializeComponent();

            //adding a new stopwatch
            stopwatch = new Stopwatch();
        }


        //event handler for a button called BtnStart to handle the click event

        private void BtnStart_Clicked(object sender, EventArgs e)
        {
            //if statement to start stopwatch if not already running
            if(!stopwatch.IsRunning)
            {
                //method to start stopwatch
                stopwatch.Start();

                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {   
                    //displays the stopwatch time in the label called lblStopwatch
                    lblStopwatch.Text = stopwatch.Elapsed.ToString();

                    if(!stopwatch.IsRunning)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }


                );
            }


        }
        //event handler for a button called BtnStop to handle the click event 
        private void BtnStop_Clicked(object sender, EventArgs e)
        {
            //changes start text to resume after the stopwatch has started
            if (stopwatch.IsRunning)
            {
                btnStart.Text = "Resume";
            }
            //stops timer on stopwatch
            stopwatch.Stop();
        }
        
        //event handler for a button called BtnReset to handle the click event
        private void BtnReset_Clicked(object sender, EventArgs e)
        {
            //resets text on stopwatch to zero
            lblStopwatch.Text = "00:00:00.0000";

            //changes resume text to start as no time has elapsed on the timer now
            btnStart.Text = "Start";

            //resets timer on stopwatch
            stopwatch.Reset();
        }

        //event handler for a button called CalculateCalories to handle the click event
        private void CalculateCalories_Clicked(object sender, EventArgs e)
        {
            //declare variables
            float calsBurned;
            float minutesRan;
            
            //create boolean value isMinutesRanEmpty
            bool isMinutesRanEmpty = true;

            //IsNullOrEmpty is a static method
            isMinutesRanEmpty = string.IsNullOrEmpty(minutesEntered.Text);

            //if isMRE = true, do nothing
            if(isMinutesRanEmpty)
            {
                //do nothing
                calAnswer.Text = "Please Enter A Value For Minutes Ran";
                return;
            }

            minutesRan = (float)Convert.ToDecimal(minutesEntered.Text);

            //declare constant for calsPerMin
            const double calsPerMin = 13.015;

            //calculate calsBurned
            calsBurned = (float)(minutesRan * calsPerMin);

            //put the answer in the label calAnswer
            calAnswer.Text = "Your Calories Burned Is: " + calsBurned.ToString();
        }
    }
}
