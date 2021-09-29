//Daniel Thai

using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace DPS_926_Assignment_1
{
    //Static page properties
    public static class Page_Prop
    {
        public static double Page_font { get; set; } = 25;
    }

    public partial class MainPage : ContentPage
    {
        private Item cur_item;
        private int cur_item_idx = 0;
        private int total_items;
        private Decimal total;
        private List<Button> num_buttons = new List<Button>();
        private List<int> digits = new List<int>();
        private Dictionary<string, int> but_vals = new Dictionary<string, int>();
        ManagerPage ManagerChildPage = null;
        ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
        {
            get
            {
                return items;
            }
        }

        ObservableCollection<PurchaseLog> history;

        public MainPage(ObservableCollection<Item> inventory, ManagerPage mp)
        {
            ManagerChildPage = mp;
            items = inventory;
            history = new ObservableCollection<PurchaseLog>();
            ManagerChildPage.RegisterHistory(history);
            total_items = items.Count;
            cur_item = items[cur_item_idx];
            total = 0;

            InitializeComponent();

            Inventory.ItemsSource = items;
            ItemName.Text = cur_item.Name;
            Quantity.Text = "0";
            Total.Text = total.ToString();
            SetUpButtons();
        }
            

        private void SetUpButtons()
        {
            if (num_buttons.Count == 0)
            {
                num_buttons.Add(Num0);
                num_buttons.Add(Num1);
                num_buttons.Add(Num2);
                num_buttons.Add(Num3);
                num_buttons.Add(Num4);
                num_buttons.Add(Num5);
                num_buttons.Add(Num6);
                num_buttons.Add(Num7);
                num_buttons.Add(Num8);
                num_buttons.Add(Num9);

                but_vals.Add(Num0.Text, 0);
                but_vals.Add(Num1.Text, 1);
                but_vals.Add(Num2.Text, 2);
                but_vals.Add(Num3.Text, 3);
                but_vals.Add(Num4.Text, 4);
                but_vals.Add(Num5.Text, 5);
                but_vals.Add(Num6.Text, 6);
                but_vals.Add(Num7.Text, 7);
                but_vals.Add(Num8.Text, 8);
                but_vals.Add(Num9.Text, 9);
            }
            
            foreach (Button bt in num_buttons)
            {
                bt.FontSize = Page_Prop.Page_font;
                bt.CornerRadius = 5;
            }
        }

        //Sets the current selected item when tapped on the list
        public void TextCell_Tapped(object sender, EventArgs e)
        {
            TextCell selected = (TextCell) sender;
            cur_item = items.First<Item>(it => it.Name.Equals(selected.Text));
            cur_item_idx = items.IndexOf(cur_item);
            ItemName.Text = cur_item.Name;
            total = total_items * cur_item.Price;
            Total.Text = total.ToString();
        }

        //Updates the total selected when a number pad button is clicked
        private void Num_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (digits.Count >= 9) //prevent integer overflow
            {
                DisplayAlert("Quantity Too Large", "Entered quantity is too large", "Close");
                return;
            } else if (digits.Count == 0 && but_vals[button.Text] == 0)
            {
                return; //Do nothing when 0 is the first button clicked.
            }

            digits.Add(but_vals[button.Text]);

            total_items = 0;
            for (int i = 0; i < digits.Count; i++)
            {
                total_items += (int) Math.Pow(10, (digits.Count - i - 1)) * digits[i];
            }

            Quantity.Text = total_items.ToString();
            total = total_items * cur_item.Price;
            Total.Text = total.ToString();
        }

        private void BuyButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (cur_item.Quantity < total_items)
            {
                DisplayAlert("Quantity Too Large",
                    "Number of " + cur_item.Name + "s selected is more than what is in inventory.", "Close");
            } else if (total_items == 0)
            {
                return;
            } else
            {
                cur_item.Quantity -= total_items;
                history.Add(new PurchaseLog(cur_item.Name, total_items * cur_item.Price, total_items, DateTime.Now));
            }

            total_items = 0;
            total = 0;
            Quantity.Text = "0";
            Total.Text = "0";
            digits.Clear();
        }

        private void ManagerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(ManagerChildPage);
        }
    }
}
