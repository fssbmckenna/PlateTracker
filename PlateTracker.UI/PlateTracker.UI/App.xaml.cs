using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PlateTracker.UI.ViewModels;
using PlateTracker.UI.Views;

namespace PlateTracker.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string _uniqueId = "AFC19A5F-82C8-4636-949C-CC9C09B64B72";
        //logger
        //_container
        //private StartupMutex _startupMutex;


        public App()
        {
            //init logger
            //init container
            //configure container
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //set _startupMutex
            base.OnStartup(e);
            Initialize(e);
        }

        private void Initialize(StartupEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //Custom Error Handler

            try
            {
                //get starting Mutex
                //checkLoggingFolders, Temp, etc.
                //start Logger
                //Turn on EF Initialzers

                try
                {
                    //Test DB and other components
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
                
                //Log Starting...
                //Load MainView through container

                var vm = new MainVM();
                var mainView = new MainView(vm);
                mainView.Show();

            }
            catch (Exception ex)
            {
                //Log Error - 
                var error = ex.Message;
            }

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //log + Show Error
        }
    }
}
