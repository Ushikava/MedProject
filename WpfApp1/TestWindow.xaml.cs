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
using System.Windows.Shapes;
using Test;

namespace TestV
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private Patient patient;
        public TestWindow(Patient pt)
        {
            patient = pt;
            InitializeComponent();
            Title = $"Тестирование [{patient.F_Name} {patient.L_Name}]";
            UpdateTestList();
        }

        private void UpdateTestList()
        {
            Tests.ItemsSource = JsonWork.LoadTestInofList();
            Tests.SelectedIndex = 0;
        }
    }
}
