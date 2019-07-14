using System.Collections.ObjectModel;
using Gorchun.UI.UIModels;
using Gorchun.UI.Commands;

namespace Gorchun.UI.ViewModels
{
    public class NewElementWindowViewModel : BaseViewModel
    {
        public RelayCommand AddCommand { get; set; }

        protected override string CurrentWindowName => "NewElementW";

        private MaterialsManager _manager;

        public NewElementWindowViewModel()
        {
            AddCommand = new RelayCommand(AddNew, CanAddNew);
            _manager = new MaterialsManager();
        }

        private void AddNew(object parameter)
        {
            object arg = parameter;
        }

        private bool CanAddNew(object parameter)
        {
            return true;
        }
    }
}
