using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace iBlog.Models
{
    public class BlogMenu
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name ="Titulo")]
        public string title { get; set; }
        [AllowHtml]
        [Display(Name = "Contenido")]
        public string content { get; set; }
        [Display(Name = "Post Privado")]
        public bool privatePost { get; set; }

    }
}