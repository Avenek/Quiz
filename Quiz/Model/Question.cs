using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Content {  get; set; }
        public List<Answer> Answers { get; set; }
        public string Points { get; set; }
    }
}
