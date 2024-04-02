using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternsOfSale.Models;

namespace PatternsOfSale.ViewModels
{
    public partial class MainPageViewModel : ViewModel
    {
        [ObservableProperty]
        private double _score;

        [ObservableProperty]
        private long _time;

        [ObservableProperty]
        private Assignment? _assignment;

        [ObservableProperty]
        private List<ItemInterface> _pickedItems;
        public MainPageViewModel(GameManager gameManager) : base(gameManager)
        {
            this._score = 0;
            this._time = 0;
            this._assignment = null;
            this._pickedItems = new List<ItemInterface> { };
        }

        [RelayCommand]
        private async Task StartGame()
        {
            GameManager.StartGame();
            Score = GameManager.Kitchen.Score;
            Assignment = GameManager.Kitchen.CurrentCustomer.assignment;
        }

        [RelayCommand]
        private async Task StopGame()
        {
            GameManager.StopGame();

        }

        [RelayCommand]
        private async Task Submit()
        {
            GameManager.Submit();
            Score = GameManager.Kitchen.Score;
        }
    }
}
