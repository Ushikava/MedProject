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
        public int Value
        {
            get => int.Parse(textBox.Text);
            set => textBox.Text = value.ToString();
        }

        public RateVariant(int index, Core.QuestionRateAnswer question)
        {
            InitializeComponent();
            textBlock.Text = question.Variants[index];
            textBox.TextChanged += TextBox_TextChanged;
            textBox.TextChanged += (s, e) => ValueChangedEvent?.Invoke(index, Value);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var c = textBox.CaretIndex;

            string str = Regex.Replace(textBox.Text, @"\D*", "");

            if (str.Length > 1 && str.StartsWith('0'))
                str = str.Substring(1);
            if (str == string.Empty)
                str = "0";

            textBox.Text = str;
            textBox.CaretIndex = c;
        }
    }
}
