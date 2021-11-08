using mvvm1.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace mvvm1.ViewModels
{
    public interface IEchoNameViewModel
    {
       EchoName  EchoName { get; set; }
        
        event PropertyChangedEventHandler PropertyChanged;

        void SaveEchoName(string str);
    }
}


