using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gorchun.UIElements
{
    public class TextInputViewModel : BaseViewModel
    {
        private string _labelText;
        public string LabelText
        {
            get
            {
                return _labelText;
            }
            set
            {
                if (value == _labelText) return;
                _labelText = value;
                OnPropertyChanged(nameof(LabelText));
            }
        }
    }
}
