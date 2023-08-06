using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
        public class IndexViewModel
        {
            public List<Category> CategoryList { get; set; }
            public List<Writer> WriterList { get; set; }
        }
    }