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


namespace TestV.Questions
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class QuestoinUI : UserControl
    {
        public List<int> Answers => _quest.Answers;

        private Question _quest;
        public QuestoinUI(Question quest)
        {
            _quest = quest;
            InitializeComponent();
            QuestionTextLBL.Text = quest.Text;

            switch (quest.Type)
            {
                case SubType.Question:
                    LoadBaseQuestion(quest);
                    break;
                case SubType.QuestionRateAnswer:
                    LoadRateQuestion(quest as QuestionRateAnswer);
                    break;
                case SubType.QuestionTest:
                    break;
                default:
                    break;
            }
        }
        private void LoadRateQuestion(QuestionRateAnswer quest)
        {
            QuestionPanel.Children.Clear();
            for (int i = 0; i < quest.Questions.Count; i++)
            {
                var v = quest.Variants[i];
                var q = new Elements.RateVariant(i, quest);
                q.Value = quest.Answers[i];

                QuestionPanel.Children.Add(q);
                q.ValueChangedEvent += AnswerReceive;
            }
        }
        private void LoadBaseQuestion(Question quest)
        {
            QuestionPanel.Children.Clear();
            for (int i = 0; i < quest.Variants.Count; i++)
            {
                var v = quest.Variants[i];
                var q = new Elements.SelectVariant(i, quest);
                q.Value = quest.Answers[i];

                QuestionPanel.Children.Add(q);
                q.ValueChangedEvent += AnswerReceive;
            }
        }

        private void AnswerReceive(int index, int Value)
        {
            _quest.Answers.ForEach(x => x = -1);

            _quest.Answers[index] = Value;
        }
    }
}
