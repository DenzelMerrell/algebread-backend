using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

using backend.Models;
using Microsoft.Extensions.Configuration;

using Npgsql;

//System.Object;
// using System.Web.Mvc;

namespace Backend.Controllers {
    [ApiController]
    [Route("Food")]
    public class Food: Controller {
        [HttpGet]
        public string GetFood() { 
            //return "Response from backend food controller";
            DotNetEnv.Env.Load();
            //string connString = Environment.GetEnvironmentVariable("DATABASE_URL");
            string connString = "User ID=" + Environment.GetEnvironmentVariable("USER_ID");
            connString += "Password=" + Environment.GetEnvironmentVariable("PASSWORD");
            connString += "Host=" + Environment.GetEnvironmentVariable("HOST");
            connString += "Port=" + Environment.GetEnvironmentVariable("PORT");
            connString += "Database=" + Environment.GetEnvironmentVariable("DATABASE");
            
            //string connString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

            string query = "SELECT itemName, cost FROM food_item"
                + " JOIN food_cost ON food_item.itemId = food_cost.itemId";
            List<FoodModel> items = new List<FoodModel>();

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            try
            {
                conn.Open();

                //Get all food items
                
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // FoodModel item = new FoodModel()
                    var foodName = reader[0].ToString();
                    var cost = Int32.Parse(reader[1].ToString());
                    items.Add(new FoodModel(foodName, cost));
                }
                

                conn.Close();
            }
            catch(Exception ex)
            {
                conn.Close();
                return "Error: " + ex.Message;
            }
            
            var itemJson = JsonConvert.SerializeObject(items);
            return itemJson;

        }
    }
} 