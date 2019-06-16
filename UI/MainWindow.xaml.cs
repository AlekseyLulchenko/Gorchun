using System.Collections.Generic;
using System.Windows;
using Gorchun.Core.Models;
using Gorchun.DataBase;
using Gorchun.UI.ViewModels;

namespace Gorchun.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MaterialsProvider provider = new MaterialsProvider();
			//provider.FillWithTestData(100);
			List<Material> all = provider.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cas = this.TextInput.Value;
        }
    }
}
