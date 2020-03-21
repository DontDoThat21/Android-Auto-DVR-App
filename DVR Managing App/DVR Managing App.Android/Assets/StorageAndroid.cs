using System;
using System.Threading.Tasks;
using Android.OS;
using Xamarin.Forms;

namespace DVR_Managing_App.Droid.Assets
{
    public class StorageAndroid
    {
        public Task<UInt64> GetFreeSpace()
        {
            var fullExternalStorage = Android.OS.Environment.ExternalStorageDirectory.TotalSpace;
            var freeExternalStorage = Android.OS.Environment.ExternalStorageDirectory.UsableSpace;

            var fullInternalStorage = Android.OS.Environment.RootDirectory.TotalSpace;
            var freeInternalStorage = Android.OS.Environment.RootDirectory.UsableSpace;



            //Using StatFS
            var path = new StatFs(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));
            long blockSize = path.BlockSizeLong;
            long avaliableBlocks = path.AvailableBlocksLong;
            var produto = (blockSize * avaliableBlocks).ToString();
            return Task.FromResult(UInt64.Parse(produto));
        }
    }
}

