using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace LawСRM.Commands.Base
{
    internal abstract class Command: ICommand
    {
        //Событие срабатывает, когда метод CanExecute возвращает другой тип, 
        //т.е. команда переходит из одного состояния в другое
        public event EventHandler CanExecuteChanged
        {
            //чтобы передать управление событием WPF нужно реализовать его явно
            //Управление событием передается классу CommandManager
            add => CommandManager.RequerySuggested += value;
            remove=> CommandManager.RequerySuggested -= value;
        }

        //Метод, отвечающий за возможность использования команды
        public abstract bool CanExecute(object parameter);

        //Метод, отвечающий за основную логику команды
        public abstract void Execute(object parameter);

    }
}
