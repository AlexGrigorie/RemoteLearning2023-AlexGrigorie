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
        public string Author { get; private set; }
        public string Title { get; private set; }
        public int Year { get;  private set; }
    }
}