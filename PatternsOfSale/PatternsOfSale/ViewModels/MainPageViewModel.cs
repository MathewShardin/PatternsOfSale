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
        private ItemInterface _item;

        [ObservableProperty]
        private List<ItemInterface> _pickedItems;
        public MainPageViewModel(GameManager gameManager) : base(gameManager)
        {
            Score = 0;
            Time = 100;
            Assignment = new Assignment();
            PickedItems = new List<ItemInterface> { };
            TotalTime = 2000;
            Assignment.AddDishes(4);
            Item = new PastaItem();
        }

        [RelayCommand]
        private async Task StartGame()
        {
            GameManager.StartGame();
            Score = GameManager.Kitchen.Score;
            Assignment = GameManager.Kitchen.CurrentCustomer.assignment;
            Time += 1;
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
