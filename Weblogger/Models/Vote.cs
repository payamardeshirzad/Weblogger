using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Weblogger.Models
{
    public class Vote
    {
        [Required]
        public int VoteId { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public int Value { get; set; }
        
        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}
