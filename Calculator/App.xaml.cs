using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Calculator.ViewModels;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            // Create the ViewModel and expose it using the View's DataContext
            Views.CalculatorView view = new Views.CalculatorView();
            view.DataContext = new ViewModels.CalculatorViewModel();
            view.Show();
        }
    }
}
