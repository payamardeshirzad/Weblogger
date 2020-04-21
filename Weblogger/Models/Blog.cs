using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weblogger.Models
{
    public class Blog
    {   [Required]
        public int Id { get; set; }
        [Display(Name = "Title of Blog")]
        public string Title { get; set; }
        [Display(Name ="Date Created")]
        [DisplayFormat(DataFormatString ="{0:dd/mm/yyyy}")]
        public DateTime DateCreated { get; set; }
        [Display(Name ="Content of Blog")]
        public string BlogContent { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
