using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using AndroidX.Fragment.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Threading;
using AndroidX.DrawerLayout.Widget;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Hosting;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Controls.Hosting;
using Telerik.Maui.Controls;
using Telerik.Maui.Controls.Compatibility;
using RadComboBoxSample;

namespace RadComboBoxSample
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_main);

                var builder = MauiApp.CreateBuilder();
                builder.UseMauiEmbedding<App>();
                builder.UseMauiApp<App>()
                    .UseTelerik();

                var mauiApp = builder.Build();

                var mauiContext = new MauiContext(mauiApp.Services, this);

                var mainPage = new MainPage();

                var mauiView = mainPage.ToPlatform(mauiContext);

                SetContentView(mauiView);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}