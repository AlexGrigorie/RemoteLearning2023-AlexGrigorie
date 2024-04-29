using iQuest.BooksAndNews.Application.DataAccess;
using iQuest.BooksAndNews.Application.Publications;
using System;

namespace iQuest.BooksAndNews.Application.Publishers
{
    public delegate void BookEventHandler(Book book);
    public delegate void NewspaperEventHandler(Newspaper newspaper);
    public class PrintingOffice
    {
        private readonly IBookRepository bookRepository;
        private readonly INewspaperRepository newspaperRepository;
        private readonly ILog log;

        public event BookEventHandler RaiseBookEvent;
        public event NewspaperEventHandler RaiseNewspaperEvent;

        public PrintingOffice(IBookRepository bookRepository, INewspaperRepository newspaperRepository, ILog log)
        {
            this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            this.newspaperRepository = newspaperRepository ?? throw new ArgumentNullException(nameof(newspaperRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void PrintRandom(int bookCount, int newspaperCount)
        {
            for (int i = 0; i < bookCount; i++)
            {
                var book = bookRepository.GetRandom();
                log.WriteInfo($"Printed book: {book.Author}  {book.Title} {book.Year}");
                RaiseBookEvent(book);
            }

            for (int i = 0; i < newspaperCount; i++)
            {
                var newspaper = newspaperRepository.GetRandom();
                log.WriteInfo($"Printed newspaper: {newspaper.Title} {newspaper.Number}");
                RaiseNewspaperEvent(newspaper);
            }
        }
    }
}