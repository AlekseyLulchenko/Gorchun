using System.Collections.Generic;
using System.Windows;
using Gorchun.Core.Models;
using Gorchun.DataBase;

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
    }
}
