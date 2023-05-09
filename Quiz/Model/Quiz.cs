using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz.Model
{
    class Quiz
    {
        string Name { get; set; }
        int Id { get; set; }
        int CurrentQuestion { get; set; }
        List<Question> Questions { get; set; }
        bool ShowCorrectAnswers { get; set; }
        int Points { get; set; }
        Timer timer { get; set; }

        public void StartQuiz()
        {
            throw new NotImplementedException();
        }
        public void NextQuestion() 
        {
            throw new NotImplementedException();
        }
        public void PreviousQuestion()
        {
            throw new NotImplementedException();
        }
        public void SummarizeQuiz()
        {
            throw new NotImplementedException();
        }
        public void EndQuiz()
        {
            throw new NotImplementedException();
        }

    }
}
