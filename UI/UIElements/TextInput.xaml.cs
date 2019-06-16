using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Gorchun.UI.UIElements
{
    /// <summary>
    /// Interaction logic for TextInput.xaml
    /// </summary>
    public partial class TextInput : UserControl
    {
        public TextInput()
        {
            InitializeComponent();
        }

        static TextInput()
        {
            LabelTextProperty = DependencyProperty.Register("LabelText", typeof(string), typeof(TextInput), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnLabelTextChanged)));
            ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(TextInput), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextValuePropertyChanged)));
        }

        public static DependencyProperty LabelTextProperty;
        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }
        private static void OnLabelTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs arg)
        {
            ((TextInput)sender).LabelText = (string)arg.NewValue;
        }

        public static DependencyProperty ValueProperty;
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        private static void OnTextValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs arg)
        {
            ((TextInput)sender).Value = (string)arg.NewValue;
        }
    }
}
