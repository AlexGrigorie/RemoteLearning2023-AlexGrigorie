using System;

namespace iQuest.BooksAndNews.Application.CustomeEventsArgs
{
    public class BookEventArgs : EventArgs
    {
        public BookEventArgs(string author, string title, int year)
        {
            Author = author;
            Title = title;
            Year = year;
        }
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }
}