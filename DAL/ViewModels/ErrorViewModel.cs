using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //public class ErrorViewModel
    //{
    //    public int Id { get; set; }
    //    public string ErrorFarsiText { get; set; }
    //    public string ErrorEnglishText { get; set; }
    //}

    public class SystemMessageViewModel
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Type { get; set; }
    }
}
