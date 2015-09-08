using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Parse;
using ToDoDemo.Helpers;
using ToDoDemo.Common;
using System.Threading.Tasks;

namespace ToDoDemo {
    sealed partial class App : BootStrapper {
        public App() : base() {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();

          ParseClient.Initialize(Constants.ParseAppKey, Constants.ParseNetKey);
        }

        // FIRST!
        public override Task OnInitializeAsync() {
            // Sets Frame to Shell (with Splitview and singleton RootFrame as Content)
            Window.Current.Content = new Views.Shell(base.RootFrame);
            return base.OnInitializeAsync();
        }

        // SECOND
        public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args) {
            // Navigate RootFrame to first page
            (App.Current as App).NavigationService.Navigate(typeof(Views.LoginPage));
            return base.OnInitializeAsync();
        }
        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        //protected override void OnLaunched(LaunchActivatedEventArgs e)
        //{
        //    Frame rootFrame = Window.Current.Content as Frame ?? new Frame();
        //    rootFrame.Navigate(typeof(Views.LoginPage), e.Arguments);
        //    Window.Current.Content = new Views.Shell(rootFrame);
        //    Window.Current.Activate();


        //}
    }
}
