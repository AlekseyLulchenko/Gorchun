using System.Windows;
using Gorchun.UI.UIModels;
using Gorchun.UI.Commands;
using System;

namespace Gorchun.UI.ViewModels
{
    public class NewElementWindowViewModel : BaseViewModel
    {
        public RelayCommand AddCommand { get; set; }
        protected override string CurrentWindowName => "WindowNewElement";

        private UiMaterial _currentMaterial;
        public UiMaterial CurrentMaterial
        {
            get
            {
                return _currentMaterial;
            }
            set
            {
                if (_currentMaterial == value) { return; }
                _currentMaterial = value;
                OnPropertyChanged(nameof(CurrentMaterial));
            }
        }

        

        private MaterialsManager _manager;

        public NewElementWindowViewModel()
        {
            AddCommand = new RelayCommand(AddNew, CanAddNew);
            _manager = new MaterialsManager();
            CurrentMaterial = new UiMaterial();
        }

        private void AddNew(object parameter)
        {
            if (string.IsNullOrWhiteSpace(CurrentMaterial.Cas))
            {
                MessageBox.Show("Не задан CAS вещества", "Ошибка добавления элемента", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(CurrentMaterial.Naimenovanie))
            {
                MessageBox.Show("Не задано наименование вещества", "Ошибка добавления элемента", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (_manager.GetById(CurrentMaterial.Cas) != null)
                {
                    MessageBox.Show("Вещество с указанным CAS уже существует", "Ошибка добавления элемента", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _manager.AddNew(CurrentMaterial);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При добавлении вещества возникла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Новое вещество успешно добавлено в базу данных", "Удачно", MessageBoxButton.OK, MessageBoxImage.Information);
            CloseWindowCommand.Execute(null);
        }

        private bool CanAddNew(object parameter)
        {
            return true;
        }
    }
}
