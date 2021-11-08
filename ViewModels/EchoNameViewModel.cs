using mvvm1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace mvvm1.ViewModels
{
    public class EchoNameViewModel : INotifyPropertyChanged, IEchoNameViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private EchoName _echoName = new EchoName ();
        public EchoName EchoName 
        {
            get => _echoName;
            set
            {
                _echoName = value;
                OnPropertyChanged();
            }
        }

        public void SaveEchoName (string str)
        {
            EchoName.Name = str;
 

            OnPropertyChanged(nameof(EchoName));
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
