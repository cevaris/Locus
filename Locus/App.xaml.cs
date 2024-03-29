﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Locus.Views;
           
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Locus
{
    public partial class App : Application
    {
        public static bool IsDebug
        {
            get
            {
                bool isDebug;
#if DEBUG
                isDebug = true;
#else
                isDebug = false;
#endif
                return isDebug;
            }
        }

        private static IShared shared;
        public static IShared Shared
        {
            get
            {
                if (shared == null)
                {
                    shared = DependencyService.Get<IShared>();
                }
                return shared;
            }
        }


        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LocusPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
