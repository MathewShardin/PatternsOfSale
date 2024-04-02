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
        private long _totalTime;

        [ObservableProperty]
        private Assignment? _assignment;

        [ObservableProperty]
        private List<ItemInterface> _pickedItems;
        public MainPageViewModel(GameManager gameManager) : base(gameManager)
        {
            this.Score = 0;
            this.Time = 100;
            this.Assignment = null;
            this.PickedItems = new List<ItemInterface> { };
            this.TotalTime = 2000;
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
