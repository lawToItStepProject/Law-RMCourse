using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace LawСRM.Commands.Base
{
    public abstract class Command: ICommand
    {
        //Событие срабатывает, когда метод CanExecute возвращает другой тип, 
        //т.е. команда переходит из одного состояния в другое
        event EventHandler? ICommand.CanExecuteChanged
        {
            //чтобы передать управление событием WPF нужно реализовать его явно
            //Управление событием передается классу CommandManager
            add => CommandManager.RequerySuggested += value;
            remove=> CommandManager.RequerySuggested -= value;
        }

        //Метод, отвечающий за возможность использования команды
        bool ICommand.CanExecute(object? parameter)=>CanExecute(parameter);

        //Метод, отвечающий за основную логику команды
        void ICommand.Execute(object? parameter)
        {
            if (((ICommand)this).CanExecute(parameter))
                Execute(parameter);
        }
        protected virtual bool CanExecute(object? p) => true;

        protected abstract void Execute(object? p);

    }
}
