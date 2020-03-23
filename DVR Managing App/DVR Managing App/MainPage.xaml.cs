using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.TextToSpeech;
using System.Threading;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Java.Security;

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
            CrossTextToSpeech.Current.Speak("BEEEEEP SKEET BEEEEEP", null, 2.0f, 2, 1, default);
            PopulateDataAsync();
        }

        private async Task PopulateDataAsync()
        {
            //CrossTextToSpeech.Current.Speak("Recording Started", null, 1, 1.1f, 1, default);

            TotalRemainingSpace = Android.OS.Environment.ExternalStorageDirectory.FreeSpace;
            TotalSpacePotential = Android.OS.Environment.ExternalStorageDirectory.TotalSpace;

            double spaceInGB = TotalSpacePotential - TotalRemainingSpace;

            double spaceInPercent = spaceInGB / TotalSpacePotential;

            spaceInGB = spaceInGB / 1000000000; //sInGB /= 1000000000;

            spaceInGB = double.Parse(spaceInGB.ToString().Substring(0, 5));

            bool continueRecording = true;
            if (spaceInGB < 5)
            {
                if (spaceInGB < 2)
                {
                    continueRecording = false;
                    await CrossTextToSpeech.Current.Speak("Less than 2 gigabytes remaining, not going to record.", null, 1, 1.05f, 1, default);
                }
                else
                {
                    await CrossTextToSpeech.Current.Speak("Less than five GB remaining.", null, 1, 1.1f, 1, default);
                }
            }

            GBRemainLbl.Text = spaceInGB.ToString(); // bytes to gb
            GBRemainLbl.Text += " GB";
            await GBPcntBar.ProgressTo(spaceInPercent, 900, Easing.BounceIn);

            if (continueRecording == true)
            {
                StartRecording();
            }
        }

        private async void StartRecording()
        {
            bool isAvail = CrossMedia.Current.IsCameraAvailable;
            bool isTakePhotoSupported = CrossMedia.Current.IsTakePhotoSupported;
            bool isTakeVideoSupported = CrossMedia.Current.IsTakeVideoSupported;
            bool isPickVideoSupported = CrossMedia.Current.IsPickVideoSupported;

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera detected.", ":( Sorry no cam.", "OK");
                return;
            }

            await CrossPermissions.Current.RequestPermissionsAsync(new[] { Plugin.Permissions.Abstractions.Permission.Camera });

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",     
                CompressionQuality = 92,
                Name = "testafrica1212111.jpg"
            });

            DisplayAlert("File loc", file.Path, "OK");


        }

        private void settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private void start_Clicked(object sender, EventArgs e)
        {
            PopulateDataAsync();
        }
    }
}
