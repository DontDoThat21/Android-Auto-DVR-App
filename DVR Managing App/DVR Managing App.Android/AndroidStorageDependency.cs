using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(DVR_Managing_App.Droid.AndroidStorageDependency))]
namespace DVR_Managing_App.Droid
{
    class AndroidStorageDependency
    {
        public long GetStorageRemaining()
        {
            return Android.OS.Environment.ExternalStorageDirectory.TotalSpace;
        }
    }
}