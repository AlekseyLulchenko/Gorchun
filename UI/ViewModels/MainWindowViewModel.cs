using System.Collections.ObjectModel;
using Gorchun.DataBase;
using Gorchun.UI.UIModels;

namespace Gorchun.UI.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
        private UiMaterial _selectedMaterial;
        public UiMaterial SelectedMaterial
        {
            get
            {
                return _selectedMaterial;
            }
            set
            {
                if (_selectedMaterial == value) { return; }
                _selectedMaterial = value;
                OnPropertyChanged(nameof(_selectedMaterial));
            }
        }

		private ObservableCollection<UiMaterial> _materials;
		public ObservableCollection<UiMaterial> Materials
		{
			get { return _materials; }
			set
			{
				if (_materials == value) { return; }
				_materials = value;
				OnPropertyChanged(nameof(Materials));
			}
		}


		public MainWindowViewModel()
		{
            MaterialsManager manager = new MaterialsManager();
			Materials = new ObservableCollection<UiMaterial>(manager.GetAll());
		}
	}
}
