using iQuest.BooksAndNews.Application.Publications;
using iQuest.BooksAndNews.Application.Publishers;

namespace iQuest.BooksAndNews.Application.Subscribers
{
    public class BookLover
    {
        private readonly string name;
        private readonly ILog log;

        public BookLover(string name, PrintingOffice printingOffice, ILog log)
        {
            this.name = name;
            this.log = log;
            printingOffice.RaiseBookEvent += HandleBookEvent;
        }

        private void HandleBookEvent(Book book)
        {
            log.WriteInfo($"This subscriber has been notified {name} {book.Title} {book.Author} {book.Year}");
        }
    }
}