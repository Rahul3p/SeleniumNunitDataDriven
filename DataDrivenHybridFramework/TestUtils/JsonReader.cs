using System;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace DataDrivenHybridFramework.TestUtils
{
    public class JsonReader
    {

        public string GetTestData(string tokenKey)
        {
           string JsonFile= File.ReadAllText(ConfigurationManager.AppSettings["testDataFilePath"]);

           var JsonObject=JToken.Parse(JsonFile);

           return JsonObject.SelectToken(tokenKey).Value<string>();
        }


    }
}

