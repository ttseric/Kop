using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Data
{
    public class ParseBibileService
    {
        private readonly List<BibleBook> _bibleBooks = new List<BibleBook>();

        public List<BibleBook> BibleBooks
        {
            get { return _bibleBooks; }
        }

        public void Execute()
        {
            var books = new Dictionary<string, BibleBook>();


            string fileText = File.ReadAllText(@"c:\KopResource\hb5.txt");
            string[] fileLines = fileText.Split('\n');

            foreach (var line in fileLines)
            {
                if (string.IsNullOrEmpty(line) == false)
                {
                    var bibleLines = line.Split(' ');
                    var b = new Bible();
                    BibleBook book;

                    if (!books.ContainsKey(bibleLines[0]))
                    {
                        book = new BibleBook();
                        book.Name = bibleLines[0];
                        book.NameChi = ChiName(book.Name);
                        book.NameChiAbbr = ChiNameAbbr(book.Name);
                        book.Index = Index(book.Name);
                        books.Add(book.Name, book);
                    }
                    else
                    {
                        book = books[bibleLines[0]];
                    }

                    b.Chapter = Convert.ToInt16(bibleLines[1].Split(':')[0]);
                    b.Verse = Convert.ToInt16(bibleLines[1].Split(':')[1]);
                    b.Text = bibleLines[2];

                    book.Bibles.Add(b);
                }
            }

            foreach (var book in books)
            {
                BibleBooks.Add(book.Value);
            }
        }

        public string ChiName(string bookName)
        {
            var bookNameDictionary = new Dictionary<string, string>
                {
                    {"Gen","創世紀"}, 
                    {"Exo","出埃及記"},                    
                    {"Lev","利未記"},
                    {"Num","民數記"},
                    {"Deu","申命記"},
                    {"Jos","約書亞記"},
                    {"Jug","士師記"}, 
                    {"Rut","路得記"}, 
                    {"1Sa","撒母爾記上"},
                    {"2Sa","撒母爾記下"},
                    {"1Ki","列王記上"},
                    {"2Ki","列王記下"}, 
                    {"1Ch","歷代誌上"}, 
                    {"2Ch","歷代誌下"},
                    {"Ezr","以斯拉書"}, 
                    {"Neh","尼希米記"},
                    {"Est","以斯帖記"}, 
                    {"Job","約伯記"},
                    {"Psm","詩篇"}, 
                    {"Pro","箴言"}, 
                    {"Ecc","傳道書"},
                    {"Son","雅歌"}, 
                    {"Isa","以賽亞書"},
                    {"Jer","耶利米書"},
                    {"Lam","耶利米哀歌"},
                    {"Eze","以西結書"},
                    {"Dan","但以理書"},
                    {"Hos","何西阿書"}, 
                    {"Joe","約珥書"},
                    {"Amo","阿摩斯書"},
                    {"Oba","俄巴底亞書"}, 
                    {"Jon","約拿書"}, 
                    {"Mic","彌迦書"},
                    {"Nah","那鴻"}, 
                    {"Hab","哈巴谷書"}, 
                    {"Zep","西番亞書"}, 
                    {"Hag","哈該書"}, 
                    {"Zec","撒加利亞書"},
                    {"Mal","瑪拉基書"},
                    {"Mat","馬太福音"},
                    {"Mak","馬可福音"},
                    {"Luk","路加福音"}, 
                    {"Jhn","約翰福音"},  
                    {"Act","使徒行傳"}, 
                    {"Rom","羅馬人書"}, 
                    {"1Co","哥林多前書"},
                    {"2Co","哥林多後書"},
                    {"Gal","加拉太書"}, 
                    {"Eph","以弗所書"},
                    {"Phl","腓力比書"}, 
                    {"Col","哥羅西書"},
                    {"1Ts","帖撒羅尼迦前書"},        
                    {"2Ts","帖撒羅尼迦後書"},
                    {"1Ti","提摩太前書"},
                    {"2Ti","提摩太後書"}, 
                    {"Tit","提多書"},   
                    {"Phm","斐利門書"},
                    {"Heb","希伯來書"}, 
                    {"Jas","雅各書"},         
                    {"1Pe","彼得前書"},                  
                    {"2Pe","彼得後書"}, 
                    {"1Jn","約翰一書"}, 
                    {"2Jn","約翰二書"}, 
                    {"3Jn","約翰三書"},                     
                    {"Jud","猶大書"},   
                    {"Rev","啓示錄"}, 
                };

            return bookNameDictionary[bookName];
        }

        public string ChiNameAbbr(string bookName)
        {
            var bookNameDictionary = new Dictionary<string, string>
                {
                    {"Gen","創"}, 
                    {"Exo","出"},                    
                    {"Lev","利"},
                    {"Num","民"},
                    {"Deu","申"},
                    {"Jos","書"},
                    {"Jug","士"}, 
                    {"Rut","得"}, 
                    {"1Sa","撒上"},
                    {"2Sa","撒下"},
                    {"1Ki","王上"},
                    {"2Ki","王下"}, 
                    {"1Ch","代上"}, 
                    {"2Ch","代下"},
                    {"Ezr","拉"}, 
                    {"Neh","尼"},
                    {"Est","斯"}, 
                    {"Job","伯"},
                    {"Psm","詩"}, 
                    {"Pro","箴"}, 
                    {"Ecc","傳"},
                    {"Son","歌"}, 
                    {"Isa","賽"},
                    {"Jer","耶"},
                    {"Lam","哀"},
                    {"Eze","結"},
                    {"Dan","但"},
                    {"Hos","何"}, 
                    {"Joe","珥"},
                    {"Amo","摩"},
                    {"Oba","俄"}, 
                    {"Jon","拿"}, 
                    {"Mic","彌"},
                    {"Nah","鴻"}, 
                    {"Hab","哈"}, 
                    {"Zep","番"}, 
                    {"Hag","該"}, 
                    {"Zec","亞"},
                    {"Mal","瑪"},
                    {"Mat","太"},
                    {"Mak","可"},
                    {"Luk","路"}, 
                    {"Jhn","約"},  
                    {"Act","徒"}, 
                    {"Rom","羅"}, 
                    {"1Co","林前"},
                    {"2Co","林後"},
                    {"Gal","加"}, 
                    {"Eph","弗"},
                    {"Phl","腓"}, 
                    {"Col","西"},
                    {"1Ts","帖前"},        
                    {"2Ts","帖後"},
                    {"1Ti","提前"},
                    {"2Ti","提後"}, 
                    {"Tit","多"},   
                    {"Phm","門"},
                    {"Heb","來"}, 
                    {"Jas","雅"},         
                    {"1Pe","彼前"},                  
                    {"2Pe","彼後"}, 
                    {"1Jn","約一"}, 
                    {"2Jn","約二"}, 
                    {"3Jn","約三"},                     
                    {"Jud","猶"},   
                    {"Rev","啓"}, 
                };

            return bookNameDictionary[bookName];
        }

        public int Index(string bookName)
        {
            var bookNameDictionary = new Dictionary<string, int>
                {
                    {"Gen",1}, 
                    {"Exo",2},                    
                    {"Lev",3},
                    {"Num",4},
                    {"Deu",5},
                    {"Jos",6},
                    {"Jug",7}, 
                    {"Rut",8}, 
                    {"1Sa",9},
                    {"2Sa",10},
                    {"1Ki",11},
                    {"2Ki",12}, 
                    {"1Ch",13}, 
                    {"2Ch",14},
                    {"Ezr",15}, 
                    {"Neh",16},
                    {"Est",17}, 
                    {"Job",18},
                    {"Psm",19}, 
                    {"Pro",20}, 
                    {"Ecc",21},
                    {"Son",22}, 
                    {"Isa",23},
                    {"Jer",24},
                    {"Lam",25},
                    {"Eze",26},
                    {"Dan",27},
                    {"Hos",28}, 
                    {"Joe",29},
                    {"Amo",30},
                    {"Oba",31}, 
                    {"Jon",32}, 
                    {"Mic",33},
                    {"Nah",34}, 
                    {"Hab",35}, 
                    {"Zep",36}, 
                    {"Hag",37}, 
                    {"Zec",38},
                    {"Mal",39},
                    {"Mat",40},
                    {"Mak",41},
                    {"Luk",42}, 
                    {"Jhn",43},  
                    {"Act",44}, 
                    {"Rom",45}, 
                    {"1Co",46},
                    {"2Co",47},
                    {"Gal",48}, 
                    {"Eph",49},
                    {"Phl",50}, 
                    {"Col",51},
                    {"1Ts",52},        
                    {"2Ts",53},
                    {"1Ti",54},
                    {"2Ti",55}, 
                    {"Tit",56},   
                    {"Phm",57},
                    {"Heb",58}, 
                    {"Jas",59},         
                    {"1Pe",60},                  
                    {"2Pe",61}, 
                    {"1Jn",62}, 
                    {"2Jn",63}, 
                    {"3Jn",64},                     
                    {"Jud",65},   
                    {"Rev",66}, 
                };

            return bookNameDictionary[bookName];
        }
    }
}
