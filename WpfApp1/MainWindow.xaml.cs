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
        public List<Test.PatientInfo> Patients { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            ReloadPatientIfoList();
        }

        public void ReloadPatientIfoList()
        {
            Patients = Test.JsonWork.LoadListOfPatientInfo();
            grid.ItemsSource = Patients;
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Guid guid = (e.AddedItems[0] as Test.PatientInfo).GUID;
                LoadPatientDescr(guid);
            }
        }

        private void LoadPatientDescr(Guid guid)
        {
            var pt = Test.JsonWork.LoadPatient(guid);

            Descr.Text = pt.patient.Description;

            TestResults.Text = "";
            foreach (var test_res in pt.testResult)
            {

                TestResults.Text += $"\n[{test_res.completeTime}]\n";
                TestResults.Text += $"{test_res.TestName} {test_res.diagnosis}\n";

                foreach (var tag in test_res.results)
                    TestResults.Text += $"\t{tag.Tag}: {tag.Result}\n";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test.Patient patient = new Test.Patient();


            Patients.Add(patient.GetPatientCut());

            Test.JsonWork.SaveListOfPatientInfo(Patients);
            Test.JsonWork.SavePatient(patient, new List<Test.TestResult>());
            ReloadPatientIfoList();
        }
    }
}
