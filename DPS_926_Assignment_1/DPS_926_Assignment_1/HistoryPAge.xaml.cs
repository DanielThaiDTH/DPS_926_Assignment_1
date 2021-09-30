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
    public partial class HistoryPage : ContentPage
    {
        ObservableCollection<PurchaseLog> _history;
        public ObservableCollection<PurchaseLog> History
        {
            get { return _history; }
        }
        public HistoryPage(ObservableCollection<PurchaseLog> history)
        {
            InitializeComponent();
            _history = history;
            HistoryView.ItemsSource = _history;
        }

        private void HistoryView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            Navigation.PushAsync(new LogPage(e.SelectedItem as PurchaseLog));
        }
    }
}