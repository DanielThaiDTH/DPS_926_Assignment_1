using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DPS_926_Assignment_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManagerPage : ContentPage
    {
        ObservableCollection<Item> _inventory;
        ObservableCollection<PurchaseLog> history = null;
        public ManagerPage(ObservableCollection<Item> inventory)
        {
            InitializeComponent();
            _inventory = inventory;
        }

        public void RegisterHistory(ObservableCollection<PurchaseLog> purchaseHistory)
        {
            history = purchaseHistory;
        }
    }
}