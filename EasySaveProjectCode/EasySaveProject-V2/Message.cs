using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject_V2
{
    public class Message
    {
        public long Id { get; set; }
        public Dictionary<string, string> Content { get; set; }
        public int Status { get; set; } 

        public Message(long id, Dictionary<string, string> content, int statusCode) 
        {
            Id = id;
            Content = content;
            Status = statusCode;
        }
    }
}
