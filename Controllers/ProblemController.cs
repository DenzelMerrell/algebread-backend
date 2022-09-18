using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

using backend.Models;

namespace Backend.Controllers {
    [ApiController]
    [Route("problem")]
    public class ProblemsController {
        [HttpGet]
        public ProblemModel GetProblem() {
            DotNetEnv.Env.Load();
            string connString = "Data Source=" + Environment.GetEnvironmentVariable("DATABASE_URL");
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            //Get the maximum problem id  (SELECT MAX(id) FROM problem)
            string query = "SELECT MAX(problemId) FROM problem"; 
            SqlCommand cmd = new SqlCommand(query, conn);
            int max;
            using(SqlDataReader reader = cmd.ExecuteReader()) 
            {
                reader.Read();
                max = (int) reader.GetValue(0);
            }

            //Generate random number from 1 to the max
            Random rand = new Random();
            int randomId = rand.Next(1, max);

            //Get the problem with an id matching that number (SELECT problem FROM problem WHERE problemId = randomId)
            query = 
                "SELECT problem, answer, payment FROM problem " +
                "JOIN problem_answer pa " +
                    "ON problem.problemId = pa.problemId " +
                "JOIN problem_payment pp " +
                    "ON problem.problemId = pp.problemId " +
                "WHERE problem.problemId = " + randomId;

            cmd.CommandText = query;
            
            ProblemModel problemObj;
            using(SqlDataReader myReader = cmd.ExecuteReader())
            {
                string problem, answer;
                int payment;
                myReader.Read();
                problem = Convert.ToString(myReader.GetValue(0));
                answer = Convert.ToString(myReader.GetValue(1));
                payment = Convert.ToInt32(myReader.GetValue(2));
                problemObj = new ProblemModel(problem, answer, payment);
            }
            
            //return the problem
            return problemObj;
        }
    }
}