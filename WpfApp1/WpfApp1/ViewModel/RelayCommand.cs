using System;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    // cosumeer interface


    // public/private/protected/ => acess modifier (toegang)
    // class is een refrence type een object
    // Reference type => sla reference data op (class) 
    // Interface => contract class or a struct


    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);

        }
        // constructor
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

}
