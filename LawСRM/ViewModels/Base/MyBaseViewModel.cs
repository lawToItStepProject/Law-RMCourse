using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LawСRM.ViewModels.Base
{
    internal abstract class MyBaseViewModel : INotifyPropertyChanged
    {
        //реализация события из интерйейса INotifyPropertyChanged, оповещает об изменении свойства
        public event PropertyChangedEventHandler PropertyChanged;

        //метод, вызывающий событие PropertyChanged и уведомляющий об изменени конкретного свойства через его имя
        //параметр [CallerMemberName]string PropertyName=null можно не передавать, он будет самостоятельно определяться компилятором
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        //Метод, предназначенный для установки значения свойства
        //Решает задачу "разрешения" кольцевого изменения свойств, когда изменение одного свойства влияет на автоизменение другого и т.д.
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    

    }
}
