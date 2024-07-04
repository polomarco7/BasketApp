﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasketApp.ViewModel
{
    internal class RelayCommand : ICommand
    {
        Action<object?> execute;
        Func<object?, bool>? canExecute;

        event EventHandler? ICommand.CanExecuteChanged
        {
            add
            {
                { CommandManager.RequerySuggested += value; }
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        bool ICommand.CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        void ICommand.Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
