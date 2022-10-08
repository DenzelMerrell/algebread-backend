using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;

using backend.Models;

using Npgsql;

namespace Backend.Controllers {
    [ApiController]
    [Route("problem")]
    public class ProblemsController {
        [HttpGet]
        public ProblemModel GetProblem() {
            DotNetEnv.Env.Load();

            string connString = "User ID=" + Environment.GetEnvironmentVariable("USER_ID");
            connString += "Password=" + Environment.GetEnvironmentVariable("PASSWORD");
            connString += "Host=" + Environment.GetEnvironmentVariable("HOST");
            //connString += "Port=" + Environment.GetEnvironmentVariable("PORT");
            connString += "Database=" + Environment.GetEnvironmentVariable("DATABASE");

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            //Get the maximum problem id  (SELECT MAX(id) FROM problem)
            string query = "SELECT MAX(problemId) FROM problem";

            int max;
            NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                max = (int)reader.GetValue(0);
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

            NpgsqlDataReader myReader = cmd.ExecuteReader();
            string problem, answer;
            int payment;
            myReader.Read();
            problem = Convert.ToString(myReader.GetValue(0));
            answer = Convert.ToString(myReader.GetValue(1));
            payment = Convert.ToInt32(myReader.GetValue(2));
            problemObj = new ProblemModel(problem, answer, payment);

            //return the problem
            return problemObj;

        }
    }
}