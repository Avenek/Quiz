using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Quiz.ViewModel
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Model.MainModel model = new Model.MainModel();

        private int questionNumber = 0;
        public int QuestionNumber
        {
            get => questionNumber;
            set
            {
                questionNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionNumber)));
            }
        }

        private string questionContent = "";
        public string QuestionContent
        {
            get => questionContent;
            set
            {
                questionContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionContent)));
            }
        }

        private string firstAnswer = "";
        public string FirstAnswer
        {
            get => firstAnswer;
            set
            {
                firstAnswer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstAnswer)));
            }
        }

        private string secondAnswer = "Testowa długa bardzo wręcz długa odpowiedź Ale niech będzie jeszcze dłuższa";
        public string SecondAnswer
        {
            get => secondAnswer;
            set
            {
                secondAnswer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondAnswer)));
            }
        }
        private string thirdAnswer = "Testowa długa bardzo wręcz długa odpowiedź";
        public string ThirdAnswer
        {
            get => thirdAnswer;
            set
            {
                thirdAnswer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThirdAnswer)));
            }
        }
        private string fourthAnswer = "";
        public string FourthAnswer
        {
            get => fourthAnswer;
            set
            {
                fourthAnswer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FourthAnswer)));
            }
        }
        public QuizViewModel()
        {

        }

        private ICommand previuosQuestion;
        public ICommand previousQuestion
        {
            get
            {
                if (previuosQuestion == null)
                    previuosQuestion = new RelayCommand(

                     (o) =>
                     {
                         throw new NotImplementedException();
                     }
                    ,
                    (o) => true
                    );
                return previousQuestion;
            }
        }
        private ICommand nextQuestion;
        public ICommand NextQuestion
        {
            get
            {
                if (nextQuestion == null)
                    nextQuestion = new RelayCommand(

                     (o) =>
                     {
                         throw new NotImplementedException();
                     }
                    ,
                    (o) => true
                    );
                return nextQuestion;
            }
        }
        private ICommand endQuiz;
        public ICommand EndQuiz
        {
            get
            {
                if (endQuiz == null)
                    endQuiz = new RelayCommand(

                     (o) =>
                     {
                         throw new NotImplementedException();
                     }
                    ,
                    (o) => true
                    );
                return endQuiz;
            }
        }
    }
}
