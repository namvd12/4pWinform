
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
using System.Runtime.Serialization;
using Axis = LiveCharts.Wpf.Axis;
using System.Collections.ObjectModel;
using LiveCharts.SeriesAlgorithms;
using GiamSat.model;
using static GiamSat.model.DataAnalysis;
using GiamSat.viewDb;
using MySqlX.XDevAPI;
using System.Reflection.PortableExecutable;
using System.Windows.Media.Animation;

using System.Globalization;
using static GiamSat.model.HistoryNG;
using Org.BouncyCastle.Utilities.Collections;
using System.Windows.Markup;
using Google.Protobuf.WellKnownTypes;
using System;


namespace GiamSat.View.ShowReporting
{
    public partial class VisualReporting : Form
    {
        DataAnalysis dataAnalys = new DataAnalysis();
        HistoryNG historyNG = new HistoryNG();

        private int numLine = 9;

        private Main mAppInstance;

        public Main CalledMainDb
        {
            get
            {
                return mAppInstance;
            }
            set
            {
                mAppInstance = value;
                dataAnalys.database = mAppInstance.MainDatabase;
                historyNG.database = mAppInstance.MainDatabase;
            }
        }
        public enum ReportType
        {
            Data_AllLine,
            Data_EachLine,
            Data_MTTR,
            Data_MTBF
        };

        public enum TimeSearch
        {
            Day,
            Week,
            Month,
        };

        private ReportType g_reportType = ReportType.Data_AllLine;
        public VisualReporting(ReportType type)
        {
            InitializeComponent();
            g_reportType = type;
            cb_week.SelectedIndex = 0;
            cb_month.SelectedIndex = 0;
        }

        public void set(ReportType type, Dictionary<string, dataReport> data)
        {
            List<string> lsLable = new List<string>();

            g_reportType = type;

            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double> {},
                    LabelPoint = point => point.Y + "",
                    DataLabels = true,
                    FontSize = 20.0,
                    MaxColumnWidth = 40,
                },
                new LineSeries
                {
                    Name = "tens",
                    Values = new ChartValues<double> {},
                    LabelPoint = point => point.Y/30 + "",
                    Foreground = System.Windows.Media.Brushes.OrangeRed,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    FontSize = 15.0,
                    LineSmoothness = 0,                                       
                },
            };

            for (int i = 0; i < data.Count; i++)
            {
                double timeFail = (double)data[data.Keys.ElementAt(i)].timeFail;
                double numfail = (double)data[data.Keys.ElementAt(i)].numFail * 30;
                cartesianChart1.Series[0].Values.Add(timeFail);
                cartesianChart1.Series[1].Values.Add(numfail); // scale *20

                lsLable.Add(data.Keys.ElementAt(i));
            }

            /* Add lable X*/
            var XAxes = new Axis();
            XAxes.Labels = lsLable;
            XAxes.FontSize = 16.0;
            XAxes.FontWeight = System.Windows.FontWeights.Bold;
            XAxes.Foreground = System.Windows.Media.Brushes.Black;
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(XAxes);

