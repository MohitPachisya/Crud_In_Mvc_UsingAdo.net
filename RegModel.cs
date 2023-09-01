using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMvcProject.Models
{
    public class RegModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        [Display(Name="User Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "City Is Required")]
        [Display(Name = "User City")]

        public string City { get; set; }

        [Required(ErrorMessage = "Age Is Required")]
        [Display(Name = "User Age")]
        [Range(18,60,ErrorMessage ="Age Must be in Between 18 to 60")]
        public int Age { get; set; }
    }
}