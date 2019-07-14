using System.Collections.ObjectModel;
using Gorchun.UI.UIModels;
using Gorchun.UI.Commands;
using System.Windows;

namespace Gorchun.UI.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
        public RelayCommand OpenNewElementWindowCommand { get; set; }

        protected override string CurrentWindowName => "MainW";

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
                OnPropertyChanged(nameof(SelectedMaterial));
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

            OpenNewElementWindowCommand = new RelayCommand(OpenNewElementWindow, CanOpenNewElementWindow);
        }

        private void OpenNewElementWindow(object param)
        {
            NewElementWindow newElementWindow = new NewElementWindow();
            newElementWindow.Show();
        }

        private bool CanOpenNewElementWindow(object param)
        {
            return true;
        }
    }
}
