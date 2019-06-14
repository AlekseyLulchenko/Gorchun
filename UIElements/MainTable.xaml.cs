using System.Windows.Controls;


namespace Gorchun.UIElements
{
    /// <summary>
    /// Interaction logic for MyTable.xaml
    /// </summary>
    public partial class MainTable : UserControl
    {
        public MainTable()
        {
            InitializeComponent();
	        DataContext = this;
		}
    }
}
