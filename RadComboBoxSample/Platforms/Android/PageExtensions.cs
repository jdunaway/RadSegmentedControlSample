using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Platform;
using Microsoft.Maui;
using Fragment = AndroidX.Fragment.App.Fragment;
using Telerik.Maui.Controls.Compatibility;

namespace RadSegmentedControlSample.Platforms.Android
{
    public static class PageExtensions
    {
        public static Fragment CreateSupportFragment(this ContentPage view, MauiContext context)
        {
            return new ScopedFragment(view, context);
        }

        internal class ScopedFragment : Fragment
        {
            readonly IMauiContext _mauiContext;

            public IView DetailView { get; private set; }

            public ScopedFragment(IView detailView, IMauiContext mauiContext)
            {
                DetailView = detailView;
                _mauiContext = mauiContext;
            }

            public override global::Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                return DetailView.ToPlatform(_mauiContext);
            }
        }
    }
}
