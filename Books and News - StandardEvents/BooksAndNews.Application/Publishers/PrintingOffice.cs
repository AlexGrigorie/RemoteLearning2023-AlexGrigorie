using iQuest.BooksAndNews.Application.CustomeEventsArgs;
using iQuest.BooksAndNews.Application.DataAccess;
using System;

namespace iQuest.BooksAndNews.Application.Publishers
{
    public class PrintingOffice
    {
        private readonly IBookRepository bookRepository;
        private readonly INewspaperRepository newspaperRepository;
        private readonly ILog log;

        public event EventHandler<BookEventArgs> RaiseBookEvent;
        public event EventHandler<NewspaperEventArgs> RaiseNewspaperEvent;

        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.newspaperRepository = newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        protected virtual void OnRaiseBookEvent(BookEventArgs e) 
        {
            EventHandler<BookEventArgs> bookEvent = RaiseBookEvent;
            bookEvent(this, e);

        }

        protected virtual void OnRaiseNewspaperEvent(NewspaperEventArgs e)
        {
            EventHandler<NewspaperEventArgs> newspaperEvent = RaiseNewspaperEvent;
            newspaperEvent(this, e);
        }

        public void PrintRandom(int bookCount, int newspaperCount)
        {
            for (int i = 0; i < bookCount; i++)
            {
                var book = bookRepository.GetRandom();
                log.WriteInfo($"Printed book: {book.Author}  {book.Title} {book.Year}");
                OnRaiseBookEvent(new BookEventArgs(book.Author, book.Title, book.Year));
            }

            for (int i = 0; i < newspaperCount; i++)
            {
                var newspaper = newspaperRepository.GetRandom();
                log.WriteInfo($"Printed newspaper: {newspaper.Title} {newspaper.Number}");
                OnRaiseNewspaperEvent(new NewspaperEventArgs(newspaper.Title, newspaper.Number));
            }
        }
    }
}