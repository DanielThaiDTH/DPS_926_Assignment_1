using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DPS_926_Assignment_1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ObservableCollection<Item> inventory = CreateInventory(new ObservableCollection<Item>());
            MainPage = new MainPage(inventory);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private ObservableCollection<Item> CreateInventory(ObservableCollection<Item> items)
        {
            AddItem(items, new Item("Pants", Convert.ToDecimal(55.50), 20));
            AddItem(items, new Item("Shoes", Convert.ToDecimal(80.99), 20));
            AddItem(items, new Item("Pants", Convert.ToDecimal(10), 10)); //Test adding same item
            AddItem(items, new Item("Glasses", Convert.ToDecimal(230.30), 5));
            AddItem(items, new Item("T-Shirt", Convert.ToDecimal(70), 40));
            AddItem(items, new Item("Jacket", Convert.ToDecimal(179.99), 20));
            AddItem(items, new Item("Scarf", Convert.ToDecimal(25.50), 50));
            AddItem(items, new Item("Baseball Cap", Convert.ToDecimal(49.97), 50));

            return items;
        }

        private void AddItem(ObservableCollection<Item> items, Item it)
        {
            if (items.Contains(it))
            {
                items[items.IndexOf(it)].Quantity += it.Quantity;
            }
            else
            {
                items.Add(it);
            }
        }
    }
}
