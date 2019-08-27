﻿using System;
using Xamarin.Forms;

namespace DataExample.GlobalMethods
{
    public static class Globals
    {

        public static async void PopAsync_Button(object sender, EventArgs e)
        {
            //Global back button functionality
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}