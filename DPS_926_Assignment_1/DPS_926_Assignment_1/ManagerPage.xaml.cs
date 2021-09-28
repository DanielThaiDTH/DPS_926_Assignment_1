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
        ObservableCollection<PurchaseLog> history;
        HistoryPage historyView;
        public ManagerPage(ObservableCollection<Item> inventory)
        {
            InitializeComponent();
            _inventory = inventory;
        }

        public void RegisterHistory(ObservableCollection<PurchaseLog> purchaseHistory)
        {
            history = purchaseHistory;
            historyView = new HistoryPage(history);
        }

        private void History_Button_Clicked(object sender, EventArgs e)
        {
            if (historyView != null)
                Navigation.PushAsync(historyView);
        }
    }
}