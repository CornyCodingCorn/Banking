using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CornUI.Controls
{
    public class BaseINCP : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
