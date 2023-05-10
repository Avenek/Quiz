using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Quiz.Model
{
    public class Quiz
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Author { get; set; }
        public int CurrentQuestion { get; set; }
        public List<Question> Questions { get; set; }
        public bool ShowCorrectAnswers { get; set; }
        public double Points { get; set; }
        public Timer EndTimer { get; set; }

        public Quiz(string name, string author, int id, List<Question> questions, int time)
        {
            Name = name;
            Id = id;
            Author = author;
            CurrentQuestion = 0;
            Questions = questions;
            ShowCorrectAnswers = false;
            Points = 0;
            EndTimer = new Timer(time);
        }
        public Quiz() { }
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
            int number = 0;
            foreach (Question question in Questions)
            {
                int correctNumber = 0;
                double totalPoints = 0;
                foreach (Answer answer in question.Answers)
                {
                    if (answer.IsCorrect)
                    {
                        correctNumber++;
                    }
                }
                foreach (Answer answer in question.Answers)
                {
                    
                    if (answer.IsCorrect && answer.IsChoosen)
                    {
                        double temporaryPoints = 1;
                        temporaryPoints /= correctNumber;
                        totalPoints += temporaryPoints;
                    }
                    else if(!answer.IsCorrect && answer.IsChoosen)
                    {
                        double temporaryPoints = 1;
                        temporaryPoints /= correctNumber;
                        totalPoints -= temporaryPoints;
                    }
                }
                if (totalPoints >= 0)
                {
                    Points += totalPoints;
                    Questions[number].Points = $"{totalPoints.ToString("F2")} / 1,00";
                }
                else Questions[number].Points = $"0 / 1,00";
                number++;
            }
        }

    }
}
