using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DPS_926_Assignment_1
{
    public static class Page_Prop
    {
        public static double Page_font { get; set; } = 25;
    }
    public partial class MainPage : ContentPage
    {
        private String cur_item_name;
        private Decimal total;
        private List<Button> num_buttons = new List<Button>();
        public MainPage()
        {
            cur_item_name = "[item_name]";
            total = 0;
            InitializeComponent();
            ItemName.Text = cur_item_name;
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
            }
            
            foreach (Button bt in num_buttons)
            {
                bt.FontSize = Page_Prop.Page_font;
            }
        }
    }
}
