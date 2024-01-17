using LawСRM.Commands;
using LawСRM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LawСRM.ViewModels
{
    internal class MainWindowViewModel:ViewModel
    {
        #region Команда
        public ICommand CloseApplicationCommand { get;}
        private bool CanCloseApplicationCommandExecute(object parameter) => true;
        private void OnCloseApplicationCommandExecuted(object parameter)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                // Добавьте точку останова или вывод в консоль для отладки
                MessageBox.Show("Ошибка");
            }
        }
        #endregion
        public MainWindowViewModel() 
        {
            CloseApplicationCommand = new MainCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
        }
        
    }
}
