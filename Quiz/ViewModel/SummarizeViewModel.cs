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
    class SummarizeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Model.MainModel model = MainViewModel.model;

        private double points = 0;
        public double Points
        {
            get => points;
            set
            { 
                points = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Points)));
            }
        }
        private int maxPoints = 0;
        public int MaxPoints
        {
            get => maxPoints;
            set
            {
                maxPoints = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxPoints)));
            }
        }
        private string result = "";
        public string Result
        {
            get => result;
            set
            {
                result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
            }
        }
        public SummarizeViewModel()
        {
            MaxPoints = model.currentQuiz.Questions.Count();
            model.currentQuiz.EndQuiz();
            Points = model.currentQuiz.Points;
            Result = $"{Points.ToString("F2")} / {MaxPoints},00";
        }

        private ICommand closeWindow;
        public ICommand CloseWindow
        {
            get
            {
                if (closeWindow == null)
                    closeWindow = new RelayCommand(

                     (o) =>
                     {
                         Application.Current.MainWindow.Close();
                     }
                    ,
                    (o) => true
                    );
                return closeWindow;
            }
        }
        private ICommand checkAnswers;
        public ICommand CheckAnswers
        {
            get
            {
                if (checkAnswers == null)
                    checkAnswers = new RelayCommand(

                     (o) =>
                     {
                         model.currentQuiz.ShowCorrectAnswers = true;
                         Frame frame = Application.Current.MainWindow.FindName("MainFrame") as Frame;


                         if (frame.CanGoBack)
                         {
                             frame.NavigationService.GoBack();
                         }
                     }
                    ,
                    (o) => true
                    );
                return checkAnswers;
            }
        }
    }
}
