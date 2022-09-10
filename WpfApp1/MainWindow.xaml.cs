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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Test.PatientInfo> Patients {
            get => Test.JsonWork.LoadListOfPatientInfo();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var t = Test.JsonWork.LoadListOfPatientInfo();
            grid.ItemsSource = t;
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Guid guid = (e.AddedItems[0] as Test.PatientInfo).GUID;

                var pt = Test.JsonWork.GetPatientInfo(guid);

                Descr.Text = pt.patient.Description;

                TestResults.Text = "";
                foreach (var test_res in pt.testResult)
                {

                    TestResults.Text += $"\n[{test_res.completeTime}]\n";
                    TestResults.Text += $"{test_res.name} {test_res.diagnosis}\n";

                    foreach(var tag in test_res.results)
                        TestResults.Text += $"\t{tag.Key}: {tag.Value}\n";
                }

            }
        }
    }
}
