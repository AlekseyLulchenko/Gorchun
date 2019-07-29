using System.Collections.ObjectModel;
using Gorchun.UI.UIModels;
using Gorchun.UI.Commands;
using System.Windows;
using System;
using System.Linq;


namespace Gorchun.UI.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
        public RelayCommand OpenNewElementWindowCommand { get; set; }
        public RelayCommand DeleteElementCommand { get; set; }

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
            DeleteElementCommand = new RelayCommand(DeleteElement, CanDeleteElement);
        }

        private void DeleteElement(object param)
        {
            if (SelectedMaterial == null)
            {
                MessageBox.Show("выберите элемент!", "Элемент не выбран!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (Materials == null || Materials.Count == 0)
            {
                MessageBox.Show("Список пуст!", "Невозможно удалить элемент", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            try
            {
                RemoveOneFromDatabase(SelectedMaterial.Cas);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при удалении элемента", "Невозможно удалить элемент", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (RemoveOneFromList(SelectedMaterial.Cas) == false)
            {
                MessageBox.Show("Ошибка при удалении элемента", "Невозможно удалить элемент", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            OnPropertyChanged(nameof(Materials));
        }

        private void RemoveOneFromDatabase(string cas)
        {
            _manager.DeleteById(cas);
        }

        private bool RemoveOneFromList(string cas)
        {
            UiMaterial target = Materials.FirstOrDefault(m => m.Cas == cas);
            if (target == null)
            {
                return false;
            }
            return Materials.Remove(target);
        }

        private bool CanDeleteElement(object param)
        {
            return SelectedMaterial!=null;
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
