//Daniel Thai

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
        HistoryPage historyView; //Will exist for the life of this page
        RestockPage restocker;   //Will exist for the life of this page
        public ManagerPage(ObservableCollection<Item> inventory)
        {
            InitializeComponent();
            _inventory = inventory;
            restocker = new RestockPage(_inventory);
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

        private void Restock_Button_Clicked(object sender, EventArgs e)
        {
            if (restocker != null)
                Navigation.PushAsync(restocker);
        }

        private void Add_Prod_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddProductPage(_inventory));
        }
    }
}