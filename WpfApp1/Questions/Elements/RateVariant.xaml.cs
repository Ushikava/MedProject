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

using Regex = System.Text.RegularExpressions.Regex;

namespace TestV.Questions.Elements
{
    /// <summary>
    /// Логика взаимодействия для RateVariant.xaml
    /// </summary>
    public partial class RateVariant : UserControl, Variant
    {
        public event ValueChangedHandler ValueChangedEvent;
        private int maxValue = int.MaxValue;
        private int minValue = 0;
        private int curValue = 0;
        public int Value
        {
            get => curValue;
            set => curValue = value;
        }

        public RateVariant(int index, Core.QuestionRateAnswer question)
        {
            InitializeComponent();
            maxValue = question.MaxRate;
            minValue = question.MinRate;
            textBlock.Text = question.Variants[index];

            foreach (var cont in QuestionPanel.Children)
            {
                if (cont is RadioButton)
                {
                    (cont as RadioButton).Checked += (s, e) => ValueChangedEvent?.Invoke(index, Value);
                }
            }
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb != null)
            {
                tb.SelectAll();
            }
        }

        private void textBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb != null)
            {
                if (!tb.IsKeyboardFocusWithin)
                {
                    e.Handled = true;
                    tb.Focus();
                }
            }
        }

        private void Answer_changed(object sender, RoutedEventArgs e)
        {
            string str = (sender as RadioButton).Name.ToString().Split('_').Last();
            curValue = int.Parse(str);
        }
    }
}
