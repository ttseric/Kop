using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kop.Core;

namespace Kop.Data
{
    //public class DropCreateDatabaseIfModelChangeWithSeed : DropCreateDatabaseAlways<KopDataContext>
    public class DropCreateDatabaseIfModelChangeWithSeed : DropCreateDatabaseIfModelChanges<KopDataContext>
    {
        protected override void Seed(KopDataContext context)
        {
            BuildAnonymous(context);
            BuildCountry(context);
            BuildBible(context);
            BuildPrayerCategoryTemplate(context);
            BuildPrayeTemplateCategory(context);
        }

        private void BuildPrayeTemplateCategory(KopDataContext context)
        {
            var category1 = new PrayerTemplateCategory { Name = "家庭" };
            var category2 = new PrayerTemplateCategory { Name = "夫妻" };
            var category3 = new PrayerTemplateCategory { Name = "工作" };
            var category4 = new PrayerTemplateCategory { Name = "教會" };
            var category5 = new PrayerTemplateCategory { Name = "國家" };
            var category6 = new PrayerTemplateCategory { Name = "情緒" };
            var category7 = new PrayerTemplateCategory { Name = "學業" };

            context.PrayerTemplateCategories.Add(category1);
            context.PrayerTemplateCategories.Add(category2);
            context.PrayerTemplateCategories.Add(category3);
            context.PrayerTemplateCategories.Add(category4);
            context.PrayerTemplateCategories.Add(category5);
            context.PrayerTemplateCategories.Add(category6);
            context.PrayerTemplateCategories.Add(category7);
        }

        private void BuildPrayerCategoryTemplate(KopDataContext context)
        {
            var category = new PrayerTemplateCategory();
            var template = new PrayerTemplate();
            var detail = new StringBuilder();

            category.Name = "經典";


            detail.AppendLine("主啊! 使我作您和平之子");
            detail.AppendLine("");
            detail.AppendLine("在憎恨之處播下您的愛 在傷痕之處播下您寬恕");
            detail.AppendLine("在懷疑之處播下信心     在絕望之處播下您的盼望");
            detail.AppendLine("在幽暗之處播下您的光明 在憂愁之處播下您的歡愉");
            detail.AppendLine("在赦免時我們便蒙赦免   在捨去時我們便有所得");
            detail.AppendLine("迎接死亡時 我們便進入永生");
            detail.AppendLine("");
            detail.AppendLine("主啊 使我少為自己求");
            detail.AppendLine("");
            detail.AppendLine("少求受安慰 但求安慰人 少求被瞭解 但求瞭解人");
            detail.AppendLine("少求愛 但求全心付出愛");

            template.PrayerTemplateCategory = category;
            template.Detail = detail.ToString();
            template.Introduction ="聖方濟各的禱文是基督徒的禱文，於十三世紀由聖徒聖法蘭西斯（聖方濟各）所作。這篇禱文自1936年起於美國流行，西普曼樞機和參議員侯勤士於第二次世界大戰期間，開始大量印發這篇禱文";
            template.Name = "聖法蘭西斯禱文";

            context.PrayerTemplateCategories.Add(category);
            context.PrayerTemplates.Add(template);
        }

        private void BuildBible(KopDataContext context)
        {
            var service = new ParseBibileService();
            service.Execute();

            foreach (var bible in service.BibleBooks)
            {
                context.BibleBooks.Add(bible);
            }
        }

