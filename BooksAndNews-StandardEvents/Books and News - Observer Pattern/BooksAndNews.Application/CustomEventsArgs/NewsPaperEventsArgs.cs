using System;

namespace iQuest.BooksAndNews.Application.CustomeEventsArgs
{
    public class NewspaperEventArgs : EventArgs
    {
        public NewspaperEventArgs(string title, int number)
        {
            Title = title;
            Number = number;
        }
        public string Title { get; private set; }

        public int Number { get; private set; }
    }
}