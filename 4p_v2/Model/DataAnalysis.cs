using _4P_PROJECT.DataBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GiamSat.model.History;
using static GiamSat.model.HistoryNG;
using static GiamSat.model.Machine;

namespace GiamSat.model
{
    public class DataAnalysis
    {
        HistoryNG historyNG = new HistoryNG();

        Machine machine = new Machine();
        public class AnalysisData
        {
            public string MachineID;
            public DateTime first_Failure_Date;
            public DateTime last_Failure_Date;
            public uint num_of_Failure;
            public double day_between_first_last_date;
            public double day_Excluding_sunday;
            public double day_Excluding_down_time;
            public double total_repair_time;
            public double total_break_time;
            public uint no_plan;
            public double total_running_time;
            public double MTTR;
            public double MTBF;
            public double RATE;
        }
        public class dataReport
        {
            public int line;
            public uint numFail;
            public uint timeFail;
            public double MTTR;
            public double MTBF;
        }
        public class timeRepare
        {
            public int MachineID;
            public DateTime TimeOK;
            public DateTime TimeNG;
        }


        private DataBase mMydatabase;

        public DataBase database
        {
            get
            {
                return mMydatabase;
            }
            set
            {
                mMydatabase = value;
                historyNG.database = mMydatabase;
            }
        }

        public AnalysisData getDataAnaLysis(string line, string lane, string time1, string time2)
        {
            List<HistoryNGData> lsHistory;
            AnalysisData data = new AnalysisData();
            List<machineData> lsMachine;
            List<timeRepare> lstimeRepare = new List<timeRepare>();

            lsHistory = historyNG.get(line, lane, time1, time2);

            if (lsHistory.Count == 0)
            {
                return null;
            }

            foreach (var history in lsHistory)
            {
                /* Caculate first_Failure_Date, num_of_Failure, last_Failure_Date*/
                if ((data.last_Failure_Date == DateTime.MinValue) && (history.status == "NG"))
                {
                    data.last_Failure_Date = DateTime.ParseExact(history.time, "dd-MM-yyyy HH:mm", null);
                }
                if (history.status == "NG")
                {
                    data.first_Failure_Date = DateTime.ParseExact(history.time, "dd-MM-yyyy HH:mm", null);
                    HistoryNGData historyOK = historyNG.searchStatusOKNearNG(Convert.ToUInt64(history.historyID), history.machineID);
                    if (historyOK != null)
                    {
                        DateTime timeOK = DateTime.ParseExact(historyOK.time, "dd-MM-yyyy HH:mm", null);
                        DateTime timeNG = DateTime.ParseExact(history.time, "dd-MM-yyyy HH:mm", null);
                        data.total_repair_time += timeOK.Subtract(timeNG).TotalMinutes;
                        data.num_of_Failure++;
                    }
                }
            }

            /*Caculate day_between_first_last_date*/
            data.day_between_first_last_date = data.last_Failure_Date.Subtract(data.first_Failure_Date).TotalDays;

            int total = 0;
            for (var i = data.first_Failure_Date; i <= data.last_Failure_Date; i = i.AddDays(1))

            /* Compare date with sunday */
            if (i.DayOfWeek == DayOfWeek.Sunday)
            {
                total++;
            }

            /* Caculate day_Excluding_sunday*/
            data.day_Excluding_sunday = data.day_between_first_last_date - total;

            /*Caculate total_running_time*/
            data.total_running_time = data.last_Failure_Date.Subtract(data.first_Failure_Date).TotalMinutes;

            /* Caculate MTTR*/
            if (data.num_of_Failure != 0)
            {
                data.MTTR = data.total_repair_time / data.num_of_Failure;
                data.MTTR = Math.Round(data.MTTR, 2);
                /* Fake data*/
                data.RATE = 10 / data.MTTR;
            }
            else
            {
                data.MTTR = 0;
            }

            /* Fake data*/
            data.no_plan = 100;
          
            if (data.num_of_Failure != 0)
            {
                data.MTBF = Math.Abs(((data.no_plan - data.total_repair_time)/60)/data.num_of_Failure) ;
                data.MTBF  = Math.Round(data.MTBF, 2);
            }
            else
            {
                data.MTBF = 0;
            }

            if (data.num_of_Failure == 0)
            {
                return null;
            }
            return data;
        }
        public AnalysisData getDataAnaLysis(List<HistoryNGData> lsHistory)
        {
     
            AnalysisData data = new AnalysisData();
            List<machineData> lsMachine;
            List<timeRepare> lstimeRepare = new List<timeRepare>();

            if (lsHistory.Count == 0)
            {
                return null;
            }

            foreach (var history in lsHistory)
            {
                /* Caculate first_Failure_Date, num_of_Failure, last_Failure_Date*/
                if ((data.last_Failure_Date == DateTime.MinValue) && (history.status == "NG"))
                {
                    data.last_Failure_Date = DateTime.ParseExact(history.time, "dd-MM-yyyy HH:mm", null);
                }
                if (history.status == "NG")
                {
                    data.first_Failure_Date = DateTime.ParseExact(history.time, "dd-MM-yyyy HH:mm", null);
                    HistoryNGData historyOK = historyNG.searchStatusOKNearNG(Convert.ToUInt64(history.historyID), history.machineID);
                    if (historyOK != null)
                    {
                        DateTime timeOK = DateTime.ParseExact(historyOK.time, "dd-MM-yyyy HH:mm", null);
                        DateTime timeNG = DateTime.ParseExact(history.time, "dd-MM-yyyy HH:mm", null);
                        data.total_repair_time += timeOK.Subtract(timeNG).TotalMinutes;
                        data.num_of_Failure++;
                    }
                }
            }

            /*Caculate day_between_first_last_date*/
            data.day_between_first_last_date = data.last_Failure_Date.Subtract(data.first_Failure_Date).TotalDays;

            int total = 0;
            for (var i = data.first_Failure_Date; i <= data.last_Failure_Date; i = i.AddDays(1))

                /* Compare date with sunday */
                if (i.DayOfWeek == DayOfWeek.Sunday)
                {
                    total++;
                }

            /* Caculate day_Excluding_sunday*/
            data.day_Excluding_sunday = data.day_between_first_last_date - total;

            /*Caculate total_running_time*/
            data.total_running_time = data.last_Failure_Date.Subtract(data.first_Failure_Date).TotalMinutes;

            /* Caculate MTTR*/
            if (data.num_of_Failure != 0)
            {
                data.MTTR = data.total_repair_time / data.num_of_Failure;
                data.MTTR = Math.Round(data.MTTR, 2);
                /* Fake data*/
                data.RATE = 10 / data.MTTR;
            }
            else
            {
                data.MTTR = 0;
            }

            /* Fake data*/
            data.no_plan = 100;

            if (data.num_of_Failure != 0)
            {
                data.MTBF = Math.Abs(((data.no_plan - data.total_repair_time) / 60) / data.num_of_Failure);
                data.MTBF = Math.Round(data.MTBF, 2);
            }
            else
            {
                data.MTBF = 0;
            }

            if (data.num_of_Failure == 0)
            {
                return null;
            }
            return data;
        }
    }
}
