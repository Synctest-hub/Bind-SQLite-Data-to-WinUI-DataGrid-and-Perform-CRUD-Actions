using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SQLiteWithWinUIDataGrid.DataBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;
using Windows.UI.WindowManagement;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SQLiteWithWinUIDataGrid
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.Activated += OnActivated;
        }

        private async void OnActivated(object sender, WindowActivatedEventArgs args)
        {
            if (args.WindowActivationState == WindowActivationState.CodeActivated)
                sfDataGrid.ItemsSource = await App.Database.GetEmployeesAsync();
        }

        private void OnAddMenuClick(object sender, RoutedEventArgs e)
        {
            AddOrEditWindow addWindow = new AddOrEditWindow();
            addWindow.Title = "Add Record";
            App.ShowWindowAtCenter(addWindow.AppWindow, 550, 650);
            addWindow.Activate();
        }

        private void OnEditMenuClick(object sender, RoutedEventArgs e)
        {
            AddOrEditWindow editWindow = new AddOrEditWindow();
            editWindow.Title = "Edit Record";
            editWindow.SelectedRecord = sfDataGrid.SelectedItem as Employee;
            App.ShowWindowAtCenter(editWindow.AppWindow, 550, 650);
            editWindow.Activate();
        }

        private void OnDeleteMenuClick(object sender, RoutedEventArgs e)
        {
            DeleteWindow deleteWindow = new DeleteWindow();
            App.ShowWindowAtCenter(deleteWindow.AppWindow, 200, 500);
            deleteWindow.SelectedRecord = sfDataGrid.SelectedItem as Employee;
            deleteWindow.Activate();
        }
    }
}
