﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DVR_Managing_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {

        public static event EventHandler<ImageSource> PhotoCapturedEvent;

        public SettingsPage()
        {
            InitializeComponent();
        }
    }
}
