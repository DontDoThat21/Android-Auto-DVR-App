using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Media;
using Android.Support.Design.Widget;
using Android;

namespace DVR_Managing_App.Droid
{
    [Activity(Label = "DVR_Managing_App", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        public const int CameraPermissionsCode = 1;

        public static readonly string[] CameraPermissions =
        {
            Manifest.Permission.Camera
        };

        public static event EventHandler CameraPermissionGranted;
        private View _layout;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            await CrossMedia.Current.Initialize();

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == CameraPermissionsCode && grantResults[0] == Permission.Denied)
            {
                Snackbar.Make(_layout, "Camera permission is denied. Please allow Camera use.", Snackbar.LengthIndefinite)
                    .SetAction("OK", v => RequestPermissions(CameraPermissions, CameraPermissionsCode))
                    .Show();
                return;
            }

            CameraPermissionGranted?.Invoke(this, EventArgs.Empty);
        }
    }
}