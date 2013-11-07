using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Services.Bibles
{
    public interface IBibleService
    {
        List<Bible> Search(string bookName, int chapter, int fromVerse, int toVerse);
        List<BibleBook> GetBibleBooks();
        List<int> GetChapters(string bookName);
        List<int> GetChapters(int bibleBookId);
        Bible GetBible(int bibleId);
        List<Bible> GetBible(int bibleBookId, int chapter);
    }
}
