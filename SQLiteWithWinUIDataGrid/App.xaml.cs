using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using SQLiteWithWinUIDataGrid.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SQLiteWithWinUIDataGrid
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MDAxQDMyMzQyZTMwMmUzMEdudGcxQ1EvZkF6TW1xcXJlM3p2dC92cjZQaEtqbklYSDQvbUdTdTRndGs9");
            this.InitializeComponent();
        }

        static SQLiteDatabase database;

        // Create the database connection as a singleton.
        public static SQLiteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteDatabase();
                }
                return database;
            }
        }

        public static Window MainWindow
        {
            get
            {
                return m_window;
            }
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            ShowWindowAtCenter(m_window.AppWindow, m_window.AppWindow.ClientSize.Height, m_window.AppWindow.ClientSize.Width);
            m_window.Activate();
        }

        public static void ShowWindowAtCenter(AppWindow appWindow, int height, int width)
        {
            var a = DisplayArea.Primary;
            if (a != null)
            {
                var outerBounds = a.WorkArea;

                var midtY = outerBounds.Height / 2;
                var startY = midtY - (height / 2);

                if (startY < 0)
                    startY = 0;

                var midtX = outerBounds.Width / 2;
                var startX = midtX - (width / 2);

                if (startX < 0)
                    startX = 0;

                appWindow.MoveAndResize(new Windows.Graphics.RectInt32((int)startX, (int)startY, width, height));
            }
        }

        private static Window m_window;
    }
}
