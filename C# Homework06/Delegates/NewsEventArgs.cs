using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class NewsEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }

        public NewsEventArgs(string title, string content, DateTime time)
        {
            Title = title;
            Content = content;
            Time = time;
        }
    }
}
