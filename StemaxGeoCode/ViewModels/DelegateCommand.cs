using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace StemaxGeoCode.ViewModels
{
    class DelegateCommand<T> : ICommand
    {
        private readonly Predicate<T?>? _canExecute;
        private readonly Action<T?> _execute;

        public DelegateCommand(Action<T?> execute, Predicate<T?>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;            
        }

        public event EventHandler? CanExecuteChanged {
            add{ CommandManager.RequerySuggested += value; }
            remove{ CommandManager.RequerySuggested -= value; }        
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? false;
        }

        public void Execute(object? parameter)
        {
            _execute((T)parameter);
        }
    }
}
