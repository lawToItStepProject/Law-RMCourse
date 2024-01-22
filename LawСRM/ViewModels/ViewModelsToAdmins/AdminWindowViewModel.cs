//using LawСRM.Commands;
using LawСRM.Data.Entities;
using LawСRM.Interfaces;
using LawСRM.ViewModels.ViewModelsClients;

using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;

using System.Windows;
using System.Windows.Input;

namespace LawСRM.ViewModels.ViewModelsToAdmins
{
    internal class AdminWindowViewModel:ViewModel
    {
        private readonly IDbWorker<IndividualClientProfile> _individualClientProfile;
        //Главная модель сможет изменять это свойство, а дочерняя модель-представляения реагировать на изменение
        private ViewModel _CurrentViewModel;
        public ViewModel CurrentViewModel { get => _CurrentViewModel; set => Set(ref _CurrentViewModel, value); }


        #region Команда для загрузки представления физических лиц
        private ICommand _ShowIndividualViewClientCommand;
        public ICommand ShowIndividualViewClientCommand => _ShowIndividualViewClientCommand
            ??= new LambdaCommand(OnShowIndividualViewClientCommandExecuted, CanShowIndividualViewClientExecute);

        private bool CanShowIndividualViewClientExecute() => true;

        private void OnShowIndividualViewClientCommandExecuted()
        {
            _CurrentViewModel = new IdividualClientsViewModel(_individualClientProfile);
            MessageBox.Show("Команда вызвана");
        }
        #endregion

        //public ICommand _ShowIndividualViewClientCommand2;
        //public ICommand ShowIndividualViewClientCommand2 => _ShowIndividualViewClientCommand2
        //    ??= new LambdaCommand(OnCShowIndividualViewClientCommand2, CanShowIndividualViewClientCommand2);
        //private bool CanShowIndividualViewClientCommand2(object parameter) => true;
        //private void OnCShowIndividualViewClientCommand2(object parameter)
        //{
        //    try
        //    {
        //        _CurrentViewModel = new IdividualClientsViewModel(_individualClientProfile);
        //        MessageBox.Show("Команда2 вызвана");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ошибка");
        //    }
        //}
        public AdminWindowViewModel(IDbWorker<IndividualClientProfile> IndividualClientProfile)
        {
            {  _individualClientProfile = IndividualClientProfile;}
        }
    }

}
