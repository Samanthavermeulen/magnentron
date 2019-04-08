using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{

    public enum Door 
    {
        Opening,
        Closing,
        Open,
        Closed
    };





    public class MicrowaveState : INotifyPropertyChanged
    {
       
        // backing field
        private Door _door = Door.Closed;
        private bool _switchLamp;
        private bool _editTimer;

        public event PropertyChangedEventHandler PropertyChanged;

        // Property
        public Door DoorStatus
        {
            get { return _door; }
            set
            {
                if (_door == value)
                {
                    // return value
                }
                else
                {
                    _door = value;

                switch (_door)
                {
                        case Door.Open:
                            SwitchLamp = false;
                            break;
                        case Door.Closed:
                            break;
                        case Door.Opening:
                            SwitchLamp = false;
                            break;
                        case Door.Closing:
                            SwitchLamp = false;
                            break;
                        default:break;
                      
                }

                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(DoorStatus)));

                }
              
                

            }
        }

        // Property
        public bool SwitchLamp
        {

            get { return _switchLamp; }
            set
            {
                if (_switchLamp == value) return; // if the lamp has the same value, nothing has changed
                _switchLamp = value; // else change value and =>
                //notify change
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SwitchLamp)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SwitchBackground)));
            }

        }
        // turn of the background
        public bool SwitchBackground => !SwitchLamp;

        // Property
        public bool EditTimer
        {
            get { return _editTimer; }
            set
            {
                if(_editTimer == value) return;
                _editTimer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EditTimer)));
            }
        }




    }
}
