using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// newtonsoft引用
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace test0417_NBA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string dataPath = Application.StartupPath + @"\NBA.txt";


        private void button1_Click(object sender, EventArgs e)
        {
            System.Net.WebClient objWebClient = new System.Net.WebClient();
            objWebClient.DownloadFile("http://data.nba.com/json/cms/noseason/scoreboard/20160302/games.json", Application.StartupPath + @"\NBA.txt");
            button1.Text = "OK";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader r = new System.IO.StreamReader(Application.StartupPath + @"\NBA.txt");
            string nbaJsonString = r.ReadToEnd();
            r.Close();


            // 方法二
            //JToken season = doc.SelectToken(".sports_content.sports_meta.season_meta");

            // 方法三
            // DeserializeObject 優點是嚴謹(解析整份文件)
            //Rootobject obj = JsonConvert.DeserializeObject<Rootobject>(nbaJsonString);
            //button2.Text = obj.sports_content.sports_meta.season_meta.calendar_date;
            JObject doc = JObject.Parse(nbaJsonString); //讀取資料
            // token可能是物件也可能是屬性
            // 資料變更時比較好處理
            JToken dataToken = doc.SelectToken(".sports_content.sports_meta.season_meta.calendar_date");

            textBox1.Text += dataToken.Value<string>() + "\r\n";

            JToken gameList = doc.SelectToken("sports_content.games.game");
            foreach (JToken game in gameList)
            {
                string line = string.Format("{0} @ {1}",
                    game.SelectToken("visitor.team_key").Value<string>(),
                    game.SelectToken("home").Value<string>("team_key"));

                textBox1.Text += line + "\r\n";
            }
        }

        #region json
        public class Rootobject
        {
            public Sports_Content sports_content { get; set; }
        }

        public class Sports_Content
        {
            public Sports_Meta sports_meta { get; set; }
            public Games games { get; set; }
        }

        public class Sports_Meta
        {
            public string date_time { get; set; }
            public Season_Meta season_meta { get; set; }
            public Next next { get; set; }
        }

        public class Season_Meta
        {
            public string calendar_date { get; set; }
            public string season_year { get; set; }
            public string stats_season_year { get; set; }
            public string stats_season_id { get; set; }
            public string stats_season_stage { get; set; }
            public string roster_season_year { get; set; }
            public string schedule_season_year { get; set; }
            public string standings_season_year { get; set; }
            public string season_id { get; set; }
            public string display_year { get; set; }
            public string display_season { get; set; }
            public string season_stage { get; set; }
        }

        public class Next
        {
            public string url { get; set; }
        }

        public class Games
        {
            public Game[] game { get; set; }
        }

        public class Game
        {
            public string id { get; set; }
            public string game_url { get; set; }
            public string season_id { get; set; }
            public string date { get; set; }
            public string time { get; set; }
            public string arena { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string home_start_date { get; set; }
            public string home_start_time { get; set; }
            public string visitor_start_date { get; set; }
            public string visitor_start_time { get; set; }
            public string previewAvailable { get; set; }
            public string recapAvailable { get; set; }
            public string notebookAvailable { get; set; }
            public string tnt_ot { get; set; }
            public string buzzerBeater { get; set; }
            public Ticket ticket { get; set; }
            public Period_Time period_time { get; set; }
            public Lp lp { get; set; }
            public Dl dl { get; set; }
            public Broadcasters broadcasters { get; set; }
            public Visitor1 visitor { get; set; }
            public Home1 home { get; set; }
        }

        public class Ticket
        {
            public string ticket_link { get; set; }
        }

        public class Period_Time
        {
            public string period_value { get; set; }
            public string period_status { get; set; }
            public string game_status { get; set; }
            public string game_clock { get; set; }
            public string total_periods { get; set; }
            public string period_name { get; set; }
        }

        public class Lp
        {
            public string lp_video { get; set; }
            public string condensed_bb { get; set; }
            public Visitor visitor { get; set; }
            public Home home { get; set; }
        }

        public class Visitor
        {
            public Audio audio { get; set; }
            public Video video { get; set; }
        }

        public class Audio
        {
            public string ENG { get; set; }
            public string SPA { get; set; }
        }

        public class Video
        {
            public string avl { get; set; }
            public string onAir { get; set; }
            public string archBB { get; set; }
        }

        public class Home
        {
            public Audio1 audio { get; set; }
            public Video1 video { get; set; }
        }

        public class Audio1
        {
            public string ENG { get; set; }
            public string SPA { get; set; }
        }

        public class Video1
        {
            public string avl { get; set; }
            public string onAir { get; set; }
            public string archBB { get; set; }
        }

        public class Dl
        {
            public Link[] link { get; set; }
        }

        public class Link
        {
            public string name { get; set; }
            public string long_nm { get; set; }
            public string code { get; set; }
            public string url { get; set; }
            public string mobile_url { get; set; }
            public string home_visitor { get; set; }
        }

        public class Broadcasters
        {
            public Radio radio { get; set; }
            public Tv tv { get; set; }
        }

        public class Radio
        {
            public Broadcaster[] broadcaster { get; set; }
        }

        public class Broadcaster
        {
            public string scope { get; set; }
            public string home_visitor { get; set; }
            public string display_name { get; set; }
        }

        public class Tv
        {
            public Broadcaster1[] broadcaster { get; set; }
        }

        public class Broadcaster1
        {
            public string scope { get; set; }
            public string home_visitor { get; set; }
            public string display_name { get; set; }
        }

        public class Visitor1
        {
            public string id { get; set; }
            public string team_key { get; set; }
            public string city { get; set; }
            public string abbreviation { get; set; }
            public string nickname { get; set; }
            public string url_name { get; set; }
            public string team_code { get; set; }
            public string score { get; set; }
            public Linescores linescores { get; set; }
        }

        public class Linescores
        {
            public Period[] period { get; set; }
        }

        public class Period
        {
            public string period_value { get; set; }
            public string period_name { get; set; }
            public string score { get; set; }
        }

        public class Home1
        {
            public string id { get; set; }
            public string team_key { get; set; }
            public string city { get; set; }
            public string abbreviation { get; set; }
            public string nickname { get; set; }
            public string url_name { get; set; }
            public string team_code { get; set; }
            public string score { get; set; }
            public Linescores1 linescores { get; set; }
        }

        public class Linescores1
        {
            public Period1[] period { get; set; }
        }

        public class Period1
        {
            public string period_value { get; set; }
            public string period_name { get; set; }
            public string score { get; set; }
        }
        #endregion
    }
}
