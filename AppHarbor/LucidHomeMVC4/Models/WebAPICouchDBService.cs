using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
//using System.Json;
using JsonFx;
using System.Text;

namespace LucidHomeMVC4.Models
{
    public class WebAPICouchDBService
    {
        HttpClient _http = new HttpClient();
        string _baseurl = "https://lucid.iriscouch.com";

        public WebAPICouchDBService()
        {
            string user = ConfigurationManager.AppSettings.Get("IrisCouchUser");
            string pass = ConfigurationManager.AppSettings.Get("IrisCouchPass");
            _http.BaseAddress = new Uri(_baseurl);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(Encoding.ASCII.GetBytes(user+":"+pass)));
        }

        public List<WorkoutSetModel> GetWorkoutSetList()
        {
            List<WorkoutSetModel> wsl = new List<WorkoutSetModel>();

            var response = _http.GetAsync("/workoutdb/_all_docs?include_docs=true").Result;
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //var result = response.Content.ReadAsAsync<JsonObject>().Result;
            var result = response.Content.ReadAsStringAsync();
            dynamic dyn = TextTODynamicJson(result.Result);

            foreach( var row in dyn.rows ){
                WorkoutSetModel ws = new WorkoutSetModel { _id = row.doc._id, 
                                                            Reps = row.doc.Reps, 
                                                            Weight = row.doc.Weight, 
                                                            When = DateTime.Parse(row.doc.When) };
                wsl.Add(ws);
            }

            return wsl;
        }

        public void SaveWorkoutSetItem(WorkoutSetModel ws)
        {
            if (string.IsNullOrEmpty(ws._id))
            {
                var response = _http.PostAsJsonAsync("/workoutdb/_all_docs?include_docs=true", ws).Result;
            }
            else
            {
                var response = _http.PutAsJsonAsync("/workoutdb/" + ws._id, ws).Result;
            }
        }

        public WorkoutSetModel GetWorkoutSetItem(string id)
        {

            var response = _http.GetAsync("/workoutdb/" + id).Result;
            var result = response.Content.ReadAsStringAsync();
            dynamic dyn = TextTODynamicJson(result.Result);

            WorkoutSetModel ws = new WorkoutSetModel();
            ws._id = dyn._id;
            ws._rev = dyn._rev;
            ws.Weight = dyn.Weight;
            ws.Reps = dyn.Reps;
            ws.When = DateTime.Parse(dyn.When.ToString());

            return ws;
        }

        public dynamic TextTODynamicJson(string val)
        {
            var reader = new JsonFx.Json.JsonReader();
            dynamic dyn = reader.Read(val);
            return dyn;
        }

    }
}