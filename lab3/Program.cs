using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Proj7
{
    class Program
    {
        public interface IObserver
        {
            void Update(ISubject subject);
        }
        public interface ISubject
        {
            void Attach(IObserver observer, string type);
            void Detach(IObserver observer, string type);
            void Notify(string type);
        }

        public class TextNews
        {
            public string title;
            public List<string> theme;
            public string text;
            public TextNews(string title, List<string> theme, string text)
            {
                this.title = title;
                this.theme = theme;
                this.text = text;
            }
            public override string ToString()
            {
                return $"{this.title}";
            }
        }

        public class VideoNews
        {
            public string title;
            public List<string> thene;
            public string url;
            public VideoNews(string title, List<string> theme, string url)
            {
                this.title = title;
                this.theme = theme;
                this.url = url;
            }
            public override string ToString()
            {
                return $"{this.title}";
            }
        }

        public class NewsList : ISubject
        {
            public List<TextNews> text_news = new List<TextNews> { };
            public List<VideoNews> video_news = new List<VideoNews> { };

            public List<IObserver> textObservers = new List<IObserver>();
            public List<IObserver> videoObservers = new List<IObserver>();

            public void Attach(IObserver observer, string type)
            {
                if (type == "subscribe_txt")
                {
                    Console.WriteLine($"user subscribed to text news");
                    this.textObservers.Add(observer);
                }
                if (type == "subscribe_vid")
                {
                    Console.WriteLine("user subscribet to video news");
                    this.videoObservers.Add(observer);
                }
                if (type == "subscribe")
                {
                    this.textObservers.Add(observer);
                    this.videoObservers.Add(observer);
                    Console.WriteLine("User subscribed to video and text");
                }
            }

            public void Detach(IObserver observer, string type)
            {
                if (type == "Unsubscribe_txt")
                {
                    this.textObservers.Remove(observer);
                    Console.WriteLine($"User unsubscribed to text news");
                }
                if (type == "Unsubscribe_vid")
                {
                    this.videoObservers.Remove(observer);
                    Console.WriteLine($"User unsubscribed to video news");
                }
                if (type == "Unsubscribe")
                {
                    this.textObservers.Remove(observer);
                    this.videoObservers.Remove(observer);
                    Console.WriteLine("Unsubscribed from all");                    
                }
            }

            public void Notify(string type)
            {
                if (type == "notify_txt")
                {
                    Console.WriteLine("NewsFeed: Notifying text subscribers...");

                    foreach (var observer in textObservers)
                    {
                        observer.Update(this);
                    }
                }
                if (type == "notify_vid")
                {
                    Console.WriteLine("NewsFeed: Notifying video subscribers...");

                    foreach (var observer in videoObservers)
                    {
                        observer.Update(this);
                    }
                }
                if (type == "notify")
                {
                    Console.WriteLine("NewsFeed: Notifying all subscribers...");

                    foreach (var observer in textObservers.Concat(videoObservers))
                    {
                        observer.Update(this);
                    }
                }
            }

            public void AddedTextNews(TextNews news)
            {
                this.text_news.Add(news);
                Console.WriteLine(text_news.Last());
                this.Notify("notify_txt");

            }
            public void AddedVideoNews(VideoNews news)
            {
                this.video_news.Add(news);
                Console.WriteLine(video_news.Last());
                this.Notify("notify_vid");
            }
        }


        class Reader : IObserver
        {
            public string name;
            public Reader(string name)
            {
                this.name = name;
            }
            public void Update(ISubject subject)
            {
                if ((subject as NewsList).text_news.Count != 0 || (subject as NewsList).text_news.Count != 0)
                {
                    Console.WriteLine($"{name}: Reacted to the news.");
                }
            }
        }

        static void Main(string[] args)
        {
            var list = new NewsList();
            var readerA = new Reader("Bob T.");
            var readerB = new Reader("Volter W.");
            var readerC = new Reader("Tommy S.");
            var videoNew = new VideoNews("The New Phase Of The War In Ukraine",
                new List<string> { "War", "Ukraine" },
                "https://www.youtube.com/watch?v=fejo8cXMpSw&ab_channel=VICENews");
            var textNew1 = new TextNews("Russia delivers note of protest to Latvian ambassador over removal of Soviet monuments delivers note of protest to Latvian ambassador over removal of Soviet monuments",
                new List<string> { "Ukraine", "War" , "Terrorism"},
                "Russian authorities on Thursday summoned Latvia's ambassador to the country, Maris Riekstins, to deliver a note of protest against what Moscow considers illegal actions related to the removal of monuments dating back to the Soviet era.");
            var textNew2 = new TextNews("Miss Universe is changing! See how the rules have become more flexible",
                new List<string> { "Changes in the Miss Universe pageant", "Transgender woman owns Miss Universe" },
                "Miss Universe is going through a lot of changes. In October 2022, it was bought by a transwoman, Anne Jakkaphong. Standing in the middle of this photo, wearing a beige dress, she is a billionaire of Thai origin.");

//Test

            list.Attach(readerA, "subscribe_txt"); //reader A just subscibed on text news
            list.Attach(readerB, "subscribe_txt"); 
            list.AddedTextNews(textNew1); //added text news
            list.Detach(readerB, "subscribe_txt");
            list.AddedTextNews(textNew2);
            list.Attach(readerA, "subscribe_vid");
            list.Attach(readerB, "unsubscribe_txt");//reader B unsubscribed from news
            list.Attach(readerC, "subscribe_vid");
            list.AddedVideoNews(videoNew);//add video news
            list.Detach(readerA, "subscribe_vid");
        }
    }
}