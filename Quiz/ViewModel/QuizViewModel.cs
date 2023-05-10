using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Quiz.ViewModel
{
    public class QuizViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Model.MainModel model = MainViewModel.model;

        private int questionNumber = 1;
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
        private Visibility nextQuestionVisibility = Visibility.Visible;
        public Visibility NextQuestionVisibility
        {
            get { return nextQuestionVisibility; }
            set
            {
                endQuizVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NextQuestionVisibility)));
            }
        }
        private SolidColorBrush firstAnswerBackground = null;
        public SolidColorBrush FirstAnswerBackground
        {
            get { return firstAnswerBackground; }
            set
            {
                firstAnswerBackground = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstAnswerBackground)));
            }
        }
        private SolidColorBrush secondAnswerBackground = null;
        public SolidColorBrush SecondAnswerBackground
        {
            get { return secondAnswerBackground; }
            set
            {
                secondAnswerBackground = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondAnswerBackground)));
            }
        }
        private SolidColorBrush thirdAnswerBackground = null;
        public SolidColorBrush ThirdAnswerBackground
        {
            get { return thirdAnswerBackground; }
            set
            {
                thirdAnswerBackground = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ThirdAnswerBackground)));
            }
        }
        private SolidColorBrush fourthAnswerBackground = null;
        public SolidColorBrush FourthAnswerBackground
        {
            get { return fourthAnswerBackground; }
            set
            {
                fourthAnswerBackground = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FourthAnswerBackground)));
            }
        }
        private string timerValue;
        public string TimerValue
        {
            get { return timerValue; }
            set
            {
                timerValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimerValue)));
            }
        }
        private string pointsNumber;
        public string PointsNumber
        {
            get { return pointsNumber; }
            set
            {
                pointsNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PointsNumber)));
            }
        }
        public QuizViewModel()
        {
            QuestionNumber = 1;
            PointsNumber = "";
            model.StartQuiz(MainViewModel.SelectedQuiz + 1);
            QuestionContent = model.currentQuiz.Questions[0];
            FirstAnswer = model.currentQuiz.Questions[0].Answers[0];
            SecondAnswer = model.currentQuiz.Questions[0].Answers[1];
            ThirdAnswer = model.currentQuiz.Questions[0].Answers[2];
            FourthAnswer = model.currentQuiz.Questions[0].Answers[3];
            makeColor();
            // Inicjalizacja i konfiguracja timera
            model.currentQuiz.EndTimer.Interval = TimeSpan.FromMinutes(30).TotalMilliseconds;
                model.currentQuiz.EndTimer.AutoReset = false;
                TimerValue = TimeSpan.FromMinutes(30).ToString(@"hh\:mm\:ss");
                model.currentQuiz.EndTimer.Start();
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += TimerTick;
                timer.Start();
            
                // Ustawienie początkowej wartości timera
                TimerValue = TimeSpan.FromMinutes(30).ToString(@"hh\:mm\:ss");


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
                         QuestionContent = model.currentQuiz.Questions[questionNumber-1];
                         FirstAnswer = model.currentQuiz.Questions[questionNumber-1].Answers[0];
                         SecondAnswer = model.currentQuiz.Questions[questionNumber-1].Answers[1];
                         ThirdAnswer = model.currentQuiz.Questions[questionNumber - 1].Answers[2];
                         FourthAnswer = model.currentQuiz.Questions[questionNumber - 1].Answers[3];
                         makeColor();
                         NextQuestionVisibility = Visibility.Visible;
                         endQuizVisibility = Visibility.Collapsed;
                         NextQuestionVisibility = Visibility.Visible;
                         EndQuizVisibility = Visibility.Collapsed;
                         if (model.currentQuiz.ShowCorrectAnswers)
                         {
                             EndQuizText = "Zakończ przegląd";
                             PointsNumber = model.currentQuiz.Questions[questionNumber - 1].Points;
                         }
                         else EndQuizText = "Zakończ quiz";
                     }
                    ,
                    (o) => QuestionNumber != 1
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
                         QuestionContent = model.currentQuiz.Questions[questionNumber - 1];
                         FirstAnswer = model.currentQuiz.Questions[questionNumber - 1].Answers[0];
                         SecondAnswer = model.currentQuiz.Questions[questionNumber - 1].Answers[1];
                         ThirdAnswer = model.currentQuiz.Questions[questionNumber - 1].Answers[2];
                         FourthAnswer = model.currentQuiz.Questions[questionNumber - 1].Answers[3];
                         makeColor();
                         if(QuestionNumber == model.currentQuiz.Questions.Count)
                         {
                             NextQuestionVisibility = Visibility.Collapsed;
                             EndQuizVisibility = Visibility.Visible;
                             if(model.currentQuiz.ShowCorrectAnswers)
                             {
                                 EndQuizText = "Zakończ przegląd";
                                 PointsNumber = model.currentQuiz.Questions[questionNumber - 1].Points;
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
                         if(!model.currentQuiz.ShowCorrectAnswers) MessageBox.Show("Quiz został ukończony.");
                         Frame frame = Application.Current.MainWindow.FindName("MainFrame") as Frame;


                         if (frame != null)
                         {

                             frame.Navigate(new SummarizePage());
                             frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
                             QuestionNumber = 1;
                             QuestionContent = model.currentQuiz.Questions[0];
                             FirstAnswer = model.currentQuiz.Questions[0].Answers[0];
                             SecondAnswer = model.currentQuiz.Questions[0].Answers[1];
                             ThirdAnswer = model.currentQuiz.Questions[0].Answers[2];
                             FourthAnswer = model.currentQuiz.Questions[0].Answers[3];
                             model.currentQuiz.ShowCorrectAnswers = true;
                             makeColor();
                             PointsNumber = model.currentQuiz.Questions[0].Points;
                             NextQuestionVisibility = Visibility.Visible;
                             EndQuizVisibility = Visibility.Collapsed;


                         }
                     }
                    ,
                    (o) => true
                    );
                return endQuiz;
            }
        }
        private ICommand check;
        public ICommand Check
        {
            get
            {
                if (check == null)
                    check = new RelayCommand(

                     (o) =>
                     {
                         
                     }
                    ,
                    (o) => !model.currentQuiz.ShowCorrectAnswers
                    );
                return check;
            }
        }

        private void makeColor()
        {
            if (model.currentQuiz.ShowCorrectAnswers)
            {
                FirstAnswerBackground = null;
                SecondAnswerBackground = null;
                ThirdAnswerBackground = null;
                FourthAnswerBackground = null;

                if (model.currentQuiz.Questions[questionNumber -1].Answers[0].IsCorrect)
                    FirstAnswerBackground = Brushes.Green;
                if (!model.currentQuiz.Questions[questionNumber - 1].Answers[0].IsCorrect && model.currentQuiz.Questions[questionNumber-1].Answers[0].IsChoosen)
                    FirstAnswerBackground = Brushes.Red;
                if (model.currentQuiz.Questions[questionNumber - 1].Answers[1].IsCorrect)
                    SecondAnswerBackground = Brushes.Green;
                if (!model.currentQuiz.Questions[questionNumber - 1].Answers[1].IsCorrect && model.currentQuiz.Questions[questionNumber-1].Answers[1].IsChoosen)
                    SecondAnswerBackground = Brushes.Red;
                if (model.currentQuiz.Questions[questionNumber - 1].Answers[2].IsCorrect)
                    ThirdAnswerBackground = Brushes.Green;  
                if (!model.currentQuiz.Questions[questionNumber - 1].Answers[2].IsCorrect && model.currentQuiz.Questions[questionNumber - 1].Answers[2].IsChoosen)
                    ThirdAnswerBackground = Brushes.Red;
                if (model.currentQuiz.Questions[questionNumber - 1].Answers[3].IsCorrect)
                    FourthAnswerBackground = Brushes.Green;
                if (!model.currentQuiz.Questions[questionNumber - 1].Answers[3].IsCorrect && model.currentQuiz.Questions[questionNumber - 1].Answers[3].IsChoosen)
                    FourthAnswerBackground = Brushes.Red;

            }
            else
            {
                FirstAnswerBackground = null;
                SecondAnswerBackground = null;
                ThirdAnswerBackground = null;
                FourthAnswerBackground = null;
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            if (!model.currentQuiz.ShowCorrectAnswers)
            {
                // Dekrementacja wartości timera co sekundę
                TimeSpan currentValue = TimeSpan.Parse(TimerValue);
                TimeSpan newValue = currentValue.Subtract(TimeSpan.FromSeconds(1));

                if (newValue <= TimeSpan.Zero)
                {
                    // Timer osiągnął zero - wykonaj akcję po upływie czasu
                    EndQuiz.Execute(null);
                    MessageBox.Show("Czas minął!");
                }
                else
                {
                    // Aktualizacja wartości timera
                    TimerValue = newValue.ToString(@"hh\:mm\:ss");
                }
            }
        }
    }
}
