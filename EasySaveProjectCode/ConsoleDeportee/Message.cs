using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDeportee
{
    public class Message
    {
        public long Id { get; set; }
        public Dictionary<string, string> Content { get; set; }

        //constructor 
        public Message(long id, Dictionary<string, string> content) 
        { 
            this.Id = id;
            this.Content = content;
        }
    }
}
