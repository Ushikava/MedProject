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
using Test;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Test.PatientInfo> Patients { get; private set; }
        private Patient selectedPAtient;

        public MainWindow()
        {
            InitializeComponent();
            ReloadPatientIfoList();
        }

        public void ReloadPatientIfoList()
        {
            Patients = JsonWork.LoadListOfPatientInfo();
            grid.ItemsSource = Patients;
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Guid guid = (e.AddedItems[0] as PatientInfo).GUID;
                try
                {
                    selectedPAtient = JsonWork.LoadPatient(guid);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"Ошибка при загрузке пациента [{ex.Message}]");
                    selectedPAtient = Patient.EMPTY;
                    selectedPAtient.GUID = guid;
                }
                UpdatePatientDescr(selectedPAtient);
            }
        }

        private void UpdatePatientDescr(Patient pt)
        {
            Descr.Text = pt.Description;

            TestResults.Text = "";
            foreach (var test_res in pt.TestResults)
            {

                TestResults.Text += $"\n[{test_res.completeTime}]\n";
                TestResults.Text += $"{test_res.TestName} {test_res.diagnosis}\n";

                foreach (var tag in test_res.results)
                    TestResults.Text += $"\t{tag.Tag}: {tag.Result}\n";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = Program.CreateExamplePatient();


            Patients.Add(patient.GetPatientCut());

            JsonWork.SaveListOfPatientInfo(Patients);
            JsonWork.SavePatient(patient);
            ReloadPatientIfoList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Patients.RemoveAll( x => x.GUID == selectedPAtient.GUID);
            JsonWork.DeletePatient(selectedPAtient.GUID);
            JsonWork.SaveListOfPatientInfo(Patients);
            ReloadPatientIfoList();
        }
    }
}
