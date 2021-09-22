using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DPS_926_Assignment_1
{
    public partial class MainPage : ContentPage
    {
        public String cur_item_name;
        public static int page_font;
        public Decimal total;
        public MainPage()
        {
            cur_item_name = "[item_name]";
            page_font = 25;
            total = 0;
            InitializeComponent();
            ItemName.FontSize = page_font;
            Total.FontSize = page_font;
            ItemName.Text = cur_item_name;
            Total.Text = total.ToString();
            setUpButtons();
        }

        private void setUpButtons()
        {
            Num0.FontSize = page_font;
            Num1.FontSize = page_font;
            Num2.FontSize = page_font;
            Num3.FontSize = page_font;
            Num4.FontSize = page_font;
            Num5.FontSize = page_font;
            Num6.FontSize = page_font;
            Num7.FontSize = page_font;
            Num8.FontSize = page_font;
            Num9.FontSize = page_font;
            BuyButton.FontSize = page_font;

        }
    }
}
