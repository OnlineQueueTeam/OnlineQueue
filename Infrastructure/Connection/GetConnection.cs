using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Connection
{
    public class GetConnection
    {
        private static readonly string _path = @"..\..\..\..\..\OnlineQueue\Infrastructure\Connection\appSettings.json";
   
        public  static string? Connection()
        {
            string json = File.ReadAllText(_path);

            // Parse the JSON string into a JObject
            JObject jObject = JObject.Parse(json);

            // Retrieve the connection string from the JObject
            string? connectionString = jObject["ConnectionStrings"]["MyConnectionString"].ToString();
            
            return  connectionString;

        }

        public static string? DatabaseName()
        {
            string? conString= Connection();
            int i1=0;
            int i2=0;

            if (conString is not null)
            {
                i1 = conString.IndexOf("Database");
                i2 = conString.IndexOf(";", i1);
            }
            else
                return null;

            string? dbName=conString.Substring(i1+9,i2-i1-9);

            return dbName;
        }
    }
}
