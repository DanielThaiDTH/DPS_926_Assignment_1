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
    public partial class RestockPage : ContentPage
    {
        ObservableCollection<Item> inventory;
        public RestockPage(ObservableCollection<Item> inv)
        {
            inventory = inv;
            InitializeComponent();
            InventoryList.ItemsSource = inventory;
        }


        public bool isValid()
        {
            if (inventory != null)
                return true;
            else
                return false;
        }


        private static bool validNumber(string text)
        {
            if (text == null)
                return false;

            try
            {
                int num = (int) Convert.ToUInt32(text);
            } catch (Exception)
            {
                return false;
            }

            return true;
        }


        private void RestockButton_Clicked(object sender, EventArgs e)
        {
            if (InventoryList.SelectedItem == null || !RestockPage.validNumber(QtyEnter.Text))
            {
                DisplayAlert("Error", "You have to select an item and provide a quantity.", "OK");
            } else
            {
                (InventoryList.SelectedItem as Item).Quantity += Convert.ToInt32(QtyEnter.Text);
            }
        }

        private void CancelRestock_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            QtyEnter.Text = "";
            InventoryList.SelectedItem = null;
        }
    }
}