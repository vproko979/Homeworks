using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Follower
    {
        public string Name { get; set; }
        public Follower(string name)
        {
            Name = name;
        }
        public void Subscribe(Medium medium)
        {
            medium.NewsChange += new Medium.NewsChangeHandler(NewsPublished);
        }

        // the method that implements the delegated functionality
        public void NewsPublished(object medium, NewsEventArgs news)
        {
            Console.WriteLine("{0} received news: \n" +
                "Title: {1}: \n" +
                "Content: {2} \n" +
                "Published: {3}",this.Name , news.Title, news.Content, news.Time);
        }
    }
}
