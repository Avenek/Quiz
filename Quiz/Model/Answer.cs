using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    public class Answer
    {
        public string content {  get; set; }
        public bool isCorrect { get; set; }
        public bool isChoosen { get; set; }
    }
}
