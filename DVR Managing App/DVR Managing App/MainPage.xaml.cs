using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DVR_Managing_App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {       
        
        public long TotalSpacePotential = Android.OS.Environment.ExternalStorageDirectory.TotalSpace;
        public long TotalRemainingSpace = Android.OS.Environment.ExternalStorageDirectory.FreeSpace;

        public MainPage()
        {
            InitializeComponent();
            PopulateDataAsync();
        }

        private async Task PopulateDataAsync()
        {            
            TotalRemainingSpace = Android.OS.Environment.ExternalStorageDirectory.FreeSpace;
            TotalSpacePotential = Android.OS.Environment.ExternalStorageDirectory.TotalSpace;
            
            GBRemainLbl.Text = (Android.OS.Environment.ExternalStorageDirectory.TotalSpace / ‭1000000000‬).ToString(); // bytes to gb
            GBRemainLbl.Text += "GB.";
            await GBPcntBar.ProgressTo(TotalRemainingSpace / TotalSpacePotential, 900, Easing.BounceIn); 
        }

        private void settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private void start_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
