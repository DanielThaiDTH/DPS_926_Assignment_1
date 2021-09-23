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
    public static class Page_Prop
    {
        public static double Page_font { get; set; } = 25;
    }
    public partial class MainPage : ContentPage
    {
        private String cur_item_name;
        private int cur_item_idx = 0;
        private int total_items;
        private Decimal total;
        private List<Button> num_buttons = new List<Button>();
        ObservableCollection<Item> items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get
            {
                return items;
            }
        }

        public MainPage()
        {
            CreateInventory();
            cur_item_name = items[cur_item_idx].Name;
            total = 0;
            InitializeComponent();
            ItemName.Text = cur_item_name;
            Quantity.Text = items[cur_item_idx].Quantity.ToString();
            Total.Text = total.ToString();
            SetUpButtons();
            Inventory.ItemsSource = items;
        }

        private void CreateInventory()
        {
            AddItem(new Item("Pants", Convert.ToDecimal(55.50), 20));
            AddItem(new Item("Shoes", Convert.ToDecimal(80.99), 20));
            AddItem(new Item("Pants", Convert.ToDecimal(10), 10)); //Test adding same item
            AddItem(new Item("Glasses", Convert.ToDecimal(230.30), 5));
            AddItem(new Item("T-Shirt", Convert.ToDecimal(70), 40));
            AddItem(new Item("Jacket", Convert.ToDecimal(179.99), 20));
            AddItem(new Item("Scarf", Convert.ToDecimal(25.50), 50));
            AddItem(new Item("Baseball Cap", Convert.ToDecimal(49.97), 50));
            total_items = items.Count;
        }

        private void AddItem(Item it)
        {
            if (items.Contains(it))
            {
                items[items.IndexOf(it)].Quantity += it.Quantity;
            } else
            {
                items.Add(it);
            }

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
            }
            
            foreach (Button bt in num_buttons)
            {
                bt.FontSize = Page_Prop.Page_font;
                bt.CornerRadius = 5;
            }
        }

        public void TextCell_Tapped(object sender, EventArgs e)
        {
            TextCell selected = (TextCell) sender;
            cur_item_name = selected.Text;
            cur_item_idx = items.IndexOf( items.First<Item>(it => it.Name.Equals(selected.Text)) );
            ItemName.Text = cur_item_name;
            Quantity.Text = items[cur_item_idx].Quantity.ToString();
        }
    }
}
