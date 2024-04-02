using PatternsOfSale.ViewModels;

namespace PatternsOfSale.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}
