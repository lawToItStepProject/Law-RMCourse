using LawСRM.Data.Entities;
using LawСRM.Interfaces;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.ViewModels.ViewModelsClients;

internal class IdividualClientsViewModel : ViewModel
{
    public readonly IDbWorker<IndividualClientProfile> _IndividualClientProfile;
    public IdividualClientsViewModel(IDbWorker<IndividualClientProfile> individualClientProfile)
    {
        _IndividualClientProfile = individualClientProfile;
    }


}
