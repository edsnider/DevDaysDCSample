using System.ComponentModel;
using System.Runtime.CompilerServices;
using DevDaysDCSample.Annotations;

namespace DevDaysDCSample.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isBusy; 
        public bool IsBusy 
        { 
            get { return _isBusy; } 
            set 
            { 
                _isBusy = value; 
                OnPropertyChanged(); 
            } 
        } 

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
