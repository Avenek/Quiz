using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quiz.Model
{
    internal class MainModel
    {
        public Quiz? currentQuiz { get; set; }

        public MainModel()
        {
            currentQuiz = null;
        }

        public void StartQuiz(string name, int id, List<Question> questions, Timer timer)
        {
            currentQuiz = new Quiz(name, id, questions, timer);
        }
    }
}
