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
        public string MockToString(out string dateString)
        {
            Random rand = new Random();
            string status_="";
            int statusR = rand.Next(1, 7);
            switch (statusR)
            {
                case 1:
                    status_ = "Load";
                    break;
                case 2:
                    status_ = "Unload";
                    break;
                case 3:
                    status_ = "Send";
                    break;    
                case 4:
                    status_ = "Request";
                    break;
            }
            string type_="";
            int typeR = rand.Next(1, 5);
            switch (typeR)
            {
                case 1:
                    type_ = "Open";
                    break;
                case 2:
                    type_ = "Done";
                    break;
                case 3:
                    type_ = "Done*";
                    break;
                case 4:
                    type_ = "Accepted";
                    break;
                case 5:
                    type_ = "Rejected";
                    break;
            }
            DateTime date = DateTime.Now;
            date = date.AddHours(rand.Next(-100,-1));
            dateString = date.ToString("dd/MM, HH:mm");
            return string.Format("{0}: {1} - {2}", dateString, status_, type_);
        }
    }
}
