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
        private Test _test;
        private int selectedQuestion = 0;

        private QuestoinUI prevQuestion;
        private QuestoinUI curQuestion;


        public TestWindow(Test test)
        {
            if (test.QuestionList.Count == 0)
            {
                MessageBox.Show("В тесте нет вопросов");
                Close();
            }

            _test = test;
            InitializeComponent();
            SelectQuest(selectedQuestion);
        }

        private void SelectQuest(int questionIndex)
        {
            prevQuestion = curQuestion;

            var q = new QuestoinUI(_test.QuestionList[questionIndex]);
            //q.SetValue(Grid.RowProperty, 1);
            curQuestion = q;

            if (prevQuestion != null)
                MainGrid.Children.Remove(prevQuestion);
            MainGrid.Children.Add(q);
        }

        private void CalculateResultat()
        {
            for (int i = 0; i < _test.QuestionList.Count; i++)
            {
                var q = _test.QuestionList[i].GetAnswers();

                System.Diagnostics.Debug.Write($"quest [{_test.QuestionList[i].Text}]");
                foreach (var a in q)
                    System.Diagnostics.Debug.Write($"[{a.Key}][{a.Value}]");
                System.Diagnostics.Debug.WriteLine($"_");
            }
        }

        private void Button_Click_prev(object sender, RoutedEventArgs e)
        {
            selectedQuestion = Math.Max(0, selectedQuestion - 1);
            SelectQuest(selectedQuestion);
        }

        private void Button_Click_next(object sender, RoutedEventArgs e)
        {
            selectedQuestion = Math.Min(_test.QuestionList.Count, selectedQuestion + 1);
            if (selectedQuestion == _test.QuestionList.Count)
            {
                MessageBox.Show("Это последний вопрос");
                CalculateResultat();
                selectedQuestion -= 1;
            }
            SelectQuest(selectedQuestion);
        }

    }
}
