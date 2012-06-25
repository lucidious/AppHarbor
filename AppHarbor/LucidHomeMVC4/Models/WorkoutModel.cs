using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LucidHomeMVC4.Models
{
    public class WorkoutModel
    {
        [Key]
        public string _id { get; set; }
        public string _rev { get; set; }
        public DateTime CreateDate { get; set; }
        public List<WorkoutSet> Sets { get; set; }

        public WorkoutModel()
        {
            this.Sets = new List<WorkoutSet>();
        }
    }

    public class WorkoutSet
    {
        public int Weight { get; set; }
        public int Reps { get; set; }
        public string Notes { get; set; }
    }
}