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
    public partial class MainPageViewModel : ViewModel, TimerInterface
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

        private GameTimer Timer;

        private GameManager GameManager;

        //[ObservableProperty]
        //private ObservableCollection<String>

        public MainPageViewModel(GameManager gameManager, GameTimer timer)
        {
            Items = new ObservableCollection<string>();
            PickedItemsString = new ObservableCollection<string>();
            Score = 0;
            Time = 0;
            Assignment = new Assignment();
            PickedItems = new List<ItemInterface> { };
            TotalTime = 0;
            Timer = timer;
            GameManager = gameManager;
        }

        [RelayCommand]
        private async Task StartGame()
        {
            GameManager.StartGame();
            Timer.AddSubscriber(this);
            UpdateValues();
            Time += 1;
            AddAssignmentsToList();
        }

        private void UpdateValues()
        {
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
            GameManager.Kitchen.DishPickUpStation = PickedItems;
            ClearPickedItemList();
            GameManager.Submit();
            UpdateValues();
            AddAssignmentsToList();
            
        }

        [RelayCommand]
        private async Task BurgerButton()
        {
            PickedItems.Add(new BurgerItem());
            PickedItemsString.Add("Burger");
        }

        [RelayCommand]
        private async Task PastaButton()
        {
            PickedItems.Add(new PastaItem());
            PickedItemsString.Add("Pasta");
        }

        [RelayCommand]
        private async Task BeerButton()
        {
            PickedItems.Add(new BeerItem());
            PickedItemsString.Add("Beer");
        }

        [RelayCommand]
        private async Task ColaButton()
        {
            PickedItems.Add(new ColaItem());
            PickedItemsString.Add("Cola");
        }

        private void AddAssignmentsToList()
        {
            Items.Clear();
            foreach (ItemInterface item in Assignment.DishAssignment)
            {
                String cleanName = item.GetType().Name.Substring(0, item.GetType().Name.Length - 4);
                Items.Add(cleanName);
            }
        }

        private void ClearPickedItemList()
        {
            PickedItemsString.Clear();
        }

        public void UpdateTime(long timestamp)
        {
            Time = GameManager.TimeSinceLastOrder;
            TotalTime = GameManager.TimePlayed;
        }
    }
}
