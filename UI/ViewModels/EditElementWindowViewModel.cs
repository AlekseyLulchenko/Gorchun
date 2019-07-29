using System.Windows;
using Gorchun.UI.UIModels;
using Gorchun.UI.Commands;
using System;

namespace Gorchun.UI.ViewModels
{
    public class EditElementWindowViewModel : BaseViewModel
    {
        protected override string CurrentWindowName => "WindowEditElement";
        public UiMaterial CurrentMaterial { get; set; }

        public RelayCommand SaveCommand { get; set; }

        private MaterialsManager _manager;

        public EditElementWindowViewModel(UiMaterial element)
        {
            _manager = new MaterialsManager();
            CurrentMaterial = _manager.GetById(element.Cas);
            SaveCommand = new RelayCommand(Save, CanSaveCommandBeExecuted);
        }

        private void Save(object param)
        {
            if (string.IsNullOrWhiteSpace(CurrentMaterial.Naimenovanie))
            {
                MessageBox.Show("Не задано наименование вещества", "Ошибка редактирования элемента", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _manager.Update(CurrentMaterial);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При редактировании вещества возникла ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Изменения успешно сохранены в базу данных", "Удачно", MessageBoxButton.OK, MessageBoxImage.Information);
            CloseWindowCommand.Execute(null);
        }

        private bool CanSaveCommandBeExecuted(object param)
        {
            return string.IsNullOrWhiteSpace(CurrentMaterial.Naimenovanie) == false;
        }
    }
}
