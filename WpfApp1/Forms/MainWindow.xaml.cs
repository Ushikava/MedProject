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
using Core;

namespace TestV
{
    public partial class MainWindow : Window
    {
        string content_folder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\";
        public List<PatientInfo> Patients { get; private set; }
        private List<Patient> selectedPAtient = new List<Patient>();

        public MainWindow()
        {
            InitializeComponent();
            ReloadPatientIfoList();
            ExpandMenu.Header = "\u2B9e";
            ExpandMenu_Click(null, null);

            BitmapImage bitmap_patient = new BitmapImage(new Uri(content_folder + "patient_icon.png"));
            Image image_patient = new Image();
            image_patient.Source = bitmap_patient;
            PatientsMenu.Icon = image_patient;

            BitmapImage bitmap_test = new BitmapImage(new Uri(content_folder + "tests_icon.png"));
            Image image_test = new Image();
            image_test.Source = bitmap_test;
            TestsMenu.Icon = image_test;
        }

        public void ReloadPatientIfoList()
        {
            Patients = JsonWork.LoadPatientsInfoList();
            grid.ItemsSource = Patients;
            grid.AddHandler(KeyDownEvent, new KeyEventHandler(MenuItem_KeyDown), true);
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in grid.SelectedItems)
            {
                Guid guid = (item as PatientInfo).GUID;
                try
                {
                    selectedPAtient.Add(JsonWork.LoadPatient(guid));
                    NewTestBtn.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке пациента [{ex.Message}]");
                    NewTestBtn.IsEnabled = false;
                }

                UpdatePatientDescr(selectedPAtient.Last());
            }
            NewTestBtn.IsEnabled = selectedPAtient.Count > 0;
            DeletePatientBtn.IsEnabled = selectedPAtient.Count > 0;
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
            System.Windows.MessageBoxButton buttons = System.Windows.MessageBoxButton.YesNo;
            var res = System.Windows.MessageBox.Show("Удалить выбранных пациентов?", "Подтвердите действие", buttons, System.Windows.MessageBoxImage.Question);

            if (res == MessageBoxResult.Yes)
            {
                foreach (var patient in selectedPAtient)
                {
                    JsonWork.DeletePatient(patient.GUID);

                    NewTestBtn.IsEnabled = false;
                    //UpdatePatientDescr(selectedPAtient.Last());
                }

                foreach (var patient in selectedPAtient)
                {
                    Patients.RemoveAll(x => x.GUID == patient.GUID);
                }

                JsonWork.SavePatientsInfoList(Patients);
                ReloadPatientIfoList();
            }
        }

        private void StartTestButton(object sender, RoutedEventArgs e)
        {
            Window wd = new TestSelector(selectedPAtient.Last());
            wd.Owner = this;

            Hide();
            wd.ShowDialog();
            Show();
        }

        private void MenuItem_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Delete)
                DeletePatientButton(sender, null);
        }

        private void ExpandMenu_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsMenu.Visibility != Visibility.Visible)
            {
                PatientsMenu.Visibility = Visibility.Visible;
                TestsMenu.Visibility = Visibility.Visible;
                MenuCol.Width = new GridLength(120, GridUnitType.Pixel);
                ExpandMenu.Header = "\u2B9c";
            }
            else
            {
                PatientsMenu.Visibility = Visibility.Hidden;
                TestsMenu.Visibility = Visibility.Hidden;
                MenuCol.Width = new GridLength(45, GridUnitType.Pixel);
                ExpandMenu.Header = "\u2B9e";
            }
        }
    }
}
