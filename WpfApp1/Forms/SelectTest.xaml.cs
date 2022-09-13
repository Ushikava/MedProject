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
using Core;

namespace TestV
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class TestSelector : Window
    {
        private Patient patient;
        private Test test = Test.EMPTY;
        public TestSelector(Patient pt)
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
        private void Tests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tests.SelectedItem == null)
                return;
            var testGuid = (Tests.SelectedItem as TestInfo).GUID;

            test = JsonWork.LoadTest(testGuid);
            UpdateTestUI(test);
        }

        private void UpdateTestUI(Test tst)
        {
            TestNameLbl.Content = tst.Name;
            TestDescrTB.Text = tst.Description;
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
