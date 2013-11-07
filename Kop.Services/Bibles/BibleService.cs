using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;
using Kop.Core.Data;

namespace Kop.Services.Bibles
{
    public class BibleService : IBibleService
    {
        private readonly IRepository<Bible> _bibleRepository;
        private readonly IRepository<BibleBook> _bibleBookRepository;

        public BibleService(IRepository<Bible> bibleRepository, IRepository<BibleBook> bibleBookRepository)
        {
            _bibleRepository = bibleRepository;
            _bibleBookRepository = bibleBookRepository;
        }
        public List<Bible> Search(string bookName, int chapter, int fromVerse, int toVerse)
        {
            return _bibleRepository.Table.Include("BibleBook").Where(x =>
                    x.BibleBook.Name == bookName &&
                    x.Chapter == chapter &&
                    (x.Verse >= fromVerse && x.Verse <= toVerse))
                                .ToList();
        }

        public List<int> GetChapters(string bookName)
        {
            return
                (_bibleRepository.Table.Include("BibleBook").Where(x => x.BibleBook.Name == bookName).GroupBy(x => x.Chapter).Select(g => g.Key))
                    .ToList();
        }

        public List<int> GetChapters(int bibleBookId)
        {
            return (_bibleRepository.Table.Include("BibleBook").Where(x => x.BibleBook.BibleBookId == bibleBookId).GroupBy(x => x.Chapter).Select(g => g.Key))
                    .ToList();
        }
        public List<BibleBook> GetBibleBooks()
        {
            return _bibleBookRepository.Table.ToList();

        }

        public Bible GetBible(int bibleId)
        {
            return _bibleRepository.Table.Include("BibleBook").First(x => x.BibleId == bibleId);
        }

        public List<Bible> GetBible(int bibleBookId, int chapter)
        {
            return _bibleRepository.Table.Where(x => x.BibleBook.BibleBookId == bibleBookId && x.Chapter == chapter).ToList();
        }
    }
}
