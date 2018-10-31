using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPOinS.Shared
{
    public class EmailFormModel
    {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string FromSubject { get; set; }       
        public string FromMessage { get; set; }
       
    }
}
