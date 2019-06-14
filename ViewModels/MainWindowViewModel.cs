using System.Collections.ObjectModel;
using Gorchun.Core.DataBase;
using Gorchun.Core.Models;

namespace Gorchun.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private ObservableCollection<Material> _materials;
		public ObservableCollection<Material> Materials
		{
			get { return _materials; }
			set
			{
				if (_materials == value) { return; }
				_materials = value;
				OnPropertyChanged(nameof(Materials));
			}
		}


		private string _labelText;
		public string LabelText
		{
			get { return _labelText; }
			set
			{
				if (_labelText == value) { return; }
				_labelText = value;
				OnPropertyChanged(nameof(LabelText));
			}
		}


		public MainWindowViewModel()
		{
			MaterialsProvider provider = new MaterialsProvider();
			Materials = new ObservableCollection<Material>(provider.GetAll());
			LabelText = "Hello! ";
		}
	}
}
