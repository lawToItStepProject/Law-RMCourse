using LawСRM.Commands;
using LawСRM.Data.Entities;
using LawСRM.Interfaces;
using LawСRM.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace LawСRM.ViewModels
{
    internal class MainWindowViewModel:ViewModel
    {
        private readonly IDbWorker<Admin> _admin;
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
        public MainWindowViewModel(IDbWorker<Data.Entities.Admin> admin) 
        {
            CloseApplicationCommand = new MainCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            _admin= admin;
            var admins = admin.Items.Take(1).ToArray();
        }
        
    }
}
