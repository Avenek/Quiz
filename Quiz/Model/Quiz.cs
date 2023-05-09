using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz.Model
{
    public class Quiz
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int CurrentQuestion { get; set; }
        public List<Question> Questions { get; set; }
        public bool ShowCorrectAnswers { get; set; }
        public int Points { get; set; }
        public Timer EndTimer { get; set; }

        public Quiz(string name, int id, List<Question> questions, Timer timer)
        {
            Name = name;
            Id = id;
            CurrentQuestion = 0;
            Questions = questions;
            ShowCorrectAnswers = false;
            Points = 0;
            EndTimer = timer;
        }
        public void NextQuestion() 
        {
            CurrentQuestion += 1;
        }
        public void PreviousQuestion()
        {
            CurrentQuestion -= 1;
        }
        public void SummarizeQuiz()
        {
            ShowCorrectAnswers = true;
            CurrentQuestion = 0;
        }
        public void EndQuiz()
        {
            //Podliczenie punktów
        }

    }
}
