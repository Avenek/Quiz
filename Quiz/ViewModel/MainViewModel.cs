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
        public static readonly Model.MainModel model = new Model.MainModel();

        private static int selectedQuiz=0;
        public static int SelectedQuiz
        {
            get => selectedQuiz;
            set
            {
                selectedQuiz = value;
            }
        }
        private List<string> quizes;
        public List<string> Quizes
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
            quizes = model.GetQuizListFromDatabase();
            QuizViewModel quizViewModel = new QuizViewModel();
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
                         }
                     }
                    ,
                    (o) => selectedQuiz >-1
                    );
                return startQuiz;
            }
        }
        private void MainViewModel_ButtonClicked(object sender, EventArgs e)
        {
            QuizListVisibility = Visibility.Visible;
            StartQuizVisibility = Visibility.Visible;

        }
    }
}
