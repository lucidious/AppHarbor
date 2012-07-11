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
            //WorkoutSetAllDocsModel result = response.Content.ReadAsAsync<WorkoutSetAllDocsModel>().Result;
            var reader = new JsonFx.Json.JsonReader();
            WorkoutSetAllDocsModel wsal = reader.Read<WorkoutSetAllDocsModel>(result.Result);
            foreach (var row in wsal.rows)
            {
                wsl.Add(row.doc);
            }

            return wsl;
        }

        public void SaveWorkoutSetItem(WorkoutSetModel ws)
        {
            if (string.IsNullOrEmpty(ws._id))
            {
                var response = _http.PostAsJsonAsync("/workoutdb/", ws).Result;
            }
            else
            {
                var response = _http.PutAsJsonAsync("/workoutdb/" + ws._id, ws).Result;
            }
        }

        public void DeleteWorkoutSetItem(WorkoutSetModel ws)
        {
            if (!string.IsNullOrEmpty(ws._id))
            {
                var response = _http.DeleteAsync("/workoutdb/" + ws._id + "?rev=" + ws._rev).Result;
            }
        }

        public static T Cast<T>(object o)
        {
            return (T)o;
        }

        public WorkoutSetModel GetWorkoutSetItem(string id)
        {

            var response = _http.GetAsync("/workoutdb/" + id).Result;
            var result = response.Content.ReadAsStringAsync();
            // dynamic dyn = TextTODynamicJson(result.Result);

            //WorkoutSetAllDocsModel result = response.Content.ReadAsAsync<WorkoutSetAllDocsModel>().Result;
            var reader = new JsonFx.Json.JsonReader();
            WorkoutSetModel ws = reader.Read<WorkoutSetModel>(result.Result);

            return ws;
        }


        // No longer used. Direct converstion to types works better.
        public dynamic TextTODynamicJson(string val)
        {
            var reader = new JsonFx.Json.JsonReader();
            dynamic dyn = reader.Read(val);
            return dyn;
        }

    }
}