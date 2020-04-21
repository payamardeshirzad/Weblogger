using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weblogger.Models;
using System.ComponentModel.DataAnnotations;

namespace Weblogger.ViewModels
{
    public class BlogVoteViewModel
    {
        public Blog blog { get; set; }
        public Vote vote { get; set; }
    }
}
