using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleApp.Models
{
    public class Default
    {
        [Required]
        [Display(Name = "Value")]
        public string Value { get; set; }
    }
}