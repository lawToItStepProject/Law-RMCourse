using LawСRM.ViewModels.ViewModelsToAdmins;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel=>App.Services.GetRequiredService<MainWindowViewModel>();
        //public AdminWindowViewModel AdminWindowViewModel=>App.Services.GetRequiredService<AdminWindowViewModel>();
    }
}
