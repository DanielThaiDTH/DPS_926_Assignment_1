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
    public partial class AddProductPage : ContentPage
    {
        Item newProduct;
        ObservableCollection<Item> inventory;
        public AddProductPage(ObservableCollection<Item> inv)
        {
            inventory = inv;
            InitializeComponent();
        }

        /*Handles saving a new product. It ensures that all fields are filled in and 
         with the price and quantity being positive numbers. It also checks to see if 
         the new item is not already in the inventory. Once saved, it will go back to 
         the Manager page.*/
        private void saveClicked(object sender, EventArgs e)
        {
            decimal price;
            int qty;
            string name = NameEntry.Text;

            if (name == null || name.Length == 0)
            {
                DisplayAlert("Error", "No product name provided.", "OK");
                return;
            }

            try
            {
                price = Convert.ToDecimal(PriceEntry.Text);
            } catch (Exception)
            {
                DisplayAlert("Error", "Price entered is not a proper number.", "OK");
                return;
            }

            try
            {
                qty = (int) Convert.ToUInt32(QtyEntry.Text);
            }
            catch (Exception)
            {
                DisplayAlert("Error", "Quantity should be a positive whole number.", "OK");
                return;
            }

            newProduct = new Item(name, price, qty);

            if (inventory.Contains(newProduct))
            {
                DisplayAlert("Error", "Product already exists in inventory.", "OK");
                return;
            } else if (price <= 0) {
                DisplayAlert("Error", "Price must be greater than 0.", "OK");
                return;
            } else
            {
                inventory.Add(newProduct);
                Navigation.PopAsync();
                DisplayAlert("Done!", "New product added successfully.", "OK");
            }
        }

        private void cancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}