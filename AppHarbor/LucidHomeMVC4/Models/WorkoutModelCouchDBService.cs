using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Dynamic;
//using System.Json;
using JsonFx;
using System.Text;

namespace LucidHomeMVC4.Models
{
    public class WorkoutModelCouchDBService
    {
        HttpClient _http = new HttpClient();
        private string _baseurl = "https://lucid.iriscouch.com";
        private string _defaultdatabase = "workoutdb";

        public WorkoutModelCouchDBService()
        {
            string user = ConfigurationManager.AppSettings.Get("IrisCouchUser");
            string pass = ConfigurationManager.AppSettings.Get("IrisCouchPass");
            _http.BaseAddress = new Uri(_baseurl+"/"+_defaultdatabase);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",Convert.ToBase64String(Encoding.ASCII.GetBytes(user+":"+pass)));
        }

        /*
        public List<WorkoutModel> GetWorkoutList()
        {
            List<WorkoutModel> wsl = new List<WorkoutModel>();

            var response = _http.GetAsync("/_all_docs?include_docs=true").Result;
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //var result = response.Content.ReadAsAsync<JsonObject>().Result;
            var result = response.Content.ReadAsStringAsync();
            dynamic dyn = TextTODynamicJson(result.Result);

            foreach( WorkoutModel row in dyn.rows ){
                wsl.Add(row);
            }

            return wsl;
        }


        public void SaveWorkoutItem(WorkoutModel ws)
        {
            if (string.IsNullOrEmpty(ws._id))
            {
                var response = _http.PostAsJsonAsync("", ws).Result;
            }
            else
            {
                var response = _http.PutAsJsonAsync(ws._id, ws).Result;
            }
        }

        public void DeleteWorkoutItem(WorkoutModel ws)
        {
            if (!string.IsNullOrEmpty(ws._id))
            {
                var response = _http.DeleteAsync(ws._id + "?rev=" + ws._rev).Result;
            }
        }


        public WorkoutModel GetWorkoutItem(string id)
        {

            var response = _http.GetAsync(id).Result;
            var result = response.Content.ReadAsStringAsync();
            dynamic dyn = TextTODynamicJson(result.Result);

            WorkoutModel ws = new WorkoutModel();
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
         */

    }
}