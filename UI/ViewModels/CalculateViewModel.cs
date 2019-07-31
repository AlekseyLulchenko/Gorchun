using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Gorchun.UI.Commands;
using Gorchun.UI.UIModels;

namespace Gorchun.UI.ViewModels
{
    public class CalculateViewModel : BaseViewModel
    {
        private UiMaterial _currentMaterial;

        public UiImpactParameters ImpactParameters { get; set; }

        public RelayCommand CalculateCommand{ get; set; }

        private MaterialsManager _manager;

        protected override string CurrentWindowName => "WindowCalculate";

        public CalculateViewModel(UiMaterial material)
        {
            _currentMaterial = material;
            _manager = new MaterialsManager();
            ImpactParameters = new UiImpactParameters();
            CalculateCommand = new RelayCommand(Calculate, CanCalculate);
        }

        private void Calculate(object param)
        {
            _manager.CalculateImpact(ImpactParameters, _currentMaterial);
            MessageBox.Show("Хуй!", "Информация к размышлению", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool CanCalculate(object param)
        {
            return true;
        }
    }
}
