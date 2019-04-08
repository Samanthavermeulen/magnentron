using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApp1.View;

// goes from View to ViewModel

// view is for the person who wants to do the grapic stuff
// model is for the person with database
// viewmodel is for the person who wants to code
namespace WpfApp1.ViewModel
{
    // om te zorgen dat de view kan binding met de viewmodel
    // moet de viewmodel de interface INotifyPropertyChanged 

    // implimenteer interface
    public class MainViewModel : INotifyPropertyChanged
    {

      //acces modifier => public or private 
      //fields is private and property public 

      // Backing Fields
      private string _timer;
      private string _display;
      private readonly MicrowaveState _microwaveState = new MicrowaveState();

    
      // property
      public MicrowaveState MicrowaveState { get { return _microwaveState; } }


        /// <summary>
        /// set the DispatcherTime on the background thread
        /// the DispatcherTime fired it's tick event on the foreground thread
        /// </summary>
        // field
        private readonly DispatcherTimer _dispatcherTimer;

        private readonly DispatcherTimer _doorTimer;
      // constructor of the MainViewModel
       public MainViewModel()
       {
           _doorTimer = new DispatcherTimer();
           _doorTimer.Tick += (o, e) =>
           {
               _doorTimer.Stop();
               switch (MicrowaveState.DoorStatus)
               {
                   case Door.Closing:
                       MicrowaveState.DoorStatus = Door.Closed;
                       break;
                   case Door.Closed:
                       MicrowaveState.DoorStatus = Door.Opening;
                       break;
                   case Door.Opening:
                       MicrowaveState.DoorStatus = Door.Open;
                       break;
                   case Door.Open:
                       MicrowaveState.DoorStatus = Door.Closing;
                       break;
                   default:break;

               }
           };
            _doorTimer.Interval = new TimeSpan(0,0,2);

           // lamp
            OffCommand = new RelayCommand(o => { MicrowaveState.SwitchLamp = false;}, o => MicrowaveState.SwitchLamp);
            StartCommand = new RelayCommand(o => { MicrowaveState.SwitchLamp = true;}, o => MicrowaveState.SwitchLamp == false && MicrowaveState.DoorStatus == Door.Closed);

            // door open & close
            OpenDoorCommand = new RelayCommand(o =>
            {
                MicrowaveState.DoorStatus = Door.Opening; 
                _doorTimer.Start();
            }, o => MicrowaveState.DoorStatus == Door.Closed);
            CloseDoorCommand = new RelayCommand(o =>
            {
                MicrowaveState.DoorStatus = Door.Closing;
                _doorTimer.Start();
            }, o => MicrowaveState.DoorStatus == Door.Open);


            // constructor of the DispatcherTimer
            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
           
           /*
            * When the DispatcherTimer is over one minute,
            * then the tick event is fired
            *
            * function o (a,b)
            * {}
            *
            * (a,b) =>
            * {}
            */
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
           _dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
           _dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }



      // another propety
      public string Timer
      {
          get { return _timer; }
          set
          {
                if(_timer == value) return; // if the timer has te same value, no no changed
                _timer = value; // else si si changed the timer please => and notify the change for me please
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Timer)));

          }
      }

      public string Display
      {
        get { return _display; }
          set
          {
              if(_display == value) return;
              _display = value;
              PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Display)));
          }
      }


        public event PropertyChangedEventHandler PropertyChanged;

        // lamp
        public ICommand StartCommand { get; }// if the lamp is on or not? => true or false
        public ICommand OffCommand { get; }

        // door
        public ICommand OpenDoorCommand { get; }
        public ICommand CloseDoorCommand { get; }


    }
}
