using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DPS_926_Assignment_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogPage : ContentPage
    {
        PurchaseLog pLog;
        public PurchaseLog PurchaseLog
        {
            get { return pLog; }
        }
        public string TotalMsg
        {
            get
            {
                return "Total Amount: " + pLog.Total.ToString("C", CultureInfo.CurrentCulture.NumberFormat);
            }
        }
        public LogPage(PurchaseLog log)
        {
            pLog = log;
            InitializeComponent();
            LogLayout.BindingContext = this;
        }
    }
}