        private void BuildAnonymous(KopDataContext context)
        {
            var user = new User { Name = "無名氏", LoginName="anonymous", Password = "Ha123456", Country = new Country { NameChi = "沒有提拱", NameEng = "None" } };

            user.RequestPrayers.Add(new Prayer()
                {
                    Detail =
                        "求神幫助我的弟兄-許馬來，因他身體的違和與精神上的鬱悶；希望他心情能夠平靜安穩， 求神給他剛強，求神醫治他的心靈，請他釋放心中的 不滿與情緒 ，求神將自由、喜樂的靈充滿他。引導他從困惑中走出。奉主耶穌的名求 阿門",
                    From = "馬來西亞",
                    SubmitDate = DateTime.Now,
                    RequestBy = user
                });

            user.RequestPrayers.Add(new Prayer()
                {
                    Detail =
                        "慈愛的天父 與我同在的聖靈，感謝主耶穌基督常常垂聽我的禱告，因為祢是幫助我們的神. 神的話是我腳前的燈，路上的光，我愛慕你的話！依靠神的力量使我們有信心突破困難 靠著聖靈，隨時多方禱告祈求；並要在此儆醒不倦，為眾聖徒祈求。(弗 6：18) 主阿聖經上說約伯為他的朋友祈禱.耶和華就使約伯從苦境轉回， 並且耶和華賜給他的比他從前所有的加倍. 感謝主！我們長期有愛心弟兄姐妹一直為我們代禱.希望我們能從苦境翻轉能蒙神祝福 祈求神幫助李治國弟兄為了事業打拼.經濟能除去愁苦煩惱精神上壓力˙ 求神醫治憐憫我丈夫 靈魂興盛、身體健壯、凡事興盛聖潔 * 主求祢回應我在為丈夫禱告的各樣事情上，祢知道我們的狀況和需要， 求祢恩膏塗抹他的工作計畫，供應他的需求， 在工作上充滿恩惠*求給我們 盼望和信心.不再被仇敵控告 主啊!我做不得甚麼,唯有倚靠你才能成就 詩篇 16:5 耶和華是我的產業，是我杯中的分；我所得的，祢為我持守。 主阿，你知道他在工作總是盡心盡力*認真用心負責.但總有許多試探.攪擾攻擊他 求主看顧保守李治國弟兄公司營造工程營運都十分平安蒙福，凡事順利 堅立他手所做的工能成事* 使他得著祢的祝福恩典 主啊，願將一切榮要都歸給祢！憑我們一己之力不能辦到，但在祢沒有難成的事！ 祢是天天背負黃姊妹及丈夫治國弟兄.我們重擔的救主 願 神賜福給愛祂的人，都要承受貨財，並充滿在他們的府庫， 使他們樣樣都有，且充足有餘。(箴 8：21) 祈願所有誠心愛我們主耶穌基督的人都蒙恩惠！求主呼召更多靈魂體興盛的弟兄姊妹為我們夫妻經濟家庭需要守望禱告 (因為真的很需要 感謝禱告和祈求奉主耶穌的聖名。阿們 ",
                    From = "新加坡",
                    SubmitDate = DateTime.Now,
                    RequestBy = user
                });

            user.RequestPrayers.Add(new Prayer()
                {
                    Detail = "求主保守孩子魏开阳的平安，求主坚立北京中关村四小的圣工，愿主的名在中关村四小得荣耀！感谢弟兄姊妹们的支持！",
                    From = "台中",
                    SubmitDate = DateTime.Now,
                    RequestBy = user
                });

            user.RequestPrayers.Add(new Prayer()
                {
                    Detail =
                        "主耶穌，我們身為神的兒女的要奉袮的名綑綁台灣上空那淫亂；縱慾；逆性；自大；悖逆與違逆真理道德的邪惡權勢，求袮從天上伸手攔阻這些同性婚姻法案的通過；敗壞那惡者的計謀，也求袮在立法院興起為真理發聲的領袖，制止這些不義的法案，讓我們的年輕人可以聽到更多真理與聖潔的教導。感謝袮把為國家與領導者禱告的權柄與責任託付我們，求袮讓我們在此事上盡忠。奉耶穌得勝的尊名禱告，阿們！",
                    From = "日本",
                    SubmitDate = DateTime.Now,
                    RequestBy = user
                });

            user.RequestPrayers.Add(new Prayer()
                {
                    Detail = "為簡如汶基測有聖靈的引導耶穌寶血遮蓋,自己有完全的準備.願主保守一切順利.奉耶穌的名禱告,阿们!",
                    From = "旺角",
                    SubmitDate = DateTime.Now,
                    RequestBy = user
                });
            user.RequestPrayers.Add(new Prayer()
                {
                    Detail =
                        "我今年37歲了～請求為我從小就被邪靈攪擾，鬼附～世代家族貧困、貧窮，家暴婚姻破碎，人際關係常受集體霸凌（小時學校，長大公司）總是只能從事見不了光抬不起頭的工作（八大行業清潔工等）～無論我多麼努力總是脫離不了這樣的事情臨到我～請為我代禱這些相同的事可以停止，不要再繼續在我身上發生～也請為我的兒子能脫離這些兇惡不好的咒詛代禱…（這些都是真實發生在我身上的事情，主內弟兄姐妹在我經歷過的教會已經看見很多表面說信上帝可是確跟外面不信主的人相同～所以別再跟我說妳怎麼不尋求教會幫助～）",
                    From = "長沙灣",
                    SubmitDate = DateTime.Now,
                    RequestBy = user
                });
            user.RequestPrayers.Add(new Prayer()
                {
                    Detail =
                        "弟兄姊妹们，主内平安！在行走天路的过程中，急切盼望得到主内的代祷支持，因为圣工的原因可能使孩子陷入到危险当中，请求弟兄姊妹为以下的内容持续代祷：求主保守孩子魏开阳的平安，求主坚立北京中关村四小的圣工，愿主的名在中关村四小得荣耀！感谢弟兄姊妹们的支持！",
                    From = "九龍",
                    SubmitDate = DateTime.Now,
                    RequestBy = user
                });
            user.RequestPrayers.Add(new Prayer()
                {
                    Detail =
                        "主耶穌，我們身為神的兒女的要奉袮的名綑綁台灣上空那淫亂；縱慾；逆性；自大；悖逆與違逆真理道德的邪惡權勢，求袮從天上伸手攔阻這些同性婚姻法案的通過；敗壞那惡者的計謀，也求袮在立法院興起為真理發聲的領袖，制止這些不義的法案，讓我們的年輕人可以聽到更多真理與聖潔的教導。感謝袮把為國家與領導者禱告的權柄與責任託付我們，求袮讓我們在此事上盡忠。奉耶穌得勝的尊名禱告，阿們！",
                    From = "廣州",
                    SubmitDate = DateTime.Now,
                    RequestBy = user
                });

            var prayerAnswer = new PrayerAnswer();

            prayerAnswer.Detail = "神真的是聽禱告的神!";
            prayerAnswer.CreateDate = DateTime.Now;

            user.RequestPrayers.Add(new Prayer()
                {
                    Detail = "為簡如汶基測有聖靈的引導耶穌寶血遮蓋,自己有完全的準備.願主保守一切順利.奉耶穌的名禱告,阿们!",
                    From = "上海",
                    SubmitDate = DateTime.Now,
                    RequestBy = user,
                    PrayerAnswer = prayerAnswer
                });

            context.Users.Add(user);
        }

        private void BuildCountry(KopDataContext context)
        {
            context.Countries.Add(new Country { NameEng = "China", NameChi = "中國" });
            context.Countries.Add(new Country { NameEng = "Hong Kong", NameChi = "香港" });
            context.Countries.Add(new Country { NameEng = "Taiwan", NameChi = "台灣" });
            context.Countries.Add(new Country { NameEng = "Macao", NameChi = "澳門" });
        }
    }
}
