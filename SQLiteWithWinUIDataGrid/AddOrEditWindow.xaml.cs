using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SQLiteWithWinUIDataGrid
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddOrEditWindow : Window
    {
        public AddOrEditWindow()
        {
            this.InitializeComponent();
            this.Activated += OnActivated;
        }

        private void OnActivated(object sender, WindowActivatedEventArgs args)
        {
            this.AddEditGrid.DataContext = this.SelectedRecord;
        }

        public Employee SelectedRecord { get; set; }

        private async void OnSaveClick(object sender, RoutedEventArgs e)
        {
            bool isEdit = true;
            if (SelectedRecord == null)
            {
                isEdit = false;
                SelectedRecord = new Employee();
            }

            SelectedRecord.EmployeeID = this.employeeIDTextBox.Value;
            SelectedRecord.Name = this.employeeNameTextBox.Text;
            SelectedRecord.EMail = this.EmployeeMailTextBox.Text;
            SelectedRecord.Gender = this.GenderComboBox.SelectedItem.ToString();
            SelectedRecord.BirthDate = this.EmployeeBirthDatePicker.Date;
            SelectedRecord.Location = this.EmployeeLocationTextBox.Text;

            if (isEdit)
                await App.Database.UpdateEmployeeAsync(SelectedRecord);
            else
                await App.Database.AddEmployeeAsync(SelectedRecord);

            this.Close();
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
