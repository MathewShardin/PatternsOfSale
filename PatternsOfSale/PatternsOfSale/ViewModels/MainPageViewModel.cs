using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatternsOfSale.Models;
using System.Collections.ObjectModel;

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
        private ObservableCollection<String> _items;

        [ObservableProperty]
        private ObservableCollection<String> _pickedItemsString;
        
        [ObservableProperty]
        private List<ItemInterface> _pickedItems;

        //[ObservableProperty]
        //private ObservableCollection<String>

        public MainPageViewModel(GameManager gameManager) : base(gameManager)
        {
            Items = new ObservableCollection<string>();
            PickedItemsString = new ObservableCollection<string>();
            Score = 0;
            Time = 100;
            Assignment = new Assignment();
            PickedItems = new List<ItemInterface> { };
            TotalTime = 2000;
        }

        [RelayCommand]
        private async Task StartGame()
        {
            GameManager.StartGame();
            Score = GameManager.Kitchen.Score;
            Assignment = GameManager.Kitchen.CurrentCustomer.assignment;
            Time += 1;
            AddAssignmentsToList();
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

        private void AddAssignmentsToList()
        {
            Items.Clear();
            foreach (ItemInterface item in Assignment.DishAssignment)
            {
                Items.Add(item.GetType().Name);
            }
            var yes = "";
        }

        private void ClearPickedItemList()
        {
            PickedItemsString.Clear();
        }
    }
}
