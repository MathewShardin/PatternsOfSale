using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsOfSale.ViewModels
{
    public class ViewModel : ObservableObject
    {
        public GameManager GameManager { get; private set; }

        protected ViewModel(GameManager gameManager) {
            this.GameManager = gameManager;
        }
    }
}
