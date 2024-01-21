using LawСRM.Commands;
using LawСRM.Data.Entities;
using LawСRM.Interfaces;
//using LawСRM.ViewModels.Base;
using LawСRM.ViewModels;
using System.Windows;
using System.Windows.Input;
//using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;


namespace LawСRM.ViewModels
{
    internal class MainWindowViewModel:ViewModel
    {
        private readonly IDbWorker<Admin> _admin;
        private readonly IDbWorker<IndividualClientProfile> _individualClientProfile;
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
                MessageBox.Show("Ошибка");
            }
        }
        #endregion

        //Главная модель сможет изменять это свойство, а дочерняя модель-представляения реагировать на изменение
        private ViewModel _CurrentViewModel;
        public ViewModel CurrentViewModel { get => _CurrentViewModel; set => Set(ref _CurrentViewModel, value); }
        
        #region Команда ддля загрузки представления физических лиц
        private ICommand _ShowIndividualViewClientCommand;
        public ICommand ShowIndividualViewClientCommand => _ShowIndividualViewClientCommand
            ??= new MainCommand(OnShowIndividualClientCommandExecuted, CanShowIndividualClientExecute);
        private bool CanShowIndividualClientExecute() => true;
        private void OnShowIndividualClientCommandExecuted()
        {
            _CurrentViewModel = new IdividualClientsViewModel(_individualClientProfile);
        }
        #endregion

        public MainWindowViewModel(IDbWorker<Data.Entities.Admin> admin)
        {
            CloseApplicationCommand = new MainCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            _admin = admin;
            var admins = admin.Items.Take(1).ToArray();
        }

    }
}
