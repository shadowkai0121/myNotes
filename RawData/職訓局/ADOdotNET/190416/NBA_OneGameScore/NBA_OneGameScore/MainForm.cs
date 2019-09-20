using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace NBA_OneGameScore {
    public partial class MainForm : Form {
        ToolTip objToolTip = new ToolTip();

        public MainForm() {
            InitializeComponent();

            cboGameDate.Value = DateTime.Now.AddDays(-1);
            chartScore.ChartAreas[0].CursorX.LineColor = Color.LightGray;
            chartScore.ChartAreas[0].CursorY.LineColor = Color.LightGray;
            objToolTip.InitialDelay = 0;
        }


        // private CookieContainer _objCookieContainer = new CookieContainer();
        private string GrabHtmlPage(string sUrl) {
            string sPage = "";
            try {
                HttpWebRequest objHttpWebRequest = HttpWebRequest.Create(sUrl) as HttpWebRequest;
                // objHttpWebRequest.CookieContainer = _objCookieContainer;
                WebResponse objWebResponse = objHttpWebRequest.GetResponse();
                Stream objResponseStream = objWebResponse.GetResponseStream();
                StreamReader objReader = new StreamReader(objResponseStream);
                sPage = objReader.ReadToEnd();
            }
            catch {
                sPage = "Error";
            }
            return sPage;
        }

        private void DownloadAndShowGame()
        {
            // init.
            lblMinMax.Text = "";
            chartScore.Series["expectedScore"].Points.Clear();
            chartScore.Series["avgScore"].Points.Clear();
            chartScore.Series["pace"].Points.Clear();
            int iPeriod = 1;
            int iCurrentTotal = 0;
            int iCurrentPace = 0;
            int[,] minMax = { { 999, 0 }, { 999, 0 }, { 999, 0 }, { 999, 0 }, { 999, 0 } };
            double[] margin = { 0, 0, 0, 0, 0 };
            int iMinutesPerQuarter = Properties.Settings.Default.MinutesPerQuarter;
            int iAvgLineTraceCount = Properties.Settings.Default.AvgLineTraceCount;
            int iPaceAvgLineTraceCount = Properties.Settings.Default.PaceAvgLineTraceCount;
            int iSecondsPerSlice = Properties.Settings.Default.SecondsPerSlice;
            double nBookTotal = Convert.ToDouble(txtBookTotal.Text);
            double nPointsPerSecond = nBookTotal / (iMinutesPerQuarter * 60 * 4);
            chartScore.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;

            int iLastTimeSlice = 0;
            int[] scoresList = new int[iMinutesPerQuarter * 60 * 4 / iSecondsPerSlice + 1];
            double[] paceList = new double[iMinutesPerQuarter * 60 * 4 / iSecondsPerSlice + 1];
            double[] intervalPaceList = new double[iMinutesPerQuarter * 60 * 4 / iSecondsPerSlice + 1];
            for (int iTimeSlice = 0; iTimeSlice < scoresList.Length; iTimeSlice++)
            {
                scoresList[iTimeSlice] = -1;
                paceList[iTimeSlice] = -1;
            }
            iLastTimeSlice = iMinutesPerQuarter * 60 * 4 / iSecondsPerSlice;
            scoresList[iLastTimeSlice] = 0;
            paceList[iLastTimeSlice] = 0;

            // Download Json data from NBA
            string sGameId = cboMatchup.Text.Substring(8);
            string sUrl = string.Format("http://data.nba.com/10s/json/cms/noseason/game/{0}/{1}/pbp_{2}.json",
                cboGameDate.Value.ToString("yyyyMMdd"),
                sGameId,
                "all"
                );
            string sJson = GrabHtmlPage(sUrl);
            if (sJson.Length <= 20)
            {
                this.Text = "Cannot get JSON data.";
                return;
            }
            JObject oJson = JObject.Parse(sJson);

            // Parse each play.
            var plays = oJson.SelectToken("sports_content.game.play");
            foreach (var oPlay in plays)
            {
                iPeriod = oPlay.Value<int>("period");
                if (iPeriod > 4)
                {  // 暫不考慮 OT
                    this.Text += " OT!!";
                    break;
                }

                string sDescription = oPlay.Value<string>("description");
                lblEvent1.Text = lblEvent2.Text;
                lblEvent2.Text = sDescription;
                if (
                    sDescription.Contains("Missed") ||
                    sDescription.Contains("Made") ||
                    sDescription.Contains("Free Throw")
                    )
                {

                    string sTimeAndScore = oPlay.Value<string>("clock");
                    if (sTimeAndScore.Length <= 3)
                        continue;
                    int iMinute = Convert.ToInt32(sTimeAndScore.Substring(0, 2));
                    int iSecond = Convert.ToInt32(sTimeAndScore.Substring(3, 2));
                    int iRemain = iMinute * 60 + iSecond +
                        ((4 - iPeriod) * iMinutesPerQuarter * 60);
                    iCurrentTotal = oPlay.Value<int>("visitor_score") + oPlay.Value<int>("home_score");
                    iLastTimeSlice = iRemain / iSecondsPerSlice;
                    scoresList[iLastTimeSlice] = iCurrentTotal;

                    if (sDescription.Contains("Missed") ||
                        sDescription.Contains("Made") ||
                        sDescription.Contains("2 of 2")
                        )
                    {
                        iCurrentPace += 1;
                        paceList[iLastTimeSlice] = iCurrentPace;
                    }
                }  // Missed or Made or Free Throw

            }  // end of eachPlay
            for (int iTimeSlice = iMinutesPerQuarter * 60 * 4 / iSecondsPerSlice; iTimeSlice >= iLastTimeSlice; iTimeSlice--)
            {
                if (scoresList[iTimeSlice] == -1)
                {
                    scoresList[iTimeSlice] = scoresList[iTimeSlice + 1];
                }
                if (paceList[iTimeSlice] == -1)
                {
                    paceList[iTimeSlice] = paceList[iTimeSlice + 1];
                }
            }

            // pace for each time slice
            for (int iTimeSlice = iLastTimeSlice;
                iTimeSlice < (iMinutesPerQuarter * 60 * 4 / iSecondsPerSlice);
                iTimeSlice++)
            {
                paceList[iTimeSlice] = paceList[iTimeSlice] - paceList[iTimeSlice + 1];
            }
            for (int iTimeSlice = iLastTimeSlice;
                iTimeSlice < (iMinutesPerQuarter * 60 * 4 / iSecondsPerSlice);
                iTimeSlice++)
            {
                double nIntervalPace = 0;
                for (int i = 0; i < iPaceAvgLineTraceCount; i++)
                {
                    if (iTimeSlice + i <= (iMinutesPerQuarter * 60 * 4 / iSecondsPerSlice))
                    {
                        nIntervalPace += paceList[iTimeSlice + i];
                    }
                }
                intervalPaceList[iTimeSlice] = nIntervalPace;
            }


            // draw and report
            for (int iTimeSlice = iMinutesPerQuarter * 60 * 4 / iSecondsPerSlice; iTimeSlice >= iLastTimeSlice; iTimeSlice--)
            {
                int iRemain = iTimeSlice * iSecondsPerSlice;
                int iExpectedScore = Convert.ToInt32(Math.Floor(
                    scoresList[iTimeSlice] + nPointsPerSecond * iTimeSlice * iSecondsPerSlice));
                if (iExpectedScore < minMax[0, 0])
                    minMax[0, 0] = iExpectedScore;
                if (iExpectedScore > minMax[0, 1])
                    minMax[0, 1] = iExpectedScore;
                if (iExpectedScore < minMax[4 - iTimeSlice / (iMinutesPerQuarter * 60 / iSecondsPerSlice), 0])
                    minMax[4 - iTimeSlice / (iMinutesPerQuarter * 60 / iSecondsPerSlice), 0] = iExpectedScore;
                if (iExpectedScore > minMax[4 - iTimeSlice / (iMinutesPerQuarter * 60 / iSecondsPerSlice), 1])
                    minMax[4 - iTimeSlice / (iMinutesPerQuarter * 60 / iSecondsPerSlice), 1] = iExpectedScore;
                chartScore.Series["expectedScore"].Points.AddY(iExpectedScore);

                // Avg Line:
                double nAvgTotal = 0;
                double nTotal = 0;
                int iCount = 0;
                int iIndex = chartScore.Series["expectedScore"].Points.Count - 1;
                while (iIndex >= 0 && iCount < iAvgLineTraceCount)
                {
                    iCount += 1;
                    nTotal += (int)chartScore.Series["expectedScore"].Points[iIndex].YValues[0];
                    iIndex -= 1;
                }
                if (iCount > 0)
                {
                    nAvgTotal = nTotal / iCount;
                    chartScore.Series["avgScore"].Points.AddY(nAvgTotal);
                    // margin:
                    margin[0] += (iExpectedScore - nAvgTotal);
                    margin[4 - iTimeSlice / (iMinutesPerQuarter * 60 / iSecondsPerSlice)] +=
                        (iExpectedScore - nAvgTotal);
                }
                else
                {
                    chartScore.Series["avgScore"].Points.AddY(iExpectedScore);
                }

            }

            // draw pace
            if (chkPace.Checked)
            {
                for (int iTimeSlice = iMinutesPerQuarter * 60 * 4 / iSecondsPerSlice; iTimeSlice >= iLastTimeSlice; iTimeSlice--)
                {
                    chartScore.Series["pace"].Points.AddY(minMax[0, 0] - 2 + intervalPaceList[iTimeSlice]);
                    // chartScore.Series["pace"].Points.AddY(190 + intervalPaceList[iTimeSlice]);
                }
            }


            // Text report:
            lblMinMax.Text = string.Format("Min: {0}, Max: {1}", minMax[0, 0], minMax[0, 1]);
            for (int iQuarter = 1; iQuarter <= 4; iQuarter++)
            {
                if (minMax[iQuarter, 0] < 999)
                    lblMinMax.Text += string.Format("  Q{0}({1}~{2})",
                        iQuarter, minMax[iQuarter, 0], minMax[iQuarter, 1]);
            }

            lblMinMax.Text += "   Total: " + iCurrentTotal.ToString();
            chartScore.ChartAreas[0].AxisY.Minimum = minMax[0, 0] - 2;
            chartScore.ChartAreas[0].AxisY.Maximum = minMax[0, 1] + 2;


            string sMargin = "";
            for (int i = 1; i < margin.Length; i++)
            {
                sMargin += string.Format("Q{0}: {1:N1}   |   ", i, margin[i]);
            }
            sMargin = string.Format("Overall: {0:N1}   |   ", margin[0]) + sMargin;
            lblMargin.Text = sMargin;
        }  // end of DownloadAndShowGame

        private void cboGameDate_ValueChanged(object sender, EventArgs e) {
            // workerDownloadGameList.RunWorkerAsync();
            // Debug:
            try {
                workerDownloadGameList_DoWork(null, null);
            }
            catch {
                cboGameDate.Value = new DateTime(2018, 3, 1);
            }
        }

        private void cboMatchup_SelectedIndexChanged(object sender, EventArgs e) {
            this.Text = cboMatchup.Text.Substring(0, 7);

            lblMinMax.Text = "--";
            lblMargin.Text = "--";
            chartScore.Series["expectedScore"].Points.Clear();
            chartScore.Series["avgScore"].Points.Clear();
            chartScore.Series["pace"].Points.Clear();
            lblEvent1.Text = "--";
            lblEvent2.Text = "--";
        }

        private void btnGo_Click(object sender, EventArgs e) {
            DownloadAndShowGame();
        }

        private void timerRefresh_Tick(object sender, EventArgs e) {
            DownloadAndShowGame();
        }

        private void txtRefreshSeconds_TextChanged(object sender, EventArgs e) {
            int iSecond = 0;
            try {
                iSecond = Convert.ToInt32(txtRefreshSeconds.Text);
            }
            catch {

            }
            timerRefresh.Interval = (iSecond > 0) ? iSecond * 1000 : 300000;
            timerRefresh.Enabled = (iSecond > 6) ? true : false;
        }

        private void notifyIconMain_DoubleClick(object sender, EventArgs e) {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Visible = false;
            }
        }

        private void workerDownloadGameList_DoWork(object sender, DoWorkEventArgs e) {
            cboGameDate.Enabled = false;
            cboMatchup.Enabled = false;
            btnGo.Enabled = false;
            cboMatchup.Items.Clear();
            string sUrl = string.Format(
                "http://data.nba.com/json/cms/noseason/scoreboard/{0}/games.json",
                cboGameDate.Value.ToString("yyyyMMdd"));
            string sGamesJson = GrabHtmlPage(sUrl);

            JObject oJson = JObject.Parse(sGamesJson);

            var games = oJson.SelectToken("sports_content.games.game");
            foreach (var oGame in games) {
                string sItem = string.Format("{0}@{1} {2}",
                    oGame.SelectToken("visitor.team_key"),
                    oGame.SelectToken("home.team_key"),
                    oGame.Value<string>("id")
                    );
                cboMatchup.Items.Add(sItem);
            }
            cboMatchup.SelectedIndex = 0;
            cboGameDate.Enabled = true;
            cboMatchup.Enabled = true;
            btnGo.Enabled = true;
        }

        private void chartScore_MouseMove(object sender, MouseEventArgs e) {
            if (chartScore.Series["expectedScore"].Points.Count > 0) {
                Point pointMouse = new Point(e.X, e.Y);
                chartScore.ChartAreas[0].CursorX.SetCursorPixelPosition(pointMouse, true);
                chartScore.ChartAreas[0].CursorY.SetCursorPixelPosition(pointMouse, true);
            }
        }

        private void chartScore_GetToolTipText(object sender, ToolTipEventArgs e) {
            if (e.HitTestResult.PointIndex >= 0) {
                Point pointToolTip = new Point(e.X, e.Y - 16);
                if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint) {
                    var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                    objToolTip.Show(string.Format("{0}", dataPoint.YValues[0]), chartScore, pointToolTip, 5000);
                }
            }
        }

        private void chartScore_MouseLeave(object sender, EventArgs e) {
            chartScore.ChartAreas[0].CursorX.Position = double.NaN;
            chartScore.ChartAreas[0].CursorY.Position = -1;
        }

        private void chkPace_CheckedChanged(object sender, EventArgs e) {
            DownloadAndShowGame();
        }
    }
}
