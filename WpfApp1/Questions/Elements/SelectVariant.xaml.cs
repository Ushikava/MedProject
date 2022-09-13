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

namespace TestV.Questions.Elements
{
    /// <summary>
    /// Логика взаимодействия для SelectVariant.xaml
    /// </summary>
    public partial class SelectVariant : UserControl, Variant
    {
        public event ValueChangedHandler ValueChangedEvent;
        public int Value
        {
            get => checkBox.IsChecked.Value ? 1 : 0;
            set => checkBox.IsChecked = value != 0;
        }

        public SelectVariant(int index, Core.Question question)
        {
            InitializeComponent();
            checkBox.Content = question.Variants[index];
            checkBox.Click += (s, e) => ValueChangedEvent?.Invoke(index, Value);
        }
        
    }
}
