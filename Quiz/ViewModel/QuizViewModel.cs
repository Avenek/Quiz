using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

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

        private Model.Question questionContent;
        public Model.Question QuestionContent
        {
            get => questionContent;
            set
            {
                questionContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuestionContent)));
            }
        }

        private Model.Answer firstAnswer;
        public Model.Answer FirstAnswer
        {
            get => firstAnswer;
            set
            {
                firstAnswer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstAnswer)));
            }
        }

        private Model.Answer secondAnswer = null;
        public Model.Answer SecondAnswer
        {
            get => secondAnswer;
            set
            {
                secondAnswer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondAnswer)));
            }
        }
        private Model.Answer thirdAnswer = null;
        public Model.Answer ThirdAnswer
        {
            get => thirdAnswer;
            set
            {
                thirdAnswer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThirdAnswer)));
            }
        }
        private Model.Answer fourthAnswer = null;
        public Model.Answer FourthAnswer
        {
            get => fourthAnswer;
            set
            {
                fourthAnswer = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FourthAnswer)));
            }
        }
        private Visibility endQuizVisibility = Visibility.Collapsed;
        public Visibility EndQuizVisibility
        {
            get { return endQuizVisibility; }
            set
            {
                endQuizVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndQuizVisibility)));
            }
        }
        private string endQuizText = "Zakończ quiz";
        public string EndQuizText
        {
            get { return endQuizText; }
            set
            {
                endQuizText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndQuizText)));
            }
        }
        private Visibility nextQuestionVisibility = Visibility.Collapsed;
        public Visibility NextQuestionVisibility
        {
            get { return nextQuestionVisibility; }
            set
            {
                endQuizVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NextQuestionVisibility)));
            }
        }
        private SolidColorBrush firstAnswerBackground = Brushes.Black;
        public SolidColorBrush FirstAnswerBackground
        {
            get { return firstAnswerBackground; }
            set
            {
                firstAnswerBackground = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstAnswerBackground)));
            }
        }
        private SolidColorBrush secondAnswerBackground = Brushes.Black;
        public SolidColorBrush SecondAnswerBackground
        {
            get { return secondAnswerBackground; }
            set
            {
                secondAnswerBackground = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondAnswerBackground)));
            }
        }
        private SolidColorBrush thirdAnswerBackground = Brushes.Black;
        public SolidColorBrush ThirdAnswerBackground
        {
            get { return thirdAnswerBackground; }
            set
            {
                thirdAnswerBackground = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThirdAnswerBackground)));
            }
        }
        private SolidColorBrush fourthAnswerBackground = Brushes.Black;
        public SolidColorBrush FourthAnswerBackground
        {
            get { return fourthAnswerBackground; }
            set
            {
                fourthAnswerBackground = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FourthAnswerBackground)));
            }
        }
        public QuizViewModel()
        {
            QuestionContent = model.currentQuiz.Questions[questionNumber];
            FirstAnswer = model.currentQuiz.Questions[questionNumber].answers[0];
            SecondAnswer = model.currentQuiz.Questions[questionNumber].answers[1];
            ThirdAnswer = model.currentQuiz.Questions[questionNumber].answers[2];
            FourthAnswer = model.currentQuiz.Questions[questionNumber].answers[3];
        }

        private ICommand previousQuestion;
        public ICommand PreviousQuestion
        {
            get
            {
                if (previousQuestion == null)
                    previousQuestion = new RelayCommand(

                     (o) =>
                     {
                         QuestionNumber -= 1;
                         QuestionContent = model.currentQuiz.Questions[questionNumber];
                         FirstAnswer = model.currentQuiz.Questions[questionNumber].answers[0];
                         SecondAnswer = model.currentQuiz.Questions[questionNumber].answers[1];
                         ThirdAnswer = model.currentQuiz.Questions[questionNumber].answers[2];
                         FourthAnswer = model.currentQuiz.Questions[questionNumber].answers[3];
                         makeColor();
                         NextQuestionVisibility = Visibility.Visible;
                         endQuizVisibility = Visibility.Collapsed;
                     }
                    ,
                    (o) => QuestionNumber != 0
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
                         QuestionNumber += 1;
                         QuestionContent = model.currentQuiz.Questions[questionNumber];
                         FirstAnswer = model.currentQuiz.Questions[questionNumber].answers[0];
                         SecondAnswer = model.currentQuiz.Questions[questionNumber].answers[1];
                         ThirdAnswer = model.currentQuiz.Questions[questionNumber].answers[2];
                         FourthAnswer = model.currentQuiz.Questions[questionNumber].answers[3];
                         makeColor();
                         if(QuestionNumber == model.currentQuiz.Questions.Count)
                         {
                             NextQuestionVisibility = Visibility.Collapsed;
                             endQuizVisibility = Visibility.Visible;
                             if(model.currentQuiz.ShowCorrectAnswers)
                             {
                                 EndQuizText = "Zakończ przegląd";
                             }
                             else EndQuizText = "Zakończ quiz";
                         }

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

        private void makeColor()
        {
            if (model.currentQuiz.ShowCorrectAnswers)
            {
                if (model.currentQuiz.Questions[questionNumber].answers[0].isCorrect)
                    FirstAnswerBackground = Brushes.Green;
                else if (model.currentQuiz.Questions[questionNumber].answers[0].isCorrect && model.currentQuiz.Questions[questionNumber].answers[0].isChoosen)
                    FirstAnswerBackground = Brushes.Red;
                if (model.currentQuiz.Questions[questionNumber].answers[1].isCorrect)
                    SecondAnswerBackground = Brushes.Green;
                else if (model.currentQuiz.Questions[questionNumber].answers[1].isCorrect && model.currentQuiz.Questions[questionNumber].answers[1].isChoosen)
                    SecondAnswerBackground = Brushes.Red;
                if (model.currentQuiz.Questions[questionNumber].answers[2].isCorrect)
                    ThirdAnswerBackground = Brushes.Green;
                else if (model.currentQuiz.Questions[questionNumber].answers[2].isCorrect && model.currentQuiz.Questions[questionNumber].answers[2].isChoosen)
                    ThirdAnswerBackground = Brushes.Red;
                if (model.currentQuiz.Questions[questionNumber].answers[3].isCorrect)
                    FourthAnswerBackground = Brushes.Green;
                else if (model.currentQuiz.Questions[questionNumber].answers[3].isCorrect && model.currentQuiz.Questions[questionNumber].answers[3].isChoosen)
                    FourthAnswerBackground = Brushes.Red;

            }
            else
            {
                FirstAnswerBackground = Brushes.Black;
                SecondAnswerBackground = Brushes.Black;
                ThirdAnswerBackground = Brushes.Black;
                FourthAnswerBackground = Brushes.Black;
            }
        }

    }
}
