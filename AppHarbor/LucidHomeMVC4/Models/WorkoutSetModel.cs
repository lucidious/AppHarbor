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
}