using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.ViewModels
{
    public partial class MainPageViewModel : ViewModel
    {
        [ObservableProperty]
        private double _score;

        [ObservableProperty]
        private DateTime _time;

        [ObservableProperty]
        private string _order;

        [ObservableProperty]
        private string _pickedItems;
        public MainPageViewModel(GameManager gameManager) : base(gameManager)
        {
            this._score = 0;
            this._time = DateTime.Now;
            this._order = string.Empty;
            this._pickedItems = string.Empty;
        }
    }
}
