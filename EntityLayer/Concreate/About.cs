using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class About
    {
        [Key]
        public int AboutID{ get; set; }
        public string AboutDetails_1 { get; set; }
        public string AboutDetails_2 { get; set; }
        public string AboutImage_1 { get; set; }
        public string AboutImage_2 { get; set; }
        public string AboutMapLocation { get; set; }
        public  bool AboutStatus { get; set; }
    }
}
