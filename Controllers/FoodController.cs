using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

using backend.Models;

//System.Object;
// using System.Web.Mvc;

namespace Backend.Controllers {
    [ApiController]
    [Route("Food")]
    public class Food: Controller {
        [HttpGet]
        public string GetFood() { 
            return "Response from backend food controller";
            DotNetEnv.Env.Load();
            string connString = "Data Source=" + Environment.GetEnvironmentVariable("DATABASE_URL");
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            //Get all food items
            string query = "SELECT itemName, cost FROM food_item" 
            + " JOIN food_cost ON food_item.itemId = food_cost.itemId";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<FoodModel> items = new List<FoodModel>();
            using(SqlDataReader reader = cmd.ExecuteReader()) 
            {
                while(reader.Read()) {
                    // FoodModel item = new FoodModel()
                    var foodName = reader.GetValue(0).ToString();
                    var cost = Int32.Parse(reader.GetValue(1).ToString());
                    items.Add(new FoodModel(foodName, cost));
                }
            }

            var itemJson = JsonConvert.SerializeObject(items);
            return itemJson;
        }
    }
} 