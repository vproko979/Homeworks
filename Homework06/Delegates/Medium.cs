using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Medium
    {
        public delegate void NewsChangeHandler(object medium, NewsEventArgs news);

        public event NewsChangeHandler NewsChange;

        public void SendBreakingNews(string title, string content, DateTime time)
        {

            NewsEventArgs newsInfo = new NewsEventArgs(title, content, time);

            if (NewsChange != null)
            {
                NewsChange(this, newsInfo);
            }
        }
    }
}
