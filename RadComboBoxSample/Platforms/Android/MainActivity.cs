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
using RadSegmentedControlSample;
using RadSegmentedControlSample.Platforms.Android;

namespace RadSegmentedControlSample
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : FragmentActivity
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
                    .UseTelerik()
                    .UseTelerikControls();
////uncomment to see working with workaround.
//.ConfigureMauiHandlers((handlers) =>
//                                         {
//#if __ANDROID__
//                                             handlers.AddHandler(typeof(RadSegmentedControl), typeof(Telerik.Maui.RadSegmentedControlHandler));
//#endif
//                                         });

                var mauiApp = builder.Build();

                var mauiContext = new MauiContext(mauiApp.Services, this);

                var mainPage = new MainPage();

                AndroidX.Fragment.App.Fragment fragment = mainPage.CreateSupportFragment(mauiContext);

                SupportFragmentManager.BeginTransaction().SetReorderingAllowed(true).Add(Resource.Id.fragment_container_view, fragment, null).Commit();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}