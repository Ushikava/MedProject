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
        public QuestoinUI()
        {
            InitializeComponent();
        }
        public QuestoinUI(Question quest)
        {
            InitializeComponent();
            QuestionTextLBL.Text = quest.Text;

            switch (quest.Type)
            {
                case SubType.Question:
                case SubType.QuestionRateAnswer:
                case SubType.QuestionTest:
                default:
                    break;
            }
        }
        private void LoadQuestion(Question quest)
        {
            foreach (var v in quest.Variants)
            {

            }
        }
    }
}
