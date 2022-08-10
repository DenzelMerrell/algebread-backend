using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class ProblemModel
    {
        public string problem { get; set; }
        public string answer { get; set; }
        public int payment { get; set; }

        public ProblemModel(string p, string a, int pay)
        {
            problem = p;
            answer = a;
            payment = pay;
        }
    }
}
