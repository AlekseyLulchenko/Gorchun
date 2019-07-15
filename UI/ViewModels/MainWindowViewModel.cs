using System.Collections.ObjectModel;
using Gorchun.UI.UIModels;
using Gorchun.UI.Commands;
using System.Windows;
using System;

namespace Gorchun.UI.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
        public RelayCommand OpenNewElementWindowCommand { get; set; }
        private MaterialsManager _manager;

        protected override string CurrentWindowName => "WindowMain";

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
            _manager = new MaterialsManager();
            RefreshMainList();
            OpenNewElementWindowCommand = new RelayCommand(OpenNewElementWindow, CanOpenNewElementWindow);
        }

        private void OpenNewElementWindow(object param)
        {
            NewElementWindow newElementWindow = new NewElementWindow();
            newElementWindow.Closed += OnNewElementWindowClosed; 
            newElementWindow.Show();
        }

        private bool CanOpenNewElementWindow(object param)
        {
            return true;
        }

        private void OnNewElementWindowClosed(object sender, EventArgs arg)
        {
            RefreshMainList();
        }

        private void RefreshMainList()
        {
            Materials = new ObservableCollection<UiMaterial>(_manager.GetAll());
        }
    }
}
