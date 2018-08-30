using IASData.Enumerable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EventLogViewModel
    {
        public int? UserId { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public EventLogType Type { get; set; }
        public string Description { get; set; }

    }
}
