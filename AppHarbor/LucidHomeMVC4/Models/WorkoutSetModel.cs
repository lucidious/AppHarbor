using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LucidHomeMVC4.Models
{

    public class WorkoutSetModel
    {
        [Key]
        public string _id { get; set; }

        public string _rev { get; set; }

        [Required]
        [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        [Display(Name = "Date of the workout")]
        public DateTime When { get; set; }

        [Required]
        [Range(1, 200)]
        [DataType(DataType.Text)]
        [Display(Name = "Number of Reps")]
        public int Reps { get; set; }

        [Required]
        [Range(1, 400)]
        [DataType(DataType.Text)]
        [Display(Name = "Weight Used")]
        public int Weight { get; set; }

    }

    public class WorkoutSetAllDocsModel
    {
        public int total_rows { get; set; }
        public int offset { get; set; }
        public List<WorkoutSetRow> rows {get; set;}

        public WorkoutSetAllDocsModel()
        {
            this.rows = new List<WorkoutSetRow>();
        }
    }

    public class WorkoutSetRow
    {
        public string id { get; set; }
        public string key { get; set; }
        public CouchDBrev value { get; set; }
        public WorkoutSetModel doc { get; set; }

        public WorkoutSetRow()
        {
            this.value = new CouchDBrev();
            this.doc = new WorkoutSetModel();
        }
    }

    public class CouchDBrev
    {
        public string rev { get; set; }

        public CouchDBrev()
        {
        }
    }


}