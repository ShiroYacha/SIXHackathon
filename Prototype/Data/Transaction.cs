using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Transaction
    {
        public string id { get; set; }
        public string timestamp { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string amount { get; set; }
        public string phoneNumber { get; set; }
    }
}
