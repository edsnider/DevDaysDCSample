using DevDaysDCSample.ViewModels;
using Xamarin.Forms;

namespace DevDaysDCSample.Views
{
    public partial class MainView : ContentPage
    {
        private MainViewModel _vm => BindingContext as MainViewModel;

        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_vm == null || _vm.IsBusy || _vm.Venues.Count < 0)
                return;

            _vm.RefreshCommand.Execute(null);
        }
    }
}
