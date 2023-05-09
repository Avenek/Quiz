using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    public class Question
    {
        public string content {  get; set; }
        public List<Answer> answers { get; set; }
    }
}
