using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quiz.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
        {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Model.MainModel model = new Model.MainModel();

        private int selectedQuiz = 0;
        public int SelectedQuiz
        {
            get => selectedQuiz;
            set
            {
                selectedQuiz = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedQuiz)));
            }
        }
        private List<Model.Quiz> quizes;
        public List<Model.Quiz> Quizes
        {
            get => quizes;
            set
            {
                quizes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedQuiz)));
            }
        }
        private Visibility quizListVisibility;
        public Visibility QuizListVisibility
        {
            get { return quizListVisibility; }
            set
            {
                quizListVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QuizListVisibility)));
            }
        }
        private Visibility startQuizVisibility;
        public Visibility StartQuizVisibility
        {
            get { return startQuizVisibility; }
            set
            {
                startQuizVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartQuizVisibility)));
            }
        }

        public MainViewModel()
        {

        }

        private ICommand startQuiz;
        public ICommand StartQuiz
        {

            get
            {
                if (startQuiz == null)
                    startQuiz = new RelayCommand(

                     (o) =>
                     {

                         Frame frame = Application.Current.MainWindow.FindName("MainFrame") as Frame;


                         if (frame != null)
                         {
                             QuizListVisibility = Visibility.Collapsed;
                             StartQuizVisibility = Visibility.Collapsed;
                             frame.Navigate(new QuizPage());
                            // model.StartQuiz();
                             QuizViewModel quizViewModel = new QuizViewModel();
                         }
                     }
                    ,
                    (o) => true
                    );
                return startQuiz;
            }
        }
        private ICommand selectQuiz;
        public ICommand SelectQuiz
        {

            get
            {
                if (selectQuiz == null)
                    selectQuiz = new RelayCommand(

                     (o) =>
                     {
                         throw new NotImplementedException();
                     }
                    ,
                    (o) => true
                    );
                return selectQuiz;
            }
        }
    }
}
