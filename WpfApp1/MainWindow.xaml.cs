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

namespace TestV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Test.PatientInfo> Patients { get; private set; }
        private Patient selectedPAtient = Patient.EMPTY;

        public MainWindow()
        {
            InitializeComponent();
            ReloadPatientIfoList();
        }

        public void ReloadPatientIfoList()
        {
            Patients = JsonWork.LoadPatientsInfoList();
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
                    NewTestBtn.IsEnabled = true;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"Ошибка при загрузке пациента [{ex.Message}]");
                    selectedPAtient = Patient.EMPTY;
                    selectedPAtient.GUID = guid;
                    NewTestBtn.IsEnabled = false;
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

        private void NewPatientButton(object sender, RoutedEventArgs e)
        {
            Patient patient = Program.CreateExamplePatient();


            Patients.Add(patient.GetPatientCut());

            JsonWork.SavePatientsInfoList(Patients);
            JsonWork.SavePatient(patient);
            
            ReloadPatientIfoList();
            grid.SelectedItem = grid.Items.Count - 1;
        }

        private void DeletePatientButton(object sender, RoutedEventArgs e)
        {
            Patients.RemoveAll( x => x.GUID == selectedPAtient.GUID);
            JsonWork.DeletePatient(selectedPAtient.GUID);
            JsonWork.SavePatientsInfoList(Patients);
            ReloadPatientIfoList();

            selectedPAtient = Patient.EMPTY;
            NewTestBtn.IsEnabled = false;
            UpdatePatientDescr(selectedPAtient);
        }

        private void StartTestButton(object sender, RoutedEventArgs e)
        {
            Window wd = new TestWindow(selectedPAtient);
            wd.Owner = this;

            Hide();
            wd.ShowDialog();
            Show();
        }
    }
}
