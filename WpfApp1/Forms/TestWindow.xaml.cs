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
using TestV.Questions;

namespace TestV
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private Test test;
        private int selectedQustion = 0;

        private QuestoinUI prevQuestion;
        private QuestoinUI curQuestion;


        public TestWindow(Test test)
        {
            if (test.QuestionList.Count == 0)
            {
                MessageBox.Show("В тесте нет вопросов");
                Close();
            }

            this.test = test;
            InitializeComponent();
            SelectQuest(selectedQustion);
        }

        private void SelectQuest(int questionIndex)
        {
            prevQuestion = curQuestion;

            var q = new QuestoinUI(test.QuestionList[questionIndex]);
            //q.SetValue(Grid.RowProperty, 1);
            curQuestion = q;

            if (prevQuestion != null)
                MainGrid.Children.Remove(prevQuestion);
            MainGrid.Children.Add(q);
        }

        private void Button_Click_prev(object sender, RoutedEventArgs e)
        {
            selectedQustion = Math.Max(0, selectedQustion - 1);
            SelectQuest(selectedQustion);
        }

        private void Button_Click_next(object sender, RoutedEventArgs e)
        {
            selectedQustion = Math.Min(test.QuestionList.Count - 1, selectedQustion + 1);
            SelectQuest(selectedQustion);
        }
    }
}