            /* Disable lable Y*/

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Labels = new string[0],
                MinValue = 0
            });
        }
        private int calWeekOfYear(DateTime time)
        {
            var d = time;
            CultureInfo cul = CultureInfo.CurrentCulture;

            int weekNum = cul.Calendar.GetWeekOfYear(
                d,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);

            return weekNum;

        }
        public void setMTTR_MTBF(ReportType type, TimeSearch time, Dictionary<DateTime, List<dataReport>> dataDiction)
        {
            List<string> lsLable = new List<string>();
            g_reportType = type;
            cartesianChart1.Series.Clear();
            var Line1 = new ColumnSeries
            {
                Name = "tens",
                Values = new ChartValues<double> { },
                LabelPoint = point => point.Y + "",
                DataLabels = true,
                MaxColumnWidth = 10,
                Fill = System.Windows.Media.Brushes.DarkCyan,
            };
            tb_line1.BackColor = Color.DarkCyan;

            var Line2 = new ColumnSeries
            {
                Name = "tens",
                Values = new ChartValues<double> { },
                LabelPoint = point => point.Y + "",
                DataLabels = true,
                MaxColumnWidth = 10,
                Fill = System.Windows.Media.Brushes.Brown,
            };
            tb_line2.BackColor = Color.Brown;
            var Line3 = new ColumnSeries
            {
                Name = "tens",
                Values = new ChartValues<double> { },
                LabelPoint = point => point.Y + "",
                DataLabels = true,
                MaxColumnWidth = 10,
                Fill = System.Windows.Media.Brushes.Red,
            };
            tb_line3.BackColor = Color.Red;
            var Line4 = new ColumnSeries
            {
                Name = "tens",
                Values = new ChartValues<double> { },
                LabelPoint = point => point.Y + "",
                DataLabels = true,
                MaxColumnWidth = 10,
                Fill = System.Windows.Media.Brushes.Yellow,
            };
            tb_line4.BackColor = Color.Yellow;
            var Line5 = new ColumnSeries
            {
                Name = "tens",
                Values = new ChartValues<double> { },
                LabelPoint = point => point.Y + "",
                DataLabels = true,
                MaxColumnWidth = 10,
                Fill = System.Windows.Media.Brushes.Green,
            };
            tb_line5.BackColor = Color.Green;
            var Line6 = new ColumnSeries
            {
                Name = "tens",
                Values = new ChartValues<double> { },
                LabelPoint = point => point.Y + "",
                DataLabels = true,
                MaxColumnWidth = 10,
                Fill = System.Windows.Media.Brushes.BlueViolet,
            };
            tb_line6.BackColor = Color.BlueViolet;
            var Line7 = new ColumnSeries
            {
                Name = "tens",
                Values = new ChartValues<double> { },
                LabelPoint = point => point.Y + "",
                DataLabels = true,
                MaxColumnWidth = 10,
                Fill = System.Windows.Media.Brushes.Black,
            };
            tb_line7.BackColor = Color.Black;
            var Line8 = new ColumnSeries
            {
                Name = "tens",
                Values = new ChartValues<double> { },
                LabelPoint = point => point.Y + "",
                DataLabels = true,
                MaxColumnWidth = 10,
                Fill = System.Windows.Media.Brushes.DarkGray,
            };
            tb_line8.BackColor = Color.DarkGray;
            var Line9 = new ColumnSeries
            {
                Name = "tens",
                Values = new ChartValues<double> { },
                LabelPoint = point => point.Y + "",
                DataLabels = true,
                MaxColumnWidth = 10,
                Fill = System.Windows.Media.Brushes.LightBlue,
            };
            tb_line9.BackColor = Color.LightBlue;

            cartesianChart1.Series.Add(Line1);
            cartesianChart1.Series.Add(Line2);
            cartesianChart1.Series.Add(Line3);
            cartesianChart1.Series.Add(Line4);
            cartesianChart1.Series.Add(Line5);
            cartesianChart1.Series.Add(Line6);
            cartesianChart1.Series.Add(Line7);
            cartesianChart1.Series.Add(Line8);
            cartesianChart1.Series.Add(Line9);

            for (int i = 0; i < dataDiction.Count; i++)
            {
                for (int line = 0; line < dataDiction[dataDiction.Keys.ElementAt(i)].Count; line++)
                {
                    if (type == ReportType.Data_MTTR)
                    {
                        cartesianChart1.Series[line].Values.Add((double)dataDiction[dataDiction.Keys.ElementAt(i)][line].MTTR);
                    }
                    else if (type == ReportType.Data_MTBF)
                    {
                        cartesianChart1.Series[line].Values.Add((double)dataDiction[dataDiction.Keys.ElementAt(i)][line].MTBF);
                    }
                }
                if (time == TimeSearch.Day)
                { 
                    lsLable.Add(dataDiction.Keys.ElementAt(i).ToString("dd MMMM "));
                }
                else if (time == TimeSearch.Week)
                {
                    lsLable.Add("W" + calWeekOfYear(dataDiction.Keys.ElementAt(i)).ToString(""));
                }
                else if (time == TimeSearch.Month)
                {
                    lsLable.Add(dataDiction.Keys.ElementAt(i).ToString("MMMM "));
                }
            }

            /* Add lable X*/
            var XAxes = new Axis();
            XAxes.Labels = lsLable;
            XAxes.FontSize = 14.0;
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(XAxes);
            XAxes.FontWeight = System.Windows.FontWeights.Bold;
            XAxes.Foreground = System.Windows.Media.Brushes.Black;

            /* Disable lable Y*/
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Labels = new string[0],
            });
        }
        private void caculateAllLineDay(TimeSearch timeType, string timeForm, string timeTo)
        {
            var dataReport = new Dictionary<string, dataReport>();
            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.Now;
            int spaceDay = 0;
            if (timeType == TimeSearch.Day)
            {
                time1 = DateTime.ParseExact(timeForm, "yyyy-MM-dd", null);
                time2 = DateTime.ParseExact(timeTo, "yyyy-MM-dd", null);
                spaceDay = 1;
            }
            else
            {
                return;
            }
            List<HistoryNGData>  lsHistory = historyNG.get(null, null, time1.ToString("yyyy-MM-dd"), time2.ToString("yyyy-MM-dd"));

            for (DateTime time = time1; time <= time2; time = time.AddDays(spaceDay))
            {
                List<HistoryNGData> lsHistoryByDay = lsHistory.Where(x => DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date == time.Date).ToList();
                dataReport dataRp = new dataReport();
                dataReport.Add(time.ToString("dd-MM"), dataRp);

                for (int line = 1; line <= numLine; line++)
                {
                    List<HistoryNGData> lsHistoryByLine = lsHistoryByDay.Where(x => x.line == line.ToString()).ToList();
                    AnalysisData data = dataAnalys.getDataAnaLysis(lsHistoryByLine);
                    if (data != null)
                    {
                        dataReport[time.ToString("dd-MM")].numFail += data.num_of_Failure;
                        dataReport[time.ToString("dd-MM")].timeFail += ((uint)data.total_repair_time);
                    }
                    else
                    {
                        dataReport[time.ToString("dd-MM")].numFail += 0;
                        dataReport[time.ToString("dd-MM")].timeFail += 0;
                    }
                }
            }
            set(ReportType.Data_AllLine, dataReport);
        }
        private void caculateAllLineWeek(TimeSearch timeType, int WeekForm, int WeekTo)
        {
            var dataReport = new Dictionary<string, dataReport>();

            int spaceDay = 6;
            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime timeStart = startOfYear.AddDays(7 * (WeekForm - 1));
            DateTime timeEnd = startOfYear.AddDays(7 * (WeekTo - 1));
            List<HistoryNGData> lsHistory = historyNG.get(null, null, timeStart.ToString("yyyy-MM-dd"), timeEnd.ToString("yyyy-MM-dd"));
            for (int week = WeekForm; week <= WeekTo; week++)
            {
                dataReport dataRp = new dataReport();
                dataReport.Add("W" + week.ToString(), dataRp);

                DateTime time1 = startOfYear.AddDays(7 * (week - 1));
                DateTime time2 = time1.AddDays(spaceDay);
                List<HistoryNGData> lsHistoryByDay = lsHistory.Where(x => DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date >= time1.Date && 
                                                        DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date <= time2.Date).ToList();
                for (int line = 1; line <= numLine; line++)
                {
                    List<HistoryNGData> lsHistoryByLine = lsHistoryByDay.Where(x => x.line == line.ToString()).ToList();
                    AnalysisData data = dataAnalys.getDataAnaLysis(lsHistoryByLine);
                    if (data != null)
                    {
                        dataReport["W" + week.ToString()].numFail += data.num_of_Failure;
                        dataReport["W" + week.ToString()].timeFail += ((uint)data.total_repair_time);
                    }
                    else
                    {
                        dataReport["W" + week.ToString()].numFail += 0;
                        dataReport["W" + week.ToString()].timeFail += 0;
                    }
                }
            }
            set(ReportType.Data_AllLine, dataReport);
        }
        private void caculateAllLineMonth(TimeSearch timeType, int MonthForm, int MonthTo)
        {
            var dataReport = new Dictionary<string, dataReport>();

            DateTime timeStart = new DateTime(DateTime.Now.Year, MonthForm, 1);
            DateTime timeEnd = new DateTime(DateTime.Now.Year, MonthTo , DateTime.DaysInMonth(DateTime.Now.Year, MonthTo));

            List<HistoryNGData> lsHistory = historyNG.get(null, null, timeStart.ToString("yyyy-MM-dd"), timeEnd.ToString("yyyy-MM-dd"));
            for (int month = MonthForm; month <= MonthTo; month++)
            {
                dataReport dataRp = new dataReport();
                dataReport.Add(month.ToString(), dataRp);

                DateTime time1 = new DateTime(DateTime.Now.Year, month, 1);
                DateTime time2 = time1.AddMonths(1).AddDays(-1);
                List<HistoryNGData> lsHistoryByDay = lsHistory.Where(x => DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date >= time1.Date &&
                                        DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date <= time2.Date).ToList();
                for (int line = 1; line <= numLine; line++)
                {
                    List<HistoryNGData> lsHistoryByLine = lsHistoryByDay.Where(x => x.line == line.ToString()).ToList();
                    AnalysisData data = dataAnalys.getDataAnaLysis(lsHistoryByLine);
                    if (data != null)
                    {
                        dataReport[month.ToString()].numFail += data.num_of_Failure;
                        dataReport[month.ToString()].timeFail += ((uint)data.total_repair_time);
                    }
                    else
                    {
                        dataReport[month.ToString()].numFail += 0;
                        dataReport[month.ToString()].timeFail += 0;
                    }
                }
            }
            set(ReportType.Data_AllLine, dataReport);
        }
        private void caculateDataEachLineDay(TimeSearch timeType, string timeFrom, string timeTo)
        {
            var dataReport = new Dictionary<string, dataReport>();
            DateTime time1 = DateTime.ParseExact(timeFrom, "yyyy-MM-dd", null);
            DateTime time2 = DateTime.ParseExact(timeTo, "yyyy-MM-dd", null);
            List<HistoryNGData> lsHistory = historyNG.get(null, null, time1.ToString("yyyy-MM-dd"), time2.ToString("yyyy-MM-dd"));
            for (int line = 0; line < 9; line++)
            {
                List<HistoryNGData> lsHistoryByLine = lsHistory.Where(x => x.line == line.ToString()).ToList();
                string lineStr = line.ToString();
                if (line == 0)
                {
                    lineStr = "LTE";
                }
                else
                {
                    lineStr = (line - 1).ToString();
                }
                dataReport dataRp = new dataReport();
                dataReport.Add(lineStr, dataRp);

                AnalysisData data = dataAnalys.getDataAnaLysis(lsHistoryByLine);
                if (data != null)
                {
                    dataReport[lineStr].numFail += data.num_of_Failure;
                    dataReport[lineStr].timeFail += ((uint)data.total_repair_time);
                }
                else
                {
                    dataReport[lineStr].numFail += 0;
                    dataReport[lineStr].timeFail += 0;
                }
            }
            set(ReportType.Data_EachLine, dataReport);
        }
        private void caculateMTTRDay(TimeSearch timeType, string timeFrom, string timeTo)
        {
            var DicdataReport = new Dictionary<DateTime, List<dataReport>>();

            DateTime time1 = DateTime.ParseExact(timeFrom, "yyyy-MM-dd", null);
            DateTime time2 = DateTime.ParseExact(timeTo, "yyyy-MM-dd", null);

            List<HistoryNGData> lsHistory = historyNG.get(null, null, time1.ToString("yyyy-MM-dd"), time2.ToString("yyyy-MM-dd"));

            for (DateTime time = time1; time <= time2; time = time.AddDays(1))
            {
                var listsDataReport = new List<dataReport>();
                List<HistoryNGData> lsHistoryByDay = lsHistory.Where(x => DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date == time.Date).ToList();
                for (int line = 0; line < numLine; line++)
                {
                    dataReport dataReport = new dataReport();

                    List<HistoryNGData> lsHistoryByLine = lsHistoryByDay.Where(x => x.line == line.ToString()).ToList();

                    AnalysisData data = dataAnalys.getDataAnaLysis(lsHistoryByLine);
                    if (data != null)
                    {
                        dataReport.MTTR = data.MTTR;
                        listsDataReport.Add(dataReport);
                    }
                    else
                    {
                        //Random r = new Random();
                        //dataReport.MTTR = r.Next(0, 50);
                        dataReport.MTTR = 0;
                        listsDataReport.Add(dataReport);
                    }
                }
                DicdataReport.Add(time, listsDataReport);
            }
            setMTTR_MTBF(ReportType.Data_MTTR, TimeSearch.Day, DicdataReport);
        }
        private void caculateMTTRWeek(TimeSearch timeType, int WeekFrom, int WeekTo)
        {
            var DicdataReport = new Dictionary<DateTime, List<dataReport>>();

            int spaceDay = 6;

            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime timeStart = startOfYear.AddDays(7 * (WeekFrom - 1));
            DateTime timeEnd = startOfYear.AddDays(7 * (WeekTo - 1));

            List<HistoryNGData> lsHistory = historyNG.get(null, null, timeStart.ToString("yyyy-MM-dd"), timeEnd.ToString("yyyy-MM-dd"));

            for (int week = WeekFrom; week <= WeekTo; week++)
            {
                var listsDataReport = new List<dataReport>();
                DateTime time1 = startOfYear.AddDays(7 * (week - 1));
                DateTime time2 = time1.AddDays(spaceDay);
                List<HistoryNGData> lsHistoryByDay = lsHistory.Where(x => DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date >= time1.Date &&
                                        DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date <= time2.Date).ToList();
                for (int line = 0; line < numLine; line++)
                {
                    dataReport dataReport = new dataReport();
     
                    List<HistoryNGData> lsHistoryByLine = lsHistoryByDay.Where(x => x.line == line.ToString()).ToList();

                    AnalysisData data = dataAnalys.getDataAnaLysis(lsHistoryByLine);
                    if (data != null)
                    {
                        dataReport.MTTR = data.MTTR;
                        listsDataReport.Add(dataReport);
                    }
                    else
                    {
                        dataReport.MTTR = 0;
                        listsDataReport.Add(dataReport);
                    }
                }
                DicdataReport.Add(startOfYear.AddDays(7 * (week - 1)), listsDataReport);
            }
            setMTTR_MTBF(ReportType.Data_MTTR, TimeSearch.Week, DicdataReport);
        }
        private void caculateMTTRMonth(TimeSearch timeType, int MonthFrom, int MonthTo)
        {
            var DicdataReport = new Dictionary<DateTime, List<dataReport>>();

            int spaceDay = 6;

            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);

            DateTime timeStart = new DateTime(DateTime.Now.Year, MonthFrom, 1);
            DateTime timeEnd = new DateTime(DateTime.Now.Year, MonthTo, DateTime.DaysInMonth(DateTime.Now.Year, MonthTo));

            List<HistoryNGData> lsHistory = historyNG.get(null, null, timeStart.ToString("yyyy-MM-dd"), timeEnd.ToString("yyyy-MM-dd"));

            for (int month = MonthFrom; month <= MonthTo; month++)
            {
                var listsDataReport = new List<dataReport>();

                DateTime time1 = new DateTime(DateTime.Now.Year, month, 1);
                DateTime time2 = time1.AddMonths(1).AddDays(-1);

                List<HistoryNGData> lsHistoryByDay = lsHistory.Where(x => DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date >= time1.Date &&
                                        DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date <= time2.Date).ToList();

                for (int line = 0; line < numLine; line++)
                {
                    dataReport dataReport = new dataReport();
                    List<HistoryNGData> lsHistoryByLine = lsHistoryByDay.Where(x => x.line == line.ToString()).ToList();
                    AnalysisData data = dataAnalys.getDataAnaLysis(lsHistoryByLine);
                    if (data != null)
                    {
                        dataReport.MTTR = data.MTTR;
                        listsDataReport.Add(dataReport);
                    }
                    else
                    {
                        //Random r = new Random();
                        //dataReport.MTTR = r.Next(0, 50);
                        dataReport.MTTR = 0;
                        listsDataReport.Add(dataReport);
                    }
                }
                DicdataReport.Add(new DateTime(DateTime.Now.Year, month, 1), listsDataReport);
            }
            setMTTR_MTBF(ReportType.Data_MTTR, TimeSearch.Month, DicdataReport);
        }
        private void caculateMTBFDay(TimeSearch timeType, string timeFrom, string timeTo)
        {
            var DicdataReport = new Dictionary<DateTime, List<dataReport>>();

            DateTime time1 = DateTime.ParseExact(timeFrom, "yyyy-MM-dd", null);
            DateTime time2 = DateTime.ParseExact(timeTo, "yyyy-MM-dd", null);

            List<HistoryNGData> lsHistory = historyNG.get(null, null, time1.ToString("yyyy-MM-dd"), time2.ToString("yyyy-MM-dd"));

            for (DateTime time = time1; time <= time2; time = time.AddDays(1))
            {
                var listsDataReport = new List<dataReport>();

                List<HistoryNGData> lsHistoryByDay = lsHistory.Where(x => DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date == time.Date).ToList();
                for (int line = 0; line < numLine; line++)
                {
                    dataReport dataReport = new dataReport();
                    List<HistoryNGData> lsHistoryByLine = lsHistoryByDay.Where(x => x.line == line.ToString()).ToList();
                    AnalysisData data = dataAnalys.getDataAnaLysis(lsHistoryByLine);
                    if (data != null)
                    {
                        dataReport.MTBF = data.MTBF;
                        listsDataReport.Add(dataReport);
                    }
                    else
                    {
                        dataReport.MTBF = 0;
                        listsDataReport.Add(dataReport);
                    }
                }
                DicdataReport.Add(time, listsDataReport);
            }
            setMTTR_MTBF(ReportType.Data_MTBF,TimeSearch.Day, DicdataReport);
        }
        private void caculateMTBFWeek(TimeSearch timeType, int WeekFrom, int WeekTo)
        {
            var DicdataReport = new Dictionary<DateTime, List<dataReport>>();

            int spaceDay = 6;

            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime timeStart = startOfYear.AddDays(7 * (WeekFrom - 1));
            DateTime timeEnd = startOfYear.AddDays(7 * (WeekTo - 1));
            List<HistoryNGData> lsHistory = historyNG.get(null, null, timeStart.ToString("yyyy-MM-dd"), timeEnd.ToString("yyyy-MM-dd"));
            for (int week = WeekFrom; week <= WeekTo; week++)
            {
                var listsDataReport = new List<dataReport>();
                DateTime time1 = startOfYear.AddDays(7 * (week - 1));
                DateTime time2 = time1.AddDays(spaceDay);
                List<HistoryNGData> lsHistoryByDay = lsHistory.Where(x => DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date >= time1.Date &&
                                                        DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date <= time2.Date).ToList();
                for (int line = 0; line < numLine; line++)
                {
                    dataReport dataReport = new dataReport();
                    List<HistoryNGData> lsHistoryByLine = lsHistoryByDay.Where(x => x.line == line.ToString()).ToList();

                    AnalysisData data = dataAnalys.getDataAnaLysis(lsHistoryByLine);
                    if (data != null)
                    {
                        dataReport.MTBF = data.MTBF;
                        listsDataReport.Add(dataReport);
                    }
                    else
                    {
                        dataReport.MTBF = 0;
                        listsDataReport.Add(dataReport);
                    }
                }
                DicdataReport.Add(startOfYear.AddDays(7 * (week - 1)), listsDataReport);
            }
            setMTTR_MTBF(ReportType.Data_MTBF, TimeSearch.Week, DicdataReport);
        }
        private void caculateMTBFMonth(TimeSearch timeType, int MonthFrom, int MonthTo)
        {
            var DicdataReport = new Dictionary<DateTime, List<dataReport>>();

            int spaceDay = 6;

            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime timeStart = new DateTime(DateTime.Now.Year, MonthFrom, 1);
            DateTime timeEnd = new DateTime(DateTime.Now.Year, MonthTo, DateTime.DaysInMonth(DateTime.Now.Year, MonthTo));

            List<HistoryNGData> lsHistory = historyNG.get(null, null, timeStart.ToString("yyyy-MM-dd"), timeEnd.ToString("yyyy-MM-dd"));
            for (int month = MonthFrom; month <= MonthTo; month++)
            {
                var listsDataReport = new List<dataReport>();
                DateTime time1 = new DateTime(DateTime.Now.Year, month, 1);
                DateTime time2 = time1.AddMonths(1).AddDays(-1);
                List<HistoryNGData> lsHistoryByDay = lsHistory.Where(x => DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date >= time1.Date &&
                                        DateTime.ParseExact(x.time, "dd-MM-yyyy HH:mm", null).Date <= time2.Date).ToList();
                for (int line = 0; line < numLine; line++)
                {
                    dataReport dataReport = new dataReport();
                    List<HistoryNGData> lsHistoryByLine = lsHistoryByDay.Where(x => x.line == line.ToString()).ToList();
                    AnalysisData data = dataAnalys.getDataAnaLysis(lsHistoryByLine);
                    if (data != null)
                    {
                        dataReport.MTBF = data.MTBF;
                        listsDataReport.Add(dataReport);
                    }
                    else
                    {
                        //Random r = new Random();
                        //dataReport.MTTR = r.Next(0, 50);
                        dataReport.MTBF = 0;
                        listsDataReport.Add(dataReport);
                    }
                }
                DicdataReport.Add(new DateTime(DateTime.Now.Year, month, 1), listsDataReport);
            }
            setMTTR_MTBF(ReportType.Data_MTBF, TimeSearch.Month, DicdataReport);
        }
        private void LoadMenuAndTitle()
        {
            menu_allLine.ForeColor = Color.DimGray;
            Menu_eachLine.ForeColor = Color.DimGray;
            Menu_MTTR.ForeColor = Color.DimGray;
            Menu_MTBF.ForeColor = Color.DimGray;

            btn_seachWeek.Enabled = true;
            btn_searchMonth.Enabled = true;
            switch (g_reportType)
            {
                case ReportType.Data_AllLine:
                    lb_title.Text = "Time NG and Total NG All Line";
                    menu_allLine.ForeColor = Color.Black;
                    tbLayout_colorLine.Visible = false;
                    break;
                case ReportType.Data_EachLine:
                    lb_title.Text = "Time NG and Total NG Each Line";
                    Menu_eachLine.ForeColor = Color.Black;
                    tbLayout_colorLine.Visible = false;
                    btn_seachWeek.Enabled = false;
                    btn_searchMonth.Enabled = false;
                    break;
                case ReportType.Data_MTTR:
                    lb_title.Text = "MTTR ";
                    Menu_MTTR.ForeColor = Color.Black;
                    tbLayout_colorLine.Visible = true;
                    break;
                case ReportType.Data_MTBF:
                    lb_title.Text = "MTBF";
                    Menu_MTBF.ForeColor = Color.Black;
                    tbLayout_colorLine.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VisualReporting_Load(object sender, EventArgs e)
        {
            LoadMenuAndTitle();
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime_From = DateTime.ParseExact(dateTime_To.Text, "yyyy-MM-dd", null).AddDays(-6);
            if (g_reportType == ReportType.Data_AllLine)
            {
                caculateAllLineDay(TimeSearch.Day, dateTime_From.ToString("yyyy-MM-dd"), dateTime_To.Text);
            }
            else if (g_reportType == ReportType.Data_EachLine)
            {
                caculateDataEachLineDay(TimeSearch.Day, dateTime_To.Text, dateTime_To.Text);
            }
            else if (g_reportType == ReportType.Data_MTTR)
            {
                caculateMTTRDay(TimeSearch.Day, dateTime_From.ToString("yyyy-MM-dd"), dateTime_To.Text);
            }
            else if (g_reportType == ReportType.Data_MTBF)
            {
                caculateMTBFDay(TimeSearch.Day, dateTime_From.ToString("yyyy-MM-dd"), dateTime_To.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int weekFrom = 0;
            int weekTo = cb_week.SelectedIndex + 1;

            /* get week search from*/
            int cnt = 4;  // 4 week
            for (int i = cb_week.SelectedIndex; i >= 0; i--)
            {
                weekFrom = i + 1;
                cnt--;
                if (cnt == 0)
                {
                    break;
                }
            }

            if (g_reportType == ReportType.Data_AllLine)
            {
                caculateAllLineWeek(TimeSearch.Week, weekFrom, weekTo);
            }
            else if (g_reportType == ReportType.Data_EachLine)
            {

                //caculateDataEachLine(TimeSearch.Week, weekFrom, weekTo);
            }
            else if (g_reportType == ReportType.Data_MTTR)
            {
                caculateMTTRWeek(TimeSearch.Week, weekFrom, weekTo);
            }
            else if (g_reportType == ReportType.Data_MTBF)
            {
                caculateMTBFWeek(TimeSearch.Week, weekFrom, weekTo);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int monthFrom = 0;
            int monthTo = cb_month.SelectedIndex + 1;

            /* get week search from*/
            int cnt = 4;  // 4 week
            for (int i = cb_month.SelectedIndex; i >= 0; i--)
            {
                monthFrom = i + 1;
                cnt--;
                if (cnt == 0)
                {
                    break;
                }
            }
            if (g_reportType == ReportType.Data_AllLine)
            {
                caculateAllLineMonth(TimeSearch.Week, monthFrom, monthTo);
            }
            else if (g_reportType == ReportType.Data_EachLine)
            {

                //caculateDataEachLine(TimeSearch.Week, weekFrom, weekTo);
            }
            else if (g_reportType == ReportType.Data_MTTR)
            {
                caculateMTTRMonth(TimeSearch.Month, monthFrom, monthTo);
            }
            else if (g_reportType == ReportType.Data_MTBF)
            {
                caculateMTBFMonth(TimeSearch.Month, monthFrom, monthTo);
            }
            
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void menu_allLine_Click(object sender, EventArgs e)
        {
            g_reportType = ReportType.Data_AllLine;
            LoadMenuAndTitle();
            button1_Click(null, null);
        }

        private void Menu_eachLine_Click(object sender, EventArgs e)
        {
            g_reportType = ReportType.Data_EachLine;
            LoadMenuAndTitle();
            button1_Click(null, null);
        }

        private void Menu_MTTR_Click(object sender, EventArgs e)
        {
            g_reportType = ReportType.Data_MTTR;
            LoadMenuAndTitle();
            button1_Click(null, null);
        }

        private void Menu_MTBF_Click(object sender, EventArgs e)
        {
            g_reportType = ReportType.Data_MTBF;
            LoadMenuAndTitle();
            button1_Click(null, null);
        }
    }
}
