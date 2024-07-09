﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Resources;
using System.Threading;
using System.Globalization;
using System.Security.Cryptography;

using DevComponents.DotNetBar;
using _4P_PROJECT.DataBase;
using GiamSat.viewDb;
//using Giamsat.Model;
//using static Giamsat.Model.MachinePlan;
using Giamsat.Control.Devices;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using GiamSat.View;
using GiamSat.model;
using static GiamSat.model.ClientRF;
using static Giamsat.Control.Devices.ItemRF;
using static Giamsat.Control.Devices.RFMaster;
using static GiamSat.model.Machine;
using Syncfusion.Presentation;
using Giamsat.View.ShowItems;
using ZstdSharp.Unsafe;
using MySqlX.XDevAPI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static GiamSat.model.HistoryNG;
using Org.BouncyCastle.Utilities.Collections;
using HidSharp.Reports.Encodings;
using GiamSat.View.ShowReporting;
using static GiamSat.model.DataAnalysis;
using Giamsat.View.Config;
using static GiamSat.View.ShowReporting.VisualReporting;
using System.Net;
using System.Net.Sockets;
using Giamsat.Control.Websocket;
using static Giamsat.Control.Websocket.StatusToWebSocket;
using SabanWi.View.Config;


namespace GiamSat
{
    public partial class Main : Form
    {

        private ResourceManager mMainResourceManager;
        private CultureInfo mEnglishCultureInfo;
        private CultureInfo mVietnameseCultureInfo;

        /* database*/
        public DataBase db = new DataBase();
        ClientRF clientDb = new ClientRF();
        History historyDb = new History();
        Machine machineDb = new Machine();
        HistoryNG historyNG = new HistoryNG();
        ConfigSystem config = new ConfigSystem();
        DataAnalysis dataAnalys = new DataAnalysis();
        List<ClientData> Listclients = new List<ClientData>();
        List<machineData> ListMachine = new List<machineData>();
        /* Device*/
        RFMaster RFMaster = new RFMaster();

        public List<ItemRF> lsItems = new List<ItemRF>();

        /*Back ground worker*/

        private BackgroundWorker connectRFMaster = new BackgroundWorker();

        private BackgroundWorker connectDataBase = new BackgroundWorker();

        private BackgroundWorker updateRFStatus = new BackgroundWorker();

        private BackgroundWorker updateSocketSv = new BackgroundWorker();

        /*Device infor*/
        public enum DeviceInformation { OK, SAME_ID, SAME_LOCATION, SAME_ID_LOCATION };

        public enum LedColour { NONE, GREEN, RED, YELLOW, BLACK };

        public enum SendCommand
        {
            NONE, READ_ADD, WRITE_ADD, READ_SABAN, WRITE_SABAN, READ_TIME, WRITE_TIME,
            READ_RUNNING_INFO, DELETE_RUNNING_INFO, READ_SYS_STATUS, SCAN_SYS_STATUS
        };

        public SendCommand sendCommand { get; set; }

        public string Password { get; set; }

        public bool EditEnable;
        public bool ShowName;

        public enum LoginResult
        {
            LoginOK = 0,
            LoginWrongUsername = 1,
            LoginWrongPassword = 2
        }

        /*View infor*/

        public bool viewDetail = false;

        public ResourceManager MainResourceManager { get { return mMainResourceManager; } }

        public DataBase MainDatabase { get { return db; } }
        public LedColour Ledcolour { get; set; }

        public Main()
        {
            InitializeComponent();

            mMainResourceManager = new ResourceManager("SabanWi.Other.Language.Localization", System.Reflection.Assembly.GetExecutingAssembly());
            mEnglishCultureInfo = new CultureInfo("en-US");
            mVietnameseCultureInfo = new CultureInfo("vi-VN");
            vietnameseToolStripMenuItem.Checked = false;
            englishToolStripMenuItem.Checked = true;
            Thread.CurrentThread.CurrentUICulture = mEnglishCultureInfo;

            LoadDisplayList();

            /*Background worker: try to connect RF master*/

            connectRFMaster.DoWork += connectRFMaster_DoWork;
            connectRFMaster.ProgressChanged += connectRFMaster_ProgressChanged;
            connectRFMaster.WorkerReportsProgress = true;
            connectRFMaster.RunWorkerAsync();

            /*Background worker: try to connect Data base*/

            connectDataBase.DoWork += connectDataBase_DoWork;
            connectDataBase.RunWorkerCompleted += connectDataBase_RunWorkerCompleted;
            connectDataBase.WorkerReportsProgress = true;
            connectDataBase.RunWorkerAsync();

            /*Background worker: UpdateHistoryNG*/
            updateRFStatus.DoWork += updateRFStatus_DoWork;
            updateRFStatus.WorkerReportsProgress = true;

            /*Background worker: update to socketServer*/
            updateSocketSv.DoWork += updateSocketServer_DoWork;
            updateSocketSv.WorkerReportsProgress = true;

        }


        private void connectRFMaster_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(2000);
                if (RFMaster.connect())
                {
                    connectRFMaster.ReportProgress(1);
                }
                else
                {
                    connectRFMaster.ReportProgress(0);
                }
            }
        }

        private void connectRFMaster_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void connectDataBase_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                db.Connect();
                if (db.IsConnected())
                {
                    db.InitDataBase();
                    clientDb.database = db;
                    historyDb.database = db;
                    machineDb.database = db;
                    historyNG.database = db;
                    dataAnalys.database = db;
                    config.database = db;
                    break;
                }
            }
        }

        private void connectDataBase_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*Load item*/

            Listclients = clientDb.getAll();
            ListMachine = machineDb.getAll();
            foreach (ClientData client in Listclients)
            {
                foreach (var item in ListMachine)
                {
                    if (client.machineID == item.machineID)
                    {
                        AddItems frmNew = new AddItems();
                        frmNew.CalledApplication = this;
                        try
                        {
                            frmNew.LoadItem(client.machineID, item.machineCode, client.machineName, client.clientAddr, client.port,
                                                client.status, item.time, client.location_x, client.location_y, Convert.ToUInt16(item.linePosition), Convert.ToUInt16(item.lane), client.region, false);
                        }
                        catch (Exception)
                        {
                            frmNew.LoadItem(client.machineID, item.machineCode, client.machineName, client.clientAddr, client.port,
                                                client.status, item.time, client.location_x, client.location_y, 0, 0, client.region, false);
                        }
                    }
                }
            }
            foreach (var item in lsItems)
            {
                UpdateLedStatus(item);
            }
            /*Resize main form*/
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;

            /*Run worker check RF status*/
            updateRFStatus.RunWorkerAsync();

            /*Run worker set status to Socket*/
            //updateSocketSv.RunWorkerAsync();
        }

        void updateHistoryNG()
        {
            if (!RFMaster.isConnect())
            {
                return;
            }
            List<HistoryNGData> listWarningNG_OK = historyNG.searchWarningNG_OK();
            Dictionary<HistoryNGData, HistoryNGData> listDataPair = new Dictionary<HistoryNGData, HistoryNGData>();

            int timeNG = config.getTimeReport();

            if (listWarningNG_OK.Count > 0)
            {
                foreach (var Data in listWarningNG_OK)
                {
                    if (Data.status == "WarningNG")
                    {
                        listDataPair.Add(Data, null);
                    }
                    else if (Data.status == "OK")
                    {
                        foreach (var ls in listDataPair)
                        {
                            if ((ls.Key.machineID == Data.machineID) && (ls.Value == null))
                            {
                                listDataPair[ls.Key] = Data;
                                break;
                            }
                        }
                    }
                }
            }

            foreach (var ls in listDataPair)
            {
                DateTime timeWarningNG = DateTime.ParseExact(ls.Key.time, "dd-MM-yyyy HH:mm", null);
                DateTime timeOK;
                if (ls.Value != null)
                {
                    timeOK = DateTime.ParseExact(ls.Value.time, "dd-MM-yyyy HH:mm", null);

                    if (timeOK.Subtract(timeWarningNG).TotalMinutes > timeNG)
                    {
                        // update NG
                        historyNG.update(ls.Key.historyNGID, "NG");
                    }
                    else
                    {
                        historyNG.delete(ls.Key.historyNGID);
                        historyNG.delete(ls.Value.historyNGID);
                    }
                }
                else
                {
                    timeOK = DateTime.Now;
                    if (timeOK.Subtract(timeWarningNG).TotalMinutes > timeNG)
                    {
                        // update NG
                        historyNG.update(ls.Key.historyNGID, "NG");
                    }
                }
            }
        }
        void showMasterRFStatus(string text)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    this.Text = "SabanWi" + text;
                }));
            }
            catch
            {

            }
        }
        void updateHistory()
        {
            Dictionary<string, int> regionStatus = new Dictionary<string, int>();
            /* check status RF master*/
            if (RFMaster.isConnect())
            {
                var lsStatus = RFMaster.GetStatus(5);
                if (lsStatus != null)
                {
                    showMasterRFStatus("Master connected");

                    /*update history*/
                    foreach (var item in lsItems)
                    {
                        foreach (var Status in lsStatus)
                        {
                            if ((Status.addr == item.addr) && (Status.port == item.port))
                            {
                                /* Check status NG*/
                                if ((Status.status == item.NG))
                                {
                                    item.cntNG++;
                                    item.cntOK = 0;
                                    item.cntDIS = 0;
                                }
                                else if ((Status.status == item.OK))
                                {
                                    item.cntOK++;
                                    item.cntNG = 0;
                                    item.cntDIS = 0;
                                }
                                else
                                {
                                    item.cntOK = 0;
                                    item.cntNG = 0;
                                    item.cntDIS = 1;
                                }

                                if ((item.cntNG >= 5 || item.cntOK >= 5 || item.cntDIS == 1))
                                {
                                    item.cntNG = 0;
                                    item.cntOK = 0;
                                    if (item.status != Status.status)
                                    {
                                        item.status = Status.status;
                                        item.timeNG = DateTime.Now.ToString("dd-MM-yyyy HH:mm");

                                        /* set status to database*/
                                        clientDb.setStatus(item.machineid, item.machineName, item.status);
                                        machineDb.updateStatus(item.machineid, item.status, item.timeNG);
                                        UInt64 historyID = historyDb.add(item.machineid, "", item.timeNG, item.status);
                                        UpdateLedStatus(item);

                                        /* check and add historyNG for analysis */
                                        if (item.status == item.NG || item.status == item.OK)
                                        {
                                            HistoryNGData historyNGLast = historyNG.searchHistoryNGLast(item.machineid);
                                            if (historyNGLast != null)
                                            {
                                                if (historyNGLast.status == "WarningNG")
                                                {
                                                    historyNGLast.status = item.NG;
                                                }
                                                if (historyNGLast.status != item.status)
                                                {
                                                    historyNG.add(item.machineid, historyID.ToString(), item.line.ToString(), item.lane.ToString(), item.timeNG, item.status);
                                                }
                                            }
                                            else
                                            {
                                                historyNG.add(item.machineid, historyID.ToString(), item.line.ToString(), item.lane.ToString(), item.timeNG, item.status);
                                            }
                                        }
                                    }
                                }
                            }
                            /*set get status on region*/
                        }

                        if (item.region.Contains("Region"))
                        {
                            string regionName = item.region;

                            if (!regionStatus.ContainsKey(regionName))
                            {
                                regionStatus.Add(regionName, 0);
                            }
                            if (item.status == "NG")
                            {
                                regionStatus[regionName] += 1;
                            }
                            else if (item.status == "DIS")
                            {
                                regionStatus[regionName] += 255;
                            }
                        }
                    }

                    /* update region*/
                    foreach (var item in lsItems)
                    {
                        foreach (var value in regionStatus)
                        {
                            if (value.Key == item.machineName)
                            {
                                if (value.Value >= 255)
                                {
                                    item.status = "DIS";
                                }
                                else if (value.Value > 0)
                                {
                                    item.status = "NG";
                                }
                                else
                                {
                                    item.status = "OK";
                                }
                                clientDb.setStatus(item.machineid, item.machineName, item.status);
                                UpdateLedStatus(item);
                            }
                        }
                    }
                }
                else
                {
                    showMasterRFStatus("Master Error");
                }
            }
            else
            {
                // update led status without connect RF master

                List<ClientData> clients = clientDb.getAll();

                foreach (var item in lsItems)
                {
                    foreach (var client in clients)
                    {
                        if ((item.machineid == client.machineID) && (item.machineName == client.machineName))
                        {
                            item.status = client.status;
                            UpdateLedStatus(item);
                        }
                    }
                }
            }
        }
        private void updateRFStatus_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(300);
                updateHistory();
                updateHistoryNG();
            }
        }

        private void updateSocketServer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            StatusToWebSocket statusUpdateSocket = new StatusToWebSocket();
            List<DeviceSocketStatus> listOld = new List<DeviceSocketStatus>();
            while (true)
            {
                Thread.Sleep(1000);
                foreach (var item in lsItems)
                {
                    /*File webSocket*/
                    if ((item.status == item.NG) && !item.machineName.Contains("Region"))
                    {
                        foreach (var machine in ListMachine)
                        {
                            if (item.machineid == machine.machineID)
                            {
                                /*set status to fileSocket*/
                                statusUpdateSocket.set(item.machineid, machine.machineCode, machine.machineName, machine.linePosition, machine.lane, item.status, item.timeNG);
                                break;
                            }
                        }

                    }
                }
                statusUpdateSocket.update();

            }
        }

        #region Item method


        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public Image LedDisplay(LedColour colour, ushort number, int newImageWidth, int newImageHeight)
        {
            Image image;
            image = Properties.Resources.Ledblack32px;

            if (colour == LedColour.BLACK)
            {
                switch (number)
                {
                    case 0: image = Properties.Resources.Ledblack32px; break;
                    case 1: image = Properties.Resources.ledblack32px1; break;
                    case 2: image = Properties.Resources.ledblack32px2; break;
                    case 3: image = Properties.Resources.ledblack32px3; break;
                    case 4: image = Properties.Resources.ledblack32px4; break;
                    case 5: image = Properties.Resources.ledblack32px5; break;
                    case 6: image = Properties.Resources.ledblack32px6; break;
                    case 7: image = Properties.Resources.ledblack32px7; break;
                    case 8: image = Properties.Resources.ledblack32px8; break;
                    case 9: image = Properties.Resources.ledblack32px9; break;
                    case 10: image = Properties.Resources.ledblack32px10; break;
                    case 11: image = Properties.Resources.ledblack32px11; break;
                    case 12: image = Properties.Resources.ledblack32px12; break;
                    case 13: image = Properties.Resources.ledblack32px13; break;
                    case 14: image = Properties.Resources.ledblack32px14; break;
                    case 15: image = Properties.Resources.ledblack32px15; break;
                    case 16: image = Properties.Resources.ledblack32px16; break;
                    case 17: image = Properties.Resources.ledblack32px17; break;
                    case 18: image = Properties.Resources.ledblack32px18; break;
                    case 19: image = Properties.Resources.ledblack32px19; break;
                    case 20: image = Properties.Resources.ledblack32px20; break;
                    case 21: image = Properties.Resources.ledblack32px21; break;
                    case 22: image = Properties.Resources.ledblack32px22; break;
                    case 23: image = Properties.Resources.ledblack32px23; break;
                    case 24: image = Properties.Resources.ledblack32px24; break;
                    case 25: image = Properties.Resources.ledblack32px25; break;
                    case 26: image = Properties.Resources.ledblack32px26; break;
                    case 27: image = Properties.Resources.ledblack32px27; break;
                    case 28: image = Properties.Resources.ledblack32px28; break;
                    case 29: image = Properties.Resources.ledblack32px29; break;
                    case 30: image = Properties.Resources.ledblack32px30; break;
                    case 31: image = Properties.Resources.ledblack32px31; break;
                    case 32: image = Properties.Resources.ledblack32px32; break;
                    case 33: image = Properties.Resources.ledblack32px33; break;
                    case 34: image = Properties.Resources.ledblack32px34; break;
                    case 35: image = Properties.Resources.ledblack32px35; break;
                    case 36: image = Properties.Resources.ledblack32px36; break;
                    case 37: image = Properties.Resources.ledblack32px37; break;
                    case 38: image = Properties.Resources.ledblack32px38; break;
                    case 39: image = Properties.Resources.ledblack32px39; break;
                    case 40: image = Properties.Resources.ledblack32px40; break;
                    case 41: image = Properties.Resources.ledblack32px41; break;
                    case 42: image = Properties.Resources.ledblack32px42; break;
                    case 43: image = Properties.Resources.ledblack32px43; break;
                    case 44: image = Properties.Resources.ledblack32px44; break;
                    case 45: image = Properties.Resources.ledblack32px45; break;
                    case 46: image = Properties.Resources.ledblack32px46; break;
                    case 47: image = Properties.Resources.ledblack32px47; break;
                    case 48: image = Properties.Resources.ledblack32px48; break;
                    case 49: image = Properties.Resources.ledblack32px49; break;
                    case 50: image = Properties.Resources.ledblack32px50; break;
                    case 51: image = Properties.Resources.ledblack32px51; break;
                    case 52: image = Properties.Resources.ledblack32px52; break;
                    case 53: image = Properties.Resources.ledblack32px53; break;
                    case 54: image = Properties.Resources.ledblack32px54; break;
                    case 55: image = Properties.Resources.ledblack32px55; break;
                    case 56: image = Properties.Resources.ledblack32px56; break;
                    case 57: image = Properties.Resources.ledblack32px57; break;
                    case 58: image = Properties.Resources.ledblack32px58; break;
                    case 59: image = Properties.Resources.ledblack32px59; break;
                    case 60: image = Properties.Resources.ledblack32px60; break;
                    case 61: image = Properties.Resources.ledblack32px61; break;
                    case 62: image = Properties.Resources.ledblack32px62; break;
                    case 63: image = Properties.Resources.ledblack32px63; break;
                    case 64: image = Properties.Resources.ledblack32px64; break;
                    case 65: image = Properties.Resources.ledblack32px65; break;
                    case 66: image = Properties.Resources.ledblack32px66; break;
                    case 67: image = Properties.Resources.ledblack32px67; break;
                    case 68: image = Properties.Resources.ledblack32px68; break;
                    case 69: image = Properties.Resources.ledblack32px69; break;
                    case 70: image = Properties.Resources.ledblack32px70; break;
                    case 71: image = Properties.Resources.ledblack32px71; break;
                    case 72: image = Properties.Resources.ledblack32px72; break;
                    case 73: image = Properties.Resources.ledblack32px73; break;
                    case 74: image = Properties.Resources.ledblack32px74; break;
                    case 75: image = Properties.Resources.ledblack32px75; break;
                    case 76: image = Properties.Resources.ledblack32px76; break;
                    case 77: image = Properties.Resources.ledblack32px77; break;
                    case 78: image = Properties.Resources.ledblack32px78; break;
                    case 79: image = Properties.Resources.ledblack32px79; break;
                    case 80: image = Properties.Resources.ledblack32px80; break;
                    case 81: image = Properties.Resources.ledblack32px81; break;
                    case 82: image = Properties.Resources.ledblack32px82; break;
                    case 83: image = Properties.Resources.ledblack32px83; break;
                    case 84: image = Properties.Resources.ledblack32px84; break;
                    case 85: image = Properties.Resources.ledblack32px85; break;
                    case 86: image = Properties.Resources.ledblack32px86; break;
                    case 87: image = Properties.Resources.ledblack32px87; break;
                    case 88: image = Properties.Resources.ledblack32px88; break;
                    case 89: image = Properties.Resources.ledblack32px89; break;
                    case 90: image = Properties.Resources.ledblack32px90; break;
                    case 91: image = Properties.Resources.ledblack32px91; break;
                    case 92: image = Properties.Resources.ledblack32px92; break;
                    case 93: image = Properties.Resources.ledblack32px93; break;
                    case 94: image = Properties.Resources.ledblack32px94; break;
                    case 95: image = Properties.Resources.ledblack32px95; break;
                    case 96: image = Properties.Resources.ledblack32px96; break;
                    case 97: image = Properties.Resources.ledblack32px97; break;
                    case 98: image = Properties.Resources.ledblack32px98; break;
                    case 99: image = Properties.Resources.ledblack32px99; break;
                    case 100: image = Properties.Resources.ledblack32px100; break;
                    case 101: image = Properties.Resources.ledblack32px101; break;
                    case 102: image = Properties.Resources.ledblack32px102; break;
                    case 103: image = Properties.Resources.ledblack32px103; break;
                    case 104: image = Properties.Resources.ledblack32px104; break;
                    case 105: image = Properties.Resources.ledblack32px105; break;
                    case 106: image = Properties.Resources.ledblack32px106; break;
                    case 107: image = Properties.Resources.ledblack32px107; break;
                    case 108: image = Properties.Resources.ledblack32px108; break;
                    case 109: image = Properties.Resources.ledblack32px109; break;
                    case 110: image = Properties.Resources.ledblack32px110; break;
                    case 111: image = Properties.Resources.ledblack32px111; break;
                    case 112: image = Properties.Resources.ledblack32px112; break;
                    case 113: image = Properties.Resources.ledblack32px113; break;
                    case 114: image = Properties.Resources.ledblack32px114; break;
                    case 115: image = Properties.Resources.ledblack32px115; break;
                    case 116: image = Properties.Resources.ledblack32px116; break;
                    case 117: image = Properties.Resources.ledblack32px117; break;
                    case 118: image = Properties.Resources.ledblack32px118; break;
                    case 119: image = Properties.Resources.ledblack32px119; break;
                    case 120: image = Properties.Resources.ledblack32px120; break;
                    case 121: image = Properties.Resources.ledblack32px121; break;
                    case 122: image = Properties.Resources.ledblack32px122; break;
                    case 123: image = Properties.Resources.ledblack32px123; break;
                    case 124: image = Properties.Resources.ledblack32px124; break;
                    case 125: image = Properties.Resources.ledblack32px125; break;
                    case 126: image = Properties.Resources.ledblack32px126; break;
                    case 127: image = Properties.Resources.ledblack32px127; break;
                    case 128: image = Properties.Resources.ledblack32px128; break;
                    case 129: image = Properties.Resources.ledblack32px129; break;
                    case 130: image = Properties.Resources.ledblack32px130; break;
                    case 131: image = Properties.Resources.ledblack32px131; break;
                    case 132: image = Properties.Resources.ledblack32px132; break;
                    case 133: image = Properties.Resources.ledblack32px133; break;
                    case 134: image = Properties.Resources.ledblack32px134; break;
                    case 135: image = Properties.Resources.ledblack32px135; break;
                    case 136: image = Properties.Resources.ledblack32px136; break;
                    case 137: image = Properties.Resources.ledblack32px137; break;
                    case 138: image = Properties.Resources.ledblack32px138; break;
                    case 139: image = Properties.Resources.ledblack32px139; break;
                    case 140: image = Properties.Resources.ledblack32px140; break;
                    case 141: image = Properties.Resources.ledblack32px141; break;
                    case 142: image = Properties.Resources.ledblack32px142; break;
                    case 143: image = Properties.Resources.ledblack32px143; break;
                    case 144: image = Properties.Resources.ledblack32px144; break;
                    case 145: image = Properties.Resources.ledblack32px145; break;
                    case 146: image = Properties.Resources.ledblack32px146; break;
                    case 147: image = Properties.Resources.ledblack32px147; break;
                    case 148: image = Properties.Resources.ledblack32px148; break;
                    case 149: image = Properties.Resources.ledblack32px149; break;
                    case 150: image = Properties.Resources.ledblack32px150; break;
                    case 151: image = Properties.Resources.ledblack32px151; break;
                    case 152: image = Properties.Resources.ledblack32px152; break;
                    case 153: image = Properties.Resources.ledblack32px153; break;
                    case 154: image = Properties.Resources.ledblack32px154; break;
                    case 155: image = Properties.Resources.ledblack32px155; break;
                    case 156: image = Properties.Resources.ledblack32px156; break;
                    case 157: image = Properties.Resources.ledblack32px157; break;
                    case 158: image = Properties.Resources.ledblack32px158; break;
                    case 159: image = Properties.Resources.ledblack32px159; break;
                    case 160: image = Properties.Resources.ledblack32px160; break;
                    case 161: image = Properties.Resources.ledblack32px161; break;
                    case 162: image = Properties.Resources.ledblack32px162; break;
                    case 163: image = Properties.Resources.ledblack32px163; break;
                    case 164: image = Properties.Resources.ledblack32px164; break;
                    case 165: image = Properties.Resources.ledblack32px165; break;
                    case 166: image = Properties.Resources.ledblack32px166; break;
                    case 167: image = Properties.Resources.ledblack32px167; break;
                    case 168: image = Properties.Resources.ledblack32px168; break;
                    case 169: image = Properties.Resources.ledblack32px169; break;
                    case 170: image = Properties.Resources.ledblack32px170; break;
                    case 171: image = Properties.Resources.ledblack32px171; break;
                    case 172: image = Properties.Resources.ledblack32px172; break;
                    case 173: image = Properties.Resources.ledblack32px173; break;
                    case 174: image = Properties.Resources.ledblack32px174; break;
                    case 175: image = Properties.Resources.ledblack32px175; break;
                    case 176: image = Properties.Resources.ledblack32px176; break;
                    case 177: image = Properties.Resources.ledblack32px177; break;
                    case 178: image = Properties.Resources.ledblack32px178; break;
                    case 179: image = Properties.Resources.ledblack32px179; break;
                    case 180: image = Properties.Resources.ledblack32px180; break;
                    case 181: image = Properties.Resources.ledblack32px181; break;
                    case 182: image = Properties.Resources.ledblack32px182; break;
                    case 183: image = Properties.Resources.ledblack32px183; break;
                    case 184: image = Properties.Resources.ledblack32px184; break;
                    case 185: image = Properties.Resources.ledblack32px185; break;
                    case 186: image = Properties.Resources.ledblack32px186; break;
                    case 187: image = Properties.Resources.ledblack32px187; break;
                    case 188: image = Properties.Resources.ledblack32px188; break;
                    case 189: image = Properties.Resources.ledblack32px189; break;
                    case 190: image = Properties.Resources.ledblack32px190; break;
                    case 191: image = Properties.Resources.ledblack32px191; break;
                    case 192: image = Properties.Resources.ledblack32px192; break;
                    case 193: image = Properties.Resources.ledblack32px193; break;
                    case 194: image = Properties.Resources.ledblack32px194; break;
                    case 195: image = Properties.Resources.ledblack32px195; break;
                    case 196: image = Properties.Resources.ledblack32px196; break;
                    case 197: image = Properties.Resources.ledblack32px197; break;
                    case 198: image = Properties.Resources.ledblack32px198; break;
                    case 199: image = Properties.Resources.ledblack32px199; break;
                    case 200: image = Properties.Resources.ledblack32px200; break;
                    case 201: image = Properties.Resources.ledblack32px201; break;
                    case 202: image = Properties.Resources.ledblack32px202; break;
                    case 203: image = Properties.Resources.ledblack32px203; break;
                    case 204: image = Properties.Resources.ledblack32px204; break;
                    case 205: image = Properties.Resources.ledblack32px205; break;
                    case 206: image = Properties.Resources.ledblack32px206; break;
                    case 207: image = Properties.Resources.ledblack32px207; break;
                    case 208: image = Properties.Resources.ledblack32px208; break;
                    case 209: image = Properties.Resources.ledblack32px209; break;
                    case 210: image = Properties.Resources.ledblack32px210; break;
                    case 211: image = Properties.Resources.ledblack32px211; break;
                    case 212: image = Properties.Resources.ledblack32px212; break;
                    case 213: image = Properties.Resources.ledblack32px213; break;
                    case 214: image = Properties.Resources.ledblack32px214; break;
                    case 215: image = Properties.Resources.ledblack32px215; break;
                    case 216: image = Properties.Resources.ledblack32px216; break;
                    case 217: image = Properties.Resources.ledblack32px217; break;
                    case 218: image = Properties.Resources.ledblack32px218; break;
                    case 219: image = Properties.Resources.ledblack32px219; break;
                    case 220: image = Properties.Resources.ledblack32px220; break;
                    case 221: image = Properties.Resources.ledblack32px221; break;
                    case 222: image = Properties.Resources.ledblack32px222; break;
                    case 223: image = Properties.Resources.ledblack32px223; break;
                    case 224: image = Properties.Resources.ledblack32px224; break;
                    case 225: image = Properties.Resources.ledblack32px225; break;
                    case 226: image = Properties.Resources.ledblack32px226; break;
                    case 227: image = Properties.Resources.ledblack32px227; break;
                    case 228: image = Properties.Resources.ledblack32px228; break;
                    case 229: image = Properties.Resources.ledblack32px229; break;
                    case 230: image = Properties.Resources.ledblack32px230; break;
                    case 231: image = Properties.Resources.ledblack32px231; break;
                    case 232: image = Properties.Resources.ledblack32px232; break;
                    case 233: image = Properties.Resources.ledblack32px233; break;
                    case 234: image = Properties.Resources.ledblack32px234; break;
                    case 235: image = Properties.Resources.ledblack32px235; break;
                    case 236: image = Properties.Resources.ledblack32px236; break;
                    case 237: image = Properties.Resources.ledblack32px237; break;
                    case 238: image = Properties.Resources.ledblack32px238; break;
                    case 239: image = Properties.Resources.ledblack32px239; break;
                    case 240: image = Properties.Resources.ledblack32px240; break;
                    case 241: image = Properties.Resources.ledblack32px241; break;
                    case 242: image = Properties.Resources.ledblack32px242; break;
                    case 243: image = Properties.Resources.ledblack32px243; break;
                    case 244: image = Properties.Resources.ledblack32px244; break;
                    case 245: image = Properties.Resources.ledblack32px245; break;
                    case 246: image = Properties.Resources.ledblack32px246; break;
                    case 247: image = Properties.Resources.ledblack32px247; break;
                    case 248: image = Properties.Resources.ledblack32px248; break;
                    case 249: image = Properties.Resources.ledblack32px249; break;
                    case 250: image = Properties.Resources.ledblack32px250; break;
                    case 251: image = Properties.Resources.ledblack32px251; break;
                    case 252: image = Properties.Resources.ledblack32px252; break;
                    case 253: image = Properties.Resources.ledblack32px253; break;
                    case 254: image = Properties.Resources.ledblack32px254; break;
                    case 255: image = Properties.Resources.ledblack32px255; break;
                    default: image = Properties.Resources.Ledblack32px; break;
                }
            }

            else if (colour == LedColour.GREEN)
            {
                switch (number)
                {
                    case 0: image = Properties.Resources.LedGreen32px; break;
                    case 1: image = Properties.Resources.LedGreen32px1; break;
                    case 2: image = Properties.Resources.LedGreen32px2; break;
                    case 3: image = Properties.Resources.LedGreen32px3; break;
                    case 4: image = Properties.Resources.LedGreen32px4; break;
                    case 5: image = Properties.Resources.LedGreen32px5; break;
                    case 6: image = Properties.Resources.LedGreen32px6; break;
                    case 7: image = Properties.Resources.LedGreen32px7; break;
                    case 8: image = Properties.Resources.LedGreen32px8; break;
                    case 9: image = Properties.Resources.LedGreen32px9; break;
                    case 10: image = Properties.Resources.LedGreen32px10; break;
                    case 11: image = Properties.Resources.LedGreen32px11; break;
                    case 12: image = Properties.Resources.LedGreen32px12; break;
                    case 13: image = Properties.Resources.LedGreen32px13; break;
                    case 14: image = Properties.Resources.LedGreen32px14; break;
                    case 15: image = Properties.Resources.LedGreen32px15; break;
                    case 16: image = Properties.Resources.LedGreen32px16; break;
                    case 17: image = Properties.Resources.LedGreen32px17; break;
                    case 18: image = Properties.Resources.LedGreen32px18; break;
                    case 19: image = Properties.Resources.LedGreen32px19; break;
                    case 20: image = Properties.Resources.LedGreen32px20; break;
                    case 21: image = Properties.Resources.LedGreen32px21; break;
                    case 22: image = Properties.Resources.LedGreen32px22; break;
                    case 23: image = Properties.Resources.LedGreen32px23; break;
                    case 24: image = Properties.Resources.LedGreen32px24; break;
                    case 25: image = Properties.Resources.LedGreen32px25; break;
                    case 26: image = Properties.Resources.LedGreen32px26; break;
                    case 27: image = Properties.Resources.LedGreen32px27; break;
                    case 28: image = Properties.Resources.LedGreen32px28; break;
                    case 29: image = Properties.Resources.LedGreen32px29; break;
                    case 30: image = Properties.Resources.LedGreen32px30; break;
                    case 31: image = Properties.Resources.LedGreen32px31; break;
                    case 32: image = Properties.Resources.LedGreen32px32; break;
                    case 33: image = Properties.Resources.LedGreen32px33; break;
                    case 34: image = Properties.Resources.LedGreen32px34; break;
                    case 35: image = Properties.Resources.LedGreen32px35; break;
                    case 36: image = Properties.Resources.LedGreen32px36; break;
                    case 37: image = Properties.Resources.LedGreen32px37; break;
                    case 38: image = Properties.Resources.LedGreen32px38; break;
                    case 39: image = Properties.Resources.LedGreen32px39; break;
                    case 40: image = Properties.Resources.LedGreen32px40; break;
                    case 41: image = Properties.Resources.LedGreen32px41; break;
                    case 42: image = Properties.Resources.LedGreen32px42; break;
                    case 43: image = Properties.Resources.LedGreen32px43; break;
                    case 44: image = Properties.Resources.LedGreen32px44; break;
                    case 45: image = Properties.Resources.LedGreen32px45; break;
                    case 46: image = Properties.Resources.LedGreen32px46; break;
                    case 47: image = Properties.Resources.LedGreen32px47; break;
                    case 48: image = Properties.Resources.LedGreen32px48; break;
                    case 49: image = Properties.Resources.LedGreen32px49; break;
                    case 50: image = Properties.Resources.LedGreen32px50; break;
                    case 51: image = Properties.Resources.LedGreen32px51; break;
                    case 52: image = Properties.Resources.LedGreen32px52; break;
                    case 53: image = Properties.Resources.LedGreen32px53; break;
                    case 54: image = Properties.Resources.LedGreen32px54; break;
                    case 55: image = Properties.Resources.LedGreen32px55; break;
                    case 56: image = Properties.Resources.LedGreen32px56; break;
                    case 57: image = Properties.Resources.LedGreen32px57; break;
                    case 58: image = Properties.Resources.LedGreen32px58; break;
                    case 59: image = Properties.Resources.LedGreen32px59; break;
                    case 60: image = Properties.Resources.LedGreen32px60; break;
                    case 61: image = Properties.Resources.LedGreen32px61; break;
                    case 62: image = Properties.Resources.LedGreen32px62; break;
                    case 63: image = Properties.Resources.LedGreen32px63; break;
                    case 64: image = Properties.Resources.LedGreen32px64; break;
                    case 65: image = Properties.Resources.LedGreen32px65; break;
                    case 66: image = Properties.Resources.LedGreen32px66; break;
                    case 67: image = Properties.Resources.LedGreen32px67; break;
                    case 68: image = Properties.Resources.LedGreen32px68; break;
                    case 69: image = Properties.Resources.LedGreen32px69; break;
                    case 70: image = Properties.Resources.LedGreen32px70; break;
                    case 71: image = Properties.Resources.LedGreen32px71; break;
                    case 72: image = Properties.Resources.LedGreen32px72; break;
                    case 73: image = Properties.Resources.LedGreen32px73; break;
                    case 74: image = Properties.Resources.LedGreen32px74; break;
                    case 75: image = Properties.Resources.LedGreen32px75; break;
                    case 76: image = Properties.Resources.LedGreen32px76; break;
                    case 77: image = Properties.Resources.LedGreen32px77; break;
                    case 78: image = Properties.Resources.LedGreen32px78; break;
                    case 79: image = Properties.Resources.LedGreen32px79; break;
                    case 80: image = Properties.Resources.LedGreen32px80; break;
                    case 81: image = Properties.Resources.LedGreen32px81; break;
                    case 82: image = Properties.Resources.LedGreen32px82; break;
                    case 83: image = Properties.Resources.LedGreen32px83; break;
                    case 84: image = Properties.Resources.LedGreen32px84; break;
                    case 85: image = Properties.Resources.LedGreen32px85; break;
                    case 86: image = Properties.Resources.LedGreen32px86; break;
                    case 87: image = Properties.Resources.LedGreen32px87; break;
                    case 88: image = Properties.Resources.LedGreen32px88; break;
                    case 89: image = Properties.Resources.LedGreen32px89; break;
                    case 90: image = Properties.Resources.LedGreen32px90; break;
                    case 91: image = Properties.Resources.LedGreen32px91; break;
                    case 92: image = Properties.Resources.LedGreen32px92; break;
                    case 93: image = Properties.Resources.LedGreen32px93; break;
                    case 94: image = Properties.Resources.LedGreen32px94; break;
                    case 95: image = Properties.Resources.LedGreen32px95; break;
                    case 96: image = Properties.Resources.LedGreen32px96; break;
                    case 97: image = Properties.Resources.LedGreen32px97; break;
                    case 98: image = Properties.Resources.LedGreen32px98; break;
                    case 99: image = Properties.Resources.LedGreen32px99; break;
                    case 100: image = Properties.Resources.LedGreen32px100; break;
                    case 101: image = Properties.Resources.LedGreen32px101; break;
                    case 102: image = Properties.Resources.LedGreen32px102; break;
                    case 103: image = Properties.Resources.LedGreen32px103; break;
                    case 104: image = Properties.Resources.LedGreen32px104; break;
                    case 105: image = Properties.Resources.LedGreen32px105; break;
                    case 106: image = Properties.Resources.LedGreen32px106; break;
                    case 107: image = Properties.Resources.LedGreen32px107; break;
                    case 108: image = Properties.Resources.LedGreen32px108; break;
                    case 109: image = Properties.Resources.LedGreen32px109; break;
                    case 110: image = Properties.Resources.LedGreen32px110; break;
                    case 111: image = Properties.Resources.LedGreen32px111; break;
                    case 112: image = Properties.Resources.LedGreen32px112; break;
                    case 113: image = Properties.Resources.LedGreen32px113; break;
                    case 114: image = Properties.Resources.LedGreen32px114; break;
                    case 115: image = Properties.Resources.LedGreen32px115; break;
                    case 116: image = Properties.Resources.LedGreen32px116; break;
                    case 117: image = Properties.Resources.LedGreen32px117; break;
                    case 118: image = Properties.Resources.LedGreen32px118; break;
                    case 119: image = Properties.Resources.LedGreen32px119; break;
                    case 120: image = Properties.Resources.LedGreen32px120; break;
                    case 121: image = Properties.Resources.LedGreen32px121; break;
                    case 122: image = Properties.Resources.LedGreen32px122; break;
                    case 123: image = Properties.Resources.LedGreen32px123; break;
                    case 124: image = Properties.Resources.LedGreen32px124; break;
                    case 125: image = Properties.Resources.LedGreen32px125; break;
                    case 126: image = Properties.Resources.LedGreen32px126; break;
                    case 127: image = Properties.Resources.LedGreen32px127; break;
                    case 128: image = Properties.Resources.LedGreen32px128; break;
                    case 129: image = Properties.Resources.LedGreen32px129; break;
                    case 130: image = Properties.Resources.LedGreen32px130; break;
                    case 131: image = Properties.Resources.LedGreen32px131; break;
                    case 132: image = Properties.Resources.LedGreen32px132; break;
                    case 133: image = Properties.Resources.LedGreen32px133; break;
                    case 134: image = Properties.Resources.LedGreen32px134; break;
                    case 135: image = Properties.Resources.LedGreen32px135; break;
                    case 136: image = Properties.Resources.LedGreen32px136; break;
                    case 137: image = Properties.Resources.LedGreen32px137; break;
                    case 138: image = Properties.Resources.LedGreen32px138; break;
                    case 139: image = Properties.Resources.LedGreen32px139; break;
                    case 140: image = Properties.Resources.LedGreen32px140; break;
                    case 141: image = Properties.Resources.LedGreen32px141; break;
                    case 142: image = Properties.Resources.LedGreen32px142; break;
                    case 143: image = Properties.Resources.LedGreen32px143; break;
                    case 144: image = Properties.Resources.LedGreen32px144; break;
                    case 145: image = Properties.Resources.LedGreen32px145; break;
                    case 146: image = Properties.Resources.LedGreen32px146; break;
                    case 147: image = Properties.Resources.LedGreen32px147; break;
                    case 148: image = Properties.Resources.LedGreen32px148; break;
                    case 149: image = Properties.Resources.LedGreen32px149; break;
                    case 150: image = Properties.Resources.LedGreen32px150; break;
                    case 151: image = Properties.Resources.LedGreen32px151; break;
                    case 152: image = Properties.Resources.LedGreen32px152; break;
                    case 153: image = Properties.Resources.LedGreen32px153; break;
                    case 154: image = Properties.Resources.LedGreen32px154; break;
                    case 155: image = Properties.Resources.LedGreen32px155; break;
                    case 156: image = Properties.Resources.LedGreen32px156; break;
                    case 157: image = Properties.Resources.LedGreen32px157; break;
                    case 158: image = Properties.Resources.LedGreen32px158; break;
                    case 159: image = Properties.Resources.LedGreen32px159; break;
                    case 160: image = Properties.Resources.LedGreen32px160; break;
                    case 161: image = Properties.Resources.LedGreen32px161; break;
                    case 162: image = Properties.Resources.LedGreen32px162; break;
                    case 163: image = Properties.Resources.LedGreen32px163; break;
                    case 164: image = Properties.Resources.LedGreen32px164; break;
                    case 165: image = Properties.Resources.LedGreen32px165; break;
                    case 166: image = Properties.Resources.LedGreen32px166; break;
                    case 167: image = Properties.Resources.LedGreen32px167; break;
                    case 168: image = Properties.Resources.LedGreen32px168; break;
                    case 169: image = Properties.Resources.LedGreen32px169; break;
                    case 170: image = Properties.Resources.LedGreen32px170; break;
                    case 171: image = Properties.Resources.LedGreen32px171; break;
                    case 172: image = Properties.Resources.LedGreen32px172; break;
                    case 173: image = Properties.Resources.LedGreen32px173; break;
                    case 174: image = Properties.Resources.LedGreen32px174; break;
                    case 175: image = Properties.Resources.LedGreen32px175; break;
                    case 176: image = Properties.Resources.LedGreen32px176; break;
                    case 177: image = Properties.Resources.LedGreen32px177; break;
                    case 178: image = Properties.Resources.LedGreen32px178; break;
                    case 179: image = Properties.Resources.LedGreen32px179; break;
                    case 180: image = Properties.Resources.LedGreen32px180; break;
                    case 181: image = Properties.Resources.LedGreen32px181; break;
                    case 182: image = Properties.Resources.LedGreen32px182; break;
                    case 183: image = Properties.Resources.LedGreen32px183; break;
                    case 184: image = Properties.Resources.LedGreen32px184; break;
                    case 185: image = Properties.Resources.LedGreen32px185; break;
                    case 186: image = Properties.Resources.LedGreen32px186; break;
                    case 187: image = Properties.Resources.LedGreen32px187; break;
                    case 188: image = Properties.Resources.LedGreen32px188; break;
                    case 189: image = Properties.Resources.LedGreen32px189; break;
                    case 190: image = Properties.Resources.LedGreen32px190; break;
                    case 191: image = Properties.Resources.LedGreen32px191; break;
                    case 192: image = Properties.Resources.LedGreen32px192; break;
                    case 193: image = Properties.Resources.LedGreen32px193; break;
                    case 194: image = Properties.Resources.LedGreen32px194; break;
                    case 195: image = Properties.Resources.LedGreen32px195; break;
                    case 196: image = Properties.Resources.LedGreen32px196; break;
                    case 197: image = Properties.Resources.LedGreen32px197; break;
                    case 198: image = Properties.Resources.LedGreen32px198; break;
                    case 199: image = Properties.Resources.LedGreen32px199; break;
                    case 200: image = Properties.Resources.LedGreen32px200; break;
                    case 201: image = Properties.Resources.LedGreen32px201; break;
                    case 202: image = Properties.Resources.LedGreen32px202; break;
                    case 203: image = Properties.Resources.LedGreen32px203; break;
                    case 204: image = Properties.Resources.LedGreen32px204; break;
                    case 205: image = Properties.Resources.LedGreen32px205; break;
                    case 206: image = Properties.Resources.LedGreen32px206; break;
                    case 207: image = Properties.Resources.LedGreen32px207; break;
                    case 208: image = Properties.Resources.LedGreen32px208; break;
                    case 209: image = Properties.Resources.LedGreen32px209; break;
                    case 210: image = Properties.Resources.LedGreen32px210; break;
                    case 211: image = Properties.Resources.LedGreen32px211; break;
                    case 212: image = Properties.Resources.LedGreen32px212; break;
                    case 213: image = Properties.Resources.LedGreen32px213; break;
                    case 214: image = Properties.Resources.LedGreen32px214; break;
                    case 215: image = Properties.Resources.LedGreen32px215; break;
                    case 216: image = Properties.Resources.LedGreen32px216; break;
                    case 217: image = Properties.Resources.LedGreen32px217; break;
                    case 218: image = Properties.Resources.LedGreen32px218; break;
                    case 219: image = Properties.Resources.LedGreen32px219; break;
                    case 220: image = Properties.Resources.LedGreen32px220; break;
                    case 221: image = Properties.Resources.LedGreen32px221; break;
                    case 222: image = Properties.Resources.LedGreen32px222; break;
                    case 223: image = Properties.Resources.LedGreen32px223; break;
                    case 224: image = Properties.Resources.LedGreen32px224; break;
                    case 225: image = Properties.Resources.LedGreen32px225; break;
                    case 226: image = Properties.Resources.LedGreen32px226; break;
                    case 227: image = Properties.Resources.LedGreen32px227; break;
                    case 228: image = Properties.Resources.LedGreen32px228; break;
                    case 229: image = Properties.Resources.LedGreen32px229; break;
                    case 230: image = Properties.Resources.LedGreen32px230; break;
                    case 231: image = Properties.Resources.LedGreen32px231; break;
                    case 232: image = Properties.Resources.LedGreen32px232; break;
                    case 233: image = Properties.Resources.LedGreen32px233; break;
                    case 234: image = Properties.Resources.LedGreen32px234; break;
                    case 235: image = Properties.Resources.LedGreen32px235; break;
                    case 236: image = Properties.Resources.LedGreen32px236; break;
                    case 237: image = Properties.Resources.LedGreen32px237; break;
                    case 238: image = Properties.Resources.LedGreen32px238; break;
                    case 239: image = Properties.Resources.LedGreen32px239; break;
                    case 240: image = Properties.Resources.LedGreen32px240; break;
                    case 241: image = Properties.Resources.LedGreen32px241; break;
                    case 242: image = Properties.Resources.LedGreen32px242; break;
                    case 243: image = Properties.Resources.LedGreen32px243; break;
                    case 244: image = Properties.Resources.LedGreen32px244; break;
                    case 245: image = Properties.Resources.LedGreen32px245; break;
                    case 246: image = Properties.Resources.LedGreen32px246; break;
                    case 247: image = Properties.Resources.LedGreen32px247; break;
                    case 248: image = Properties.Resources.LedGreen32px248; break;
                    case 249: image = Properties.Resources.LedGreen32px249; break;
                    case 250: image = Properties.Resources.LedGreen32px250; break;
                    case 251: image = Properties.Resources.LedGreen32px251; break;
                    case 252: image = Properties.Resources.LedGreen32px252; break;
                    case 253: image = Properties.Resources.LedGreen32px253; break;
                    case 254: image = Properties.Resources.LedGreen32px254; break;
                    case 255: image = Properties.Resources.LedGreen32px255; break;

                    default: image = Properties.Resources.LedGreen32px; break;
                }
            }

            else if (colour == LedColour.RED)
            {
                switch (number)
                {
                    case 0: image = Properties.Resources.LedRed32px; break;
                    case 1: image = Properties.Resources.LedRed32px1; break;
                    case 2: image = Properties.Resources.LedRed32px2; break;
                    case 3: image = Properties.Resources.LedRed32px3; break;
                    case 4: image = Properties.Resources.LedRed32px4; break;
                    case 5: image = Properties.Resources.LedRed32px5; break;
                    case 6: image = Properties.Resources.LedRed32px6; break;
                    case 7: image = Properties.Resources.LedRed32px7; break;
                    case 8: image = Properties.Resources.LedRed32px8; break;
                    case 9: image = Properties.Resources.LedRed32px9; break;
                    case 10: image = Properties.Resources.LedRed32px10; break;
                    case 11: image = Properties.Resources.LedRed32px11; break;
                    case 12: image = Properties.Resources.LedRed32px12; break;
                    case 13: image = Properties.Resources.LedRed32px13; break;
                    case 14: image = Properties.Resources.LedRed32px14; break;
                    case 15: image = Properties.Resources.LedRed32px15; break;
                    case 16: image = Properties.Resources.LedRed32px16; break;
                    case 17: image = Properties.Resources.LedRed32px17; break;
                    case 18: image = Properties.Resources.LedRed32px18; break;
                    case 19: image = Properties.Resources.LedRed32px19; break;
                    case 20: image = Properties.Resources.LedRed32px20; break;
                    case 21: image = Properties.Resources.LedRed32px21; break;
                    case 22: image = Properties.Resources.LedRed32px22; break;
                    case 23: image = Properties.Resources.LedRed32px23; break;
                    case 24: image = Properties.Resources.LedRed32px24; break;
                    case 25: image = Properties.Resources.LedRed32px25; break;
                    case 26: image = Properties.Resources.LedRed32px26; break;
                    case 27: image = Properties.Resources.LedRed32px27; break;
                    case 28: image = Properties.Resources.LedRed32px28; break;
                    case 29: image = Properties.Resources.LedRed32px29; break;
                    case 30: image = Properties.Resources.LedRed32px30; break;
                    case 31: image = Properties.Resources.LedRed32px31; break;
                    case 32: image = Properties.Resources.LedRed32px32; break;
                    case 33: image = Properties.Resources.LedRed32px33; break;
                    case 34: image = Properties.Resources.LedRed32px34; break;
                    case 35: image = Properties.Resources.LedRed32px35; break;
                    case 36: image = Properties.Resources.LedRed32px36; break;
                    case 37: image = Properties.Resources.LedRed32px37; break;
                    case 38: image = Properties.Resources.LedRed32px38; break;
                    case 39: image = Properties.Resources.LedRed32px39; break;
                    case 40: image = Properties.Resources.LedRed32px40; break;
                    case 41: image = Properties.Resources.LedRed32px41; break;
                    case 42: image = Properties.Resources.LedRed32px42; break;
                    case 43: image = Properties.Resources.LedRed32px43; break;
                    case 44: image = Properties.Resources.LedRed32px44; break;
                    case 45: image = Properties.Resources.LedRed32px45; break;
                    case 46: image = Properties.Resources.LedRed32px46; break;
                    case 47: image = Properties.Resources.LedRed32px47; break;
                    case 48: image = Properties.Resources.LedRed32px48; break;
                    case 49: image = Properties.Resources.LedRed32px49; break;
                    case 50: image = Properties.Resources.LedRed32px50; break;
                    case 51: image = Properties.Resources.LedRed32px51; break;
                    case 52: image = Properties.Resources.LedRed32px52; break;
                    case 53: image = Properties.Resources.LedRed32px53; break;
                    case 54: image = Properties.Resources.LedRed32px54; break;
                    case 55: image = Properties.Resources.LedRed32px55; break;
                    case 56: image = Properties.Resources.LedRed32px56; break;
                    case 57: image = Properties.Resources.LedRed32px57; break;
                    case 58: image = Properties.Resources.LedRed32px58; break;
                    case 59: image = Properties.Resources.LedRed32px59; break;
                    case 60: image = Properties.Resources.LedRed32px60; break;
                    case 61: image = Properties.Resources.LedRed32px61; break;
                    case 62: image = Properties.Resources.LedRed32px62; break;
                    case 63: image = Properties.Resources.LedRed32px63; break;
                    case 64: image = Properties.Resources.LedRed32px64; break;
                    case 65: image = Properties.Resources.LedRed32px65; break;
                    case 66: image = Properties.Resources.LedRed32px66; break;
                    case 67: image = Properties.Resources.LedRed32px67; break;
                    case 68: image = Properties.Resources.LedRed32px68; break;
                    case 69: image = Properties.Resources.LedRed32px69; break;
                    case 70: image = Properties.Resources.LedRed32px70; break;
                    case 71: image = Properties.Resources.LedRed32px71; break;
                    case 72: image = Properties.Resources.LedRed32px72; break;
                    case 73: image = Properties.Resources.LedRed32px73; break;
                    case 74: image = Properties.Resources.LedRed32px74; break;
                    case 75: image = Properties.Resources.LedRed32px75; break;
                    case 76: image = Properties.Resources.LedRed32px76; break;
                    case 77: image = Properties.Resources.LedRed32px77; break;
                    case 78: image = Properties.Resources.LedRed32px78; break;
                    case 79: image = Properties.Resources.LedRed32px79; break;
                    case 80: image = Properties.Resources.LedRed32px80; break;
                    case 81: image = Properties.Resources.LedRed32px81; break;
                    case 82: image = Properties.Resources.LedRed32px82; break;
                    case 83: image = Properties.Resources.LedRed32px83; break;
                    case 84: image = Properties.Resources.LedRed32px84; break;
                    case 85: image = Properties.Resources.LedRed32px85; break;
                    case 86: image = Properties.Resources.LedRed32px86; break;
                    case 87: image = Properties.Resources.LedRed32px87; break;
                    case 88: image = Properties.Resources.LedRed32px88; break;
                    case 89: image = Properties.Resources.LedRed32px89; break;
                    case 90: image = Properties.Resources.LedRed32px90; break;
                    case 91: image = Properties.Resources.LedRed32px91; break;
                    case 92: image = Properties.Resources.LedRed32px92; break;
                    case 93: image = Properties.Resources.LedRed32px93; break;
                    case 94: image = Properties.Resources.LedRed32px94; break;
                    case 95: image = Properties.Resources.LedRed32px95; break;
                    case 96: image = Properties.Resources.LedRed32px96; break;
                    case 97: image = Properties.Resources.LedRed32px97; break;
                    case 98: image = Properties.Resources.LedRed32px98; break;
                    case 99: image = Properties.Resources.LedRed32px99; break;
                    case 100: image = Properties.Resources.LedRed32px100; break;
                    case 101: image = Properties.Resources.LedRed32px101; break;
                    case 102: image = Properties.Resources.LedRed32px102; break;
                    case 103: image = Properties.Resources.LedRed32px103; break;
                    case 104: image = Properties.Resources.LedRed32px104; break;
                    case 105: image = Properties.Resources.LedRed32px105; break;
                    case 106: image = Properties.Resources.LedRed32px106; break;
                    case 107: image = Properties.Resources.LedRed32px107; break;
                    case 108: image = Properties.Resources.LedRed32px108; break;
                    case 109: image = Properties.Resources.LedRed32px109; break;
                    case 110: image = Properties.Resources.LedRed32px110; break;
                    case 111: image = Properties.Resources.LedRed32px111; break;
                    case 112: image = Properties.Resources.LedRed32px112; break;
                    case 113: image = Properties.Resources.LedRed32px113; break;
                    case 114: image = Properties.Resources.LedRed32px114; break;
                    case 115: image = Properties.Resources.LedRed32px115; break;
                    case 116: image = Properties.Resources.LedRed32px116; break;
                    case 117: image = Properties.Resources.LedRed32px117; break;
                    case 118: image = Properties.Resources.LedRed32px118; break;
                    case 119: image = Properties.Resources.LedRed32px119; break;
                    case 120: image = Properties.Resources.LedRed32px120; break;
                    case 121: image = Properties.Resources.LedRed32px121; break;
                    case 122: image = Properties.Resources.LedRed32px122; break;
                    case 123: image = Properties.Resources.LedRed32px123; break;
                    case 124: image = Properties.Resources.LedRed32px124; break;
                    case 125: image = Properties.Resources.LedRed32px125; break;
                    case 126: image = Properties.Resources.LedRed32px126; break;
                    case 127: image = Properties.Resources.LedRed32px127; break;
                    case 128: image = Properties.Resources.LedRed32px128; break;
                    case 129: image = Properties.Resources.LedRed32px129; break;
                    case 130: image = Properties.Resources.LedRed32px130; break;
                    case 131: image = Properties.Resources.LedRed32px131; break;
                    case 132: image = Properties.Resources.LedRed32px132; break;
                    case 133: image = Properties.Resources.LedRed32px133; break;
                    case 134: image = Properties.Resources.LedRed32px134; break;
                    case 135: image = Properties.Resources.LedRed32px135; break;
                    case 136: image = Properties.Resources.LedRed32px136; break;
                    case 137: image = Properties.Resources.LedRed32px137; break;
                    case 138: image = Properties.Resources.LedRed32px138; break;
                    case 139: image = Properties.Resources.LedRed32px139; break;
                    case 140: image = Properties.Resources.LedRed32px140; break;
                    case 141: image = Properties.Resources.LedRed32px141; break;
                    case 142: image = Properties.Resources.LedRed32px142; break;
                    case 143: image = Properties.Resources.LedRed32px143; break;
                    case 144: image = Properties.Resources.LedRed32px144; break;
                    case 145: image = Properties.Resources.LedRed32px145; break;
                    case 146: image = Properties.Resources.LedRed32px146; break;
                    case 147: image = Properties.Resources.LedRed32px147; break;
                    case 148: image = Properties.Resources.LedRed32px148; break;
                    case 149: image = Properties.Resources.LedRed32px149; break;
                    case 150: image = Properties.Resources.LedRed32px150; break;
                    case 151: image = Properties.Resources.LedRed32px151; break;
                    case 152: image = Properties.Resources.LedRed32px152; break;
                    case 153: image = Properties.Resources.LedRed32px153; break;
                    case 154: image = Properties.Resources.LedRed32px154; break;
                    case 155: image = Properties.Resources.LedRed32px155; break;
                    case 156: image = Properties.Resources.LedRed32px156; break;
                    case 157: image = Properties.Resources.LedRed32px157; break;
                    case 158: image = Properties.Resources.LedRed32px158; break;
                    case 159: image = Properties.Resources.LedRed32px159; break;
                    case 160: image = Properties.Resources.LedRed32px160; break;
                    case 161: image = Properties.Resources.LedRed32px161; break;
                    case 162: image = Properties.Resources.LedRed32px162; break;
                    case 163: image = Properties.Resources.LedRed32px163; break;
                    case 164: image = Properties.Resources.LedRed32px164; break;
                    case 165: image = Properties.Resources.LedRed32px165; break;
                    case 166: image = Properties.Resources.LedRed32px166; break;
                    case 167: image = Properties.Resources.LedRed32px167; break;
                    case 168: image = Properties.Resources.LedRed32px168; break;
                    case 169: image = Properties.Resources.LedRed32px169; break;
                    case 170: image = Properties.Resources.LedRed32px170; break;
                    case 171: image = Properties.Resources.LedRed32px171; break;
                    case 172: image = Properties.Resources.LedRed32px172; break;
                    case 173: image = Properties.Resources.LedRed32px173; break;
                    case 174: image = Properties.Resources.LedRed32px174; break;
                    case 175: image = Properties.Resources.LedRed32px175; break;
                    case 176: image = Properties.Resources.LedRed32px176; break;
                    case 177: image = Properties.Resources.LedRed32px177; break;
                    case 178: image = Properties.Resources.LedRed32px178; break;
                    case 179: image = Properties.Resources.LedRed32px179; break;
                    case 180: image = Properties.Resources.LedRed32px180; break;
                    case 181: image = Properties.Resources.LedRed32px181; break;
                    case 182: image = Properties.Resources.LedRed32px182; break;
                    case 183: image = Properties.Resources.LedRed32px183; break;
                    case 184: image = Properties.Resources.LedRed32px184; break;
                    case 185: image = Properties.Resources.LedRed32px185; break;
                    case 186: image = Properties.Resources.LedRed32px186; break;
                    case 187: image = Properties.Resources.LedRed32px187; break;
                    case 188: image = Properties.Resources.LedRed32px188; break;
                    case 189: image = Properties.Resources.LedRed32px189; break;
                    case 190: image = Properties.Resources.LedRed32px190; break;
                    case 191: image = Properties.Resources.LedRed32px191; break;
                    case 192: image = Properties.Resources.LedRed32px192; break;
                    case 193: image = Properties.Resources.LedRed32px193; break;
                    case 194: image = Properties.Resources.LedRed32px194; break;
                    case 195: image = Properties.Resources.LedRed32px195; break;
                    case 196: image = Properties.Resources.LedRed32px196; break;
                    case 197: image = Properties.Resources.LedRed32px197; break;
                    case 198: image = Properties.Resources.LedRed32px198; break;
                    case 199: image = Properties.Resources.LedRed32px199; break;
                    case 200: image = Properties.Resources.LedRed32px200; break;
                    case 201: image = Properties.Resources.LedRed32px201; break;
                    case 202: image = Properties.Resources.LedRed32px202; break;
                    case 203: image = Properties.Resources.LedRed32px203; break;
                    case 204: image = Properties.Resources.LedRed32px204; break;
                    case 205: image = Properties.Resources.LedRed32px205; break;
                    case 206: image = Properties.Resources.LedRed32px206; break;
                    case 207: image = Properties.Resources.LedRed32px207; break;
                    case 208: image = Properties.Resources.LedRed32px208; break;
                    case 209: image = Properties.Resources.LedRed32px209; break;
                    case 210: image = Properties.Resources.LedRed32px210; break;
                    case 211: image = Properties.Resources.LedRed32px211; break;
                    case 212: image = Properties.Resources.LedRed32px212; break;
                    case 213: image = Properties.Resources.LedRed32px213; break;
                    case 214: image = Properties.Resources.LedRed32px214; break;
                    case 215: image = Properties.Resources.LedRed32px215; break;
                    case 216: image = Properties.Resources.LedRed32px216; break;
                    case 217: image = Properties.Resources.LedRed32px217; break;
                    case 218: image = Properties.Resources.LedRed32px218; break;
                    case 219: image = Properties.Resources.LedRed32px219; break;
                    case 220: image = Properties.Resources.LedRed32px220; break;
                    case 221: image = Properties.Resources.LedRed32px221; break;
                    case 222: image = Properties.Resources.LedRed32px222; break;
                    case 223: image = Properties.Resources.LedRed32px223; break;
                    case 224: image = Properties.Resources.LedRed32px224; break;
                    case 225: image = Properties.Resources.LedRed32px225; break;
                    case 226: image = Properties.Resources.LedRed32px226; break;
                    case 227: image = Properties.Resources.LedRed32px227; break;
                    case 228: image = Properties.Resources.LedRed32px228; break;
                    case 229: image = Properties.Resources.LedRed32px229; break;
                    case 230: image = Properties.Resources.LedRed32px230; break;
                    case 231: image = Properties.Resources.LedRed32px231; break;
                    case 232: image = Properties.Resources.LedRed32px232; break;
                    case 233: image = Properties.Resources.LedRed32px233; break;
                    case 234: image = Properties.Resources.LedRed32px234; break;
                    case 235: image = Properties.Resources.LedRed32px235; break;
                    case 236: image = Properties.Resources.LedRed32px236; break;
                    case 237: image = Properties.Resources.LedRed32px237; break;
                    case 238: image = Properties.Resources.LedRed32px238; break;
                    case 239: image = Properties.Resources.LedRed32px239; break;
                    case 240: image = Properties.Resources.LedRed32px240; break;
                    case 241: image = Properties.Resources.LedRed32px241; break;
                    case 242: image = Properties.Resources.LedRed32px242; break;
                    case 243: image = Properties.Resources.LedRed32px243; break;
                    case 244: image = Properties.Resources.LedRed32px244; break;
                    case 245: image = Properties.Resources.LedRed32px245; break;
                    case 246: image = Properties.Resources.LedRed32px246; break;
                    case 247: image = Properties.Resources.LedRed32px247; break;
                    case 248: image = Properties.Resources.LedRed32px248; break;
                    case 249: image = Properties.Resources.LedRed32px249; break;
                    case 250: image = Properties.Resources.LedRed32px250; break;
                    case 251: image = Properties.Resources.LedRed32px251; break;
                    case 252: image = Properties.Resources.LedRed32px252; break;
                    case 253: image = Properties.Resources.LedRed32px253; break;
                    case 254: image = Properties.Resources.LedRed32px254; break;
                    case 255: image = Properties.Resources.LedRed32px255; break;
                    default: image = Properties.Resources.LedRed32px; break;
                }
            }

            else if (colour == LedColour.YELLOW)
            {
                switch (number)
                {
                    case 0: image = Properties.Resources.LedYellow32px; break;
                    case 1: image = Properties.Resources.LedYellow32px1; break;
                    case 2: image = Properties.Resources.LedYellow32px2; break;
                    case 3: image = Properties.Resources.LedYellow32px3; break;
                    case 4: image = Properties.Resources.LedYellow32px4; break;
                    case 5: image = Properties.Resources.LedYellow32px5; break;
                    case 6: image = Properties.Resources.LedYellow32px6; break;
                    case 7: image = Properties.Resources.LedYellow32px7; break;
                    case 8: image = Properties.Resources.LedYellow32px8; break;
                    case 9: image = Properties.Resources.LedYellow32px9; break;
                    case 10: image = Properties.Resources.LedYellow32px10; break;
                    case 11: image = Properties.Resources.LedYellow32px11; break;
                    case 12: image = Properties.Resources.LedYellow32px12; break;
                    case 13: image = Properties.Resources.LedYellow32px13; break;
                    case 14: image = Properties.Resources.LedYellow32px14; break;
                    case 15: image = Properties.Resources.LedYellow32px15; break;
                    case 16: image = Properties.Resources.LedYellow32px16; break;
                    case 17: image = Properties.Resources.LedYellow32px17; break;
                    case 18: image = Properties.Resources.LedYellow32px18; break;
                    case 19: image = Properties.Resources.LedYellow32px19; break;
                    case 20: image = Properties.Resources.LedYellow32px20; break;
                    case 21: image = Properties.Resources.LedYellow32px21; break;
                    case 22: image = Properties.Resources.LedYellow32px22; break;
                    case 23: image = Properties.Resources.LedYellow32px23; break;
                    case 24: image = Properties.Resources.LedYellow32px24; break;
                    case 25: image = Properties.Resources.LedYellow32px25; break;
                    case 26: image = Properties.Resources.LedYellow32px26; break;
                    case 27: image = Properties.Resources.LedYellow32px27; break;
                    case 28: image = Properties.Resources.LedYellow32px28; break;
                    case 29: image = Properties.Resources.LedYellow32px29; break;
                    case 30: image = Properties.Resources.LedYellow32px30; break;
                    case 31: image = Properties.Resources.LedYellow32px31; break;
                    case 32: image = Properties.Resources.LedYellow32px32; break;
                    case 33: image = Properties.Resources.LedYellow32px33; break;
                    case 34: image = Properties.Resources.LedYellow32px34; break;
                    case 35: image = Properties.Resources.LedYellow32px35; break;
                    case 36: image = Properties.Resources.LedYellow32px36; break;
                    case 37: image = Properties.Resources.LedYellow32px37; break;
                    case 38: image = Properties.Resources.LedYellow32px38; break;
                    case 39: image = Properties.Resources.LedYellow32px39; break;
                    case 40: image = Properties.Resources.LedYellow32px40; break;
                    case 41: image = Properties.Resources.LedYellow32px41; break;
                    case 42: image = Properties.Resources.LedYellow32px42; break;
                    case 43: image = Properties.Resources.LedYellow32px43; break;
                    case 44: image = Properties.Resources.LedYellow32px44; break;
                    case 45: image = Properties.Resources.LedYellow32px45; break;
                    case 46: image = Properties.Resources.LedYellow32px46; break;
                    case 47: image = Properties.Resources.LedYellow32px47; break;
                    case 48: image = Properties.Resources.LedYellow32px48; break;
                    case 49: image = Properties.Resources.LedYellow32px49; break;
                    case 50: image = Properties.Resources.LedYellow32px50; break;
                    case 51: image = Properties.Resources.LedYellow32px51; break;
                    case 52: image = Properties.Resources.LedYellow32px52; break;
                    case 53: image = Properties.Resources.LedYellow32px53; break;
                    case 54: image = Properties.Resources.LedYellow32px54; break;
                    case 55: image = Properties.Resources.LedYellow32px55; break;
                    case 56: image = Properties.Resources.LedYellow32px56; break;
                    case 57: image = Properties.Resources.LedYellow32px57; break;
                    case 58: image = Properties.Resources.LedYellow32px58; break;
                    case 59: image = Properties.Resources.LedYellow32px59; break;
                    case 60: image = Properties.Resources.LedYellow32px60; break;
                    case 61: image = Properties.Resources.LedYellow32px61; break;
                    case 62: image = Properties.Resources.LedYellow32px62; break;
                    case 63: image = Properties.Resources.LedYellow32px63; break;
                    case 64: image = Properties.Resources.LedYellow32px64; break;
                    case 65: image = Properties.Resources.LedYellow32px65; break;
                    case 66: image = Properties.Resources.LedYellow32px66; break;
                    case 67: image = Properties.Resources.LedYellow32px67; break;
                    case 68: image = Properties.Resources.LedYellow32px68; break;
                    case 69: image = Properties.Resources.LedYellow32px69; break;
                    case 70: image = Properties.Resources.LedYellow32px70; break;
                    case 71: image = Properties.Resources.LedYellow32px71; break;
                    case 72: image = Properties.Resources.LedYellow32px72; break;
                    case 73: image = Properties.Resources.LedYellow32px73; break;
                    case 74: image = Properties.Resources.LedYellow32px74; break;
                    case 75: image = Properties.Resources.LedYellow32px75; break;
                    case 76: image = Properties.Resources.LedYellow32px76; break;
                    case 77: image = Properties.Resources.LedYellow32px77; break;
                    case 78: image = Properties.Resources.LedYellow32px78; break;
                    case 79: image = Properties.Resources.LedYellow32px79; break;
                    case 80: image = Properties.Resources.LedYellow32px80; break;
                    case 81: image = Properties.Resources.LedYellow32px81; break;
                    case 82: image = Properties.Resources.LedYellow32px82; break;
                    case 83: image = Properties.Resources.LedYellow32px83; break;
                    case 84: image = Properties.Resources.LedYellow32px84; break;
                    case 85: image = Properties.Resources.LedYellow32px85; break;
                    case 86: image = Properties.Resources.LedYellow32px86; break;
                    case 87: image = Properties.Resources.LedYellow32px87; break;
                    case 88: image = Properties.Resources.LedYellow32px88; break;
                    case 89: image = Properties.Resources.LedYellow32px89; break;
                    case 90: image = Properties.Resources.LedYellow32px90; break;
                    case 91: image = Properties.Resources.LedYellow32px91; break;
                    case 92: image = Properties.Resources.LedYellow32px92; break;
                    case 93: image = Properties.Resources.LedYellow32px93; break;
                    case 94: image = Properties.Resources.LedYellow32px94; break;
                    case 95: image = Properties.Resources.LedYellow32px95; break;
                    case 96: image = Properties.Resources.LedYellow32px96; break;
                    case 97: image = Properties.Resources.LedYellow32px97; break;
                    case 98: image = Properties.Resources.LedYellow32px98; break;
                    case 99: image = Properties.Resources.LedYellow32px99; break;
                    case 100: image = Properties.Resources.LedYellow32px100; break;
                    case 101: image = Properties.Resources.LedYellow32px101; break;
                    case 102: image = Properties.Resources.LedYellow32px102; break;
                    case 103: image = Properties.Resources.LedYellow32px103; break;
                    case 104: image = Properties.Resources.LedYellow32px104; break;
                    case 105: image = Properties.Resources.LedYellow32px105; break;
                    case 106: image = Properties.Resources.LedYellow32px106; break;
                    case 107: image = Properties.Resources.LedYellow32px107; break;
                    case 108: image = Properties.Resources.LedYellow32px108; break;
                    case 109: image = Properties.Resources.LedYellow32px109; break;
                    case 110: image = Properties.Resources.LedYellow32px110; break;
                    case 111: image = Properties.Resources.LedYellow32px111; break;
                    case 112: image = Properties.Resources.LedYellow32px112; break;
                    case 113: image = Properties.Resources.LedYellow32px113; break;
                    case 114: image = Properties.Resources.LedYellow32px114; break;
                    case 115: image = Properties.Resources.LedYellow32px115; break;
                    case 116: image = Properties.Resources.LedYellow32px116; break;
                    case 117: image = Properties.Resources.LedYellow32px117; break;
                    case 118: image = Properties.Resources.LedYellow32px118; break;
                    case 119: image = Properties.Resources.LedYellow32px119; break;
                    case 120: image = Properties.Resources.LedYellow32px120; break;
                    case 121: image = Properties.Resources.LedYellow32px121; break;
                    case 122: image = Properties.Resources.LedYellow32px122; break;
                    case 123: image = Properties.Resources.LedYellow32px123; break;
                    case 124: image = Properties.Resources.LedYellow32px124; break;
                    case 125: image = Properties.Resources.LedYellow32px125; break;
                    case 126: image = Properties.Resources.LedYellow32px126; break;
                    case 127: image = Properties.Resources.LedYellow32px127; break;
                    case 128: image = Properties.Resources.LedYellow32px128; break;
                    case 129: image = Properties.Resources.LedYellow32px129; break;
                    case 130: image = Properties.Resources.LedYellow32px130; break;
                    case 131: image = Properties.Resources.LedYellow32px131; break;
                    case 132: image = Properties.Resources.LedYellow32px132; break;
                    case 133: image = Properties.Resources.LedYellow32px133; break;
                    case 134: image = Properties.Resources.LedYellow32px134; break;
                    case 135: image = Properties.Resources.LedYellow32px135; break;
                    case 136: image = Properties.Resources.LedYellow32px136; break;
                    case 137: image = Properties.Resources.LedYellow32px137; break;
                    case 138: image = Properties.Resources.LedYellow32px138; break;
                    case 139: image = Properties.Resources.LedYellow32px139; break;
                    case 140: image = Properties.Resources.LedYellow32px140; break;
                    case 141: image = Properties.Resources.LedYellow32px141; break;
                    case 142: image = Properties.Resources.LedYellow32px142; break;
                    case 143: image = Properties.Resources.LedYellow32px143; break;
                    case 144: image = Properties.Resources.LedYellow32px144; break;
                    case 145: image = Properties.Resources.LedYellow32px145; break;
                    case 146: image = Properties.Resources.LedYellow32px146; break;
                    case 147: image = Properties.Resources.LedYellow32px147; break;
                    case 148: image = Properties.Resources.LedYellow32px148; break;
                    case 149: image = Properties.Resources.LedYellow32px149; break;
                    case 150: image = Properties.Resources.LedYellow32px150; break;
                    case 151: image = Properties.Resources.LedYellow32px151; break;
                    case 152: image = Properties.Resources.LedYellow32px152; break;
                    case 153: image = Properties.Resources.LedYellow32px153; break;
                    case 154: image = Properties.Resources.LedYellow32px154; break;
                    case 155: image = Properties.Resources.LedYellow32px155; break;
                    case 156: image = Properties.Resources.LedYellow32px156; break;
                    case 157: image = Properties.Resources.LedYellow32px157; break;
                    case 158: image = Properties.Resources.LedYellow32px158; break;
                    case 159: image = Properties.Resources.LedYellow32px159; break;
                    case 160: image = Properties.Resources.LedYellow32px160; break;
                    case 161: image = Properties.Resources.LedYellow32px161; break;
                    case 162: image = Properties.Resources.LedYellow32px162; break;
                    case 163: image = Properties.Resources.LedYellow32px163; break;
                    case 164: image = Properties.Resources.LedYellow32px164; break;
                    case 165: image = Properties.Resources.LedYellow32px165; break;
                    case 166: image = Properties.Resources.LedYellow32px166; break;
                    case 167: image = Properties.Resources.LedYellow32px167; break;
                    case 168: image = Properties.Resources.LedYellow32px168; break;
                    case 169: image = Properties.Resources.LedYellow32px169; break;
                    case 170: image = Properties.Resources.LedYellow32px170; break;
                    case 171: image = Properties.Resources.LedYellow32px171; break;
                    case 172: image = Properties.Resources.LedYellow32px172; break;
                    case 173: image = Properties.Resources.LedYellow32px173; break;
                    case 174: image = Properties.Resources.LedYellow32px174; break;
                    case 175: image = Properties.Resources.LedYellow32px175; break;
                    case 176: image = Properties.Resources.LedYellow32px176; break;
                    case 177: image = Properties.Resources.LedYellow32px177; break;
                    case 178: image = Properties.Resources.LedYellow32px178; break;
                    case 179: image = Properties.Resources.LedYellow32px179; break;
                    case 180: image = Properties.Resources.LedYellow32px180; break;
                    case 181: image = Properties.Resources.LedYellow32px181; break;
                    case 182: image = Properties.Resources.LedYellow32px182; break;
                    case 183: image = Properties.Resources.LedYellow32px183; break;
                    case 184: image = Properties.Resources.LedYellow32px184; break;
                    case 185: image = Properties.Resources.LedYellow32px185; break;
                    case 186: image = Properties.Resources.LedYellow32px186; break;
                    case 187: image = Properties.Resources.LedYellow32px187; break;
                    case 188: image = Properties.Resources.LedYellow32px188; break;
                    case 189: image = Properties.Resources.LedYellow32px189; break;
                    case 190: image = Properties.Resources.LedYellow32px190; break;
                    case 191: image = Properties.Resources.LedYellow32px191; break;
                    case 192: image = Properties.Resources.LedYellow32px192; break;
                    case 193: image = Properties.Resources.LedYellow32px193; break;
                    case 194: image = Properties.Resources.LedYellow32px194; break;
                    case 195: image = Properties.Resources.LedYellow32px195; break;
                    case 196: image = Properties.Resources.LedYellow32px196; break;
                    case 197: image = Properties.Resources.LedYellow32px197; break;
                    case 198: image = Properties.Resources.LedYellow32px198; break;
                    case 199: image = Properties.Resources.LedYellow32px199; break;
                    case 200: image = Properties.Resources.LedYellow32px200; break;
                    case 201: image = Properties.Resources.LedYellow32px201; break;
                    case 202: image = Properties.Resources.LedYellow32px202; break;
                    case 203: image = Properties.Resources.LedYellow32px203; break;
                    case 204: image = Properties.Resources.LedYellow32px204; break;
                    case 205: image = Properties.Resources.LedYellow32px205; break;
                    case 206: image = Properties.Resources.LedYellow32px206; break;
                    case 207: image = Properties.Resources.LedYellow32px207; break;
                    case 208: image = Properties.Resources.LedYellow32px208; break;
                    case 209: image = Properties.Resources.LedYellow32px209; break;
                    case 210: image = Properties.Resources.LedYellow32px210; break;
                    case 211: image = Properties.Resources.LedYellow32px211; break;
                    case 212: image = Properties.Resources.LedYellow32px212; break;
                    case 213: image = Properties.Resources.LedYellow32px213; break;
                    case 214: image = Properties.Resources.LedYellow32px214; break;
                    case 215: image = Properties.Resources.LedYellow32px215; break;
                    case 216: image = Properties.Resources.LedYellow32px216; break;
                    case 217: image = Properties.Resources.LedYellow32px217; break;
                    case 218: image = Properties.Resources.LedYellow32px218; break;
                    case 219: image = Properties.Resources.LedYellow32px219; break;
                    case 220: image = Properties.Resources.LedYellow32px220; break;
                    case 221: image = Properties.Resources.LedYellow32px221; break;
                    case 222: image = Properties.Resources.LedYellow32px222; break;
                    case 223: image = Properties.Resources.LedYellow32px223; break;
                    case 224: image = Properties.Resources.LedYellow32px224; break;
                    case 225: image = Properties.Resources.LedYellow32px225; break;
                    case 226: image = Properties.Resources.LedYellow32px226; break;
                    case 227: image = Properties.Resources.LedYellow32px227; break;
                    case 228: image = Properties.Resources.LedYellow32px228; break;
                    case 229: image = Properties.Resources.LedYellow32px229; break;
                    case 230: image = Properties.Resources.LedYellow32px230; break;
                    case 231: image = Properties.Resources.LedYellow32px231; break;
                    case 232: image = Properties.Resources.LedYellow32px232; break;
                    case 233: image = Properties.Resources.LedYellow32px233; break;
                    case 234: image = Properties.Resources.LedYellow32px234; break;
                    case 235: image = Properties.Resources.LedYellow32px235; break;
                    case 236: image = Properties.Resources.LedYellow32px236; break;
                    case 237: image = Properties.Resources.LedYellow32px237; break;
                    case 238: image = Properties.Resources.LedYellow32px238; break;
                    case 239: image = Properties.Resources.LedYellow32px239; break;
                    case 240: image = Properties.Resources.LedYellow32px240; break;
                    case 241: image = Properties.Resources.LedYellow32px241; break;
                    case 242: image = Properties.Resources.LedYellow32px242; break;
                    case 243: image = Properties.Resources.LedYellow32px243; break;
                    case 244: image = Properties.Resources.LedYellow32px244; break;
                    case 245: image = Properties.Resources.LedYellow32px245; break;
                    case 246: image = Properties.Resources.LedYellow32px246; break;
                    case 247: image = Properties.Resources.LedYellow32px247; break;
                    case 248: image = Properties.Resources.LedYellow32px248; break;
                    case 249: image = Properties.Resources.LedYellow32px249; break;
                    case 250: image = Properties.Resources.LedYellow32px250; break;
                    case 251: image = Properties.Resources.LedYellow32px251; break;
                    case 252: image = Properties.Resources.LedYellow32px252; break;
                    case 253: image = Properties.Resources.LedYellow32px253; break;
                    case 254: image = Properties.Resources.LedYellow32px254; break;
                    case 255: image = Properties.Resources.LedYellow32px255; break;


                    default: image = Properties.Resources.LedYellow32px; break;
                }
            }
            image = resizeImage(image, new Size(newImageWidth, newImageHeight));
            return image;
        }

        public void UpdateLedStatus(ItemRF item)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                int newImageWidth = (int)(pb_lineLTE.Width / item.RatioImageWidth);
                int newImageHeight = (int)(pb_lineLTE.Height / item.RatioImageHeight);
                if (item.status == "DIS")
                {
                    item.ButtonItem.Image = LedDisplay(LedColour.YELLOW, 0, newImageWidth, newImageHeight);
                }
                else if (item.status == "OK")
                {
                    item.ButtonItem.Image = LedDisplay(LedColour.GREEN, 0, newImageWidth, newImageHeight);
                }
                else if (item.status == "NG")
                {
                    item.ButtonItem.Image = LedDisplay(LedColour.RED, 0, newImageWidth, newImageHeight);
                }
                else
                {
                    item.ButtonItem.Image = LedDisplay(LedColour.YELLOW, 0, newImageWidth, newImageHeight);
                }
            }
        }

        public void RemoveItem(ItemInfor item)
        {
            this.pb_lineLTE.Controls.Remove(item.ButtonItem);
        }

        #endregion    

        public void UpdateUIControls()
        {
            //this.Text = mMainResourceManager.GetString("MainTitle");
            //fileToolStripMenuItem.Text = mMainResourceManager.GetString("FileMenu");
            //newToolStripMenuItem.Text = mMainResourceManager.GetString("NewMenu");
            //saveToolStripMenuItem.Text = mMainResourceManager.GetString("SaveMenu");
            //saveAsToolStripMenuItem.Text = mMainResourceManager.GetString("SaveAsMenu");
            //openToolStripMenuItem.Text = mMainResourceManager.GetString("OpenMenu");
            //recentToolStripMenuItem.Text = mMainResourceManager.GetString("RecentMenu");
            //exitToolStripMenuItem.Text = mMainResourceManager.GetString("ExitMenu");

            //editToolStripMenuItem.Text = mMainResourceManager.GetString("EditMenu");
            //connectToolStripMenuItem.Text = mMainResourceManager.GetString("ConnectMenu");
            //disconnectToolStripMenuItem.Text = mMainResourceManager.GetString("DisconnectMenu");
            //runToolStripMenuItem.Text = mMainResourceManager.GetString("RunMenu");
            //stopToolStripMenuItem.Text = mMainResourceManager.GetString("StopMenu");
            //viewToolStripMenuItem.Text = mMainResourceManager.GetString("ViewMenu");
            //languageToolStripMenuItem.Text = mMainResourceManager.GetString("LanguageMenu");
            //englishToolStripMenuItem.Text = mMainResourceManager.GetString("EnglishLanguageMenu");
            //vietnameseToolStripMenuItem.Text = mMainResourceManager.GetString("VietnameseLanguageMenu");
            //helpToolStripMenuItem.Text = mMainResourceManager.GetString("HelpMenu");
            //aboutToolStripMenuItem.Text = mMainResourceManager.GetString("AboutMenu");
            //viewToolStripMenuItem.Text = mMainResourceManager.GetString("ViewMenu");
            //deviceListToolStripMenuItem.Text = mMainResourceManager.GetString("DeviceListMenu");
            //nameToolStripMenuItem.Text = mMainResourceManager.GetString("NameMenu");
            //setUpToolStripMenuItem.Text = mMainResourceManager.GetString("EnterSetupMenu");
            //demoModeToolStripMenuItem.Text = mMainResourceManager.GetString("DemoModeMenu");
            ////documentToolStripMenuItem.Text = mMainResourceManager.GetString("DocumentMenu");
            //changePasswordToolStripMenuItem.Text = mMainResourceManager.GetString("ChangePasswordMenu");

            ////toolStripButtonNew.Text = mMainResourceManager.GetString("NewToolTip");
            ////toolStripButtonOpen.Text = mMainResourceManager.GetString("OpenToolTip");
            ////toolStripButtonSave.Text = mMainResourceManager.GetString("SaveToolTip");
            ////toolStripButtonAdd.Text = mMainResourceManager.GetString("AddToolTip");
            ////toolStripButtonConnect.Text = mMainResourceManager.GetString("ConnectToolTip");
            ////toolStripButtonDisconnect.Text = mMainResourceManager.GetString("DisconnectToolTip");
            ////toolStripButtonLoad.Text = mMainResourceManager.GetString("LoadToolTip");
            ////toolStripButtonRun.Text = mMainResourceManager.GetString("RunToolTip");
            ////toolStripButtonStop.Text = mMainResourceManager.GetString("StopToolTip");
            ////toolStripButtonAddImage.Text = mMainResourceManager.GetString("AddImageToolTip");

            //if (!EditEnable)
            //{
            //    //toolStripButtonAdd.Enabled = false;
            //    //toolStripButtonSave.Enabled = false;
            //    //toolStripButtonAddImage.Enabled = false;
            //    changePasswordToolStripMenuItem.Enabled = false;
            //}
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeDevice();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show(mMainResourceManager.GetString("SaveFileChangeMessage"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel);

            //if (dialogResult == DialogResult.OK)
            //{
            //    FileSaveAs();
            //}

        }

        private void ResetAllControl()
        {

        }

        #region Giao tiep module


        private void closeDevice()
        {
            if (!RFMaster.isConnect())
            {
                RFMaster.disconnect();
            }
        }

        #endregion



        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englishToolStripMenuItem.Checked = true;
            vietnameseToolStripMenuItem.Checked = false;
            Thread.CurrentThread.CurrentUICulture = mEnglishCultureInfo;

            LoadDisplayList();
        }

        private void vietnameseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vietnameseToolStripMenuItem.Checked = true;
            englishToolStripMenuItem.Checked = false;
            Thread.CurrentThread.CurrentUICulture = mVietnameseCultureInfo;

            LoadDisplayList();
        }

        private void LoadDisplayList()
        {
            UpdateUIControls();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AboutBox frmNew = new AboutBox();
            //frmNew.Show();
        }

        private void demoModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (demoModeToolStripMenuItem.CheckState == CheckState.Unchecked)
                demoModeToolStripMenuItem.Checked = true;
            else
                demoModeToolStripMenuItem.Checked = false;
        }

        private void toolStripButtonAddImage_Click(object sender, EventArgs e)
        {
        }

        #region Save&Load recent files


        #endregion

        public bool ShowLoginDlg()
        {
            PasswordForm logindlg = new PasswordForm();
            logindlg.CalledApplication = this;

            DialogResult dr = logindlg.ShowDialog(this);
            if (dr != DialogResult.OK)
                return false;
            return true;
        }


        #region Create & Save password
        /// <summary>
        /// store a list to file and refresh list
        /// </summary>
        /// <param name="path"></param>
        public void SavePassword()
        {

            //writing menu list to file
            //StreamWriter stringToWrite = new StreamWriter(System.Environment.CurrentDirectory + "\\Password.txt"); //create file called "Recent.txt" located on app folder
            //StreamWriter stringToWrite = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Password.txt");

            //StreamWriter stringToWrite = new StreamWriter(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "\\Password.txt");

            bool exists = System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Giamsat");

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Giamsat");
            }

            StreamWriter stringToWrite = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Giamsat" + "\\Password.txt");

            stringToWrite.WriteLine(Password);

            stringToWrite.Flush(); //write stream to file
            stringToWrite.Close(); //close the stream and reclaim memory
        }

        public void LoadPassword()
        {

            System.Collections.Generic.List<string> mListToRead = new List<string>();
            //try to load file. If file isn't found, do nothing
            try
            {

                //StreamReader AccountToRead = new StreamReader(System.Environment.CurrentDirectory + "\\Password.txt"); //read file stream
                //StreamReader AccountToRead = new StreamReader(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "\\Password.txt");

                StreamReader AccountToRead = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Giamsat" + "\\Password.txt");

                string line;

                while ((line = AccountToRead.ReadLine()) != null) //read each line until end of file
                    Password = line;

                AccountToRead.Close(); //close the stream
            }
            catch (Exception)
            {

                //throw;
                return;
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditEnable)
            {
                frmCreatePassword frmNew = new frmCreatePassword();
                frmNew.CalledApplication = this;

                DialogResult dialogResult = frmNew.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    SavePassword();
                }
                else
                {
                    return;
                }
            }

            else
            {


            }
        }

        public string CreatePassword(string strPlainPassword)
        {
            string pass = GetMD5Hash(strPlainPassword);

            return pass;
        }

        public static string GetMD5Hash(string input)
        {
            if (input.Length <= 0)
                return "";
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }

        public bool CheckPassword(string strPassword)
        {
            LoadPassword();

            string strMD5Pass = GetMD5Hash(strPassword);
            if (strMD5Pass.Equals(this.Password, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        #endregion


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void deviceListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer_plan_Tick(object sender, EventArgs e)
        {

        }

        private void timer_blink_Tick(object sender, EventArgs e)
        {
            foreach (var item in lsItems)
            {
                if (viewDetail)
                {
                    if (item.status == item.NG && !item.machineName.Contains("Region"))
                    {
                        if (item.ButtonItem.Tooltip == string.Empty)
                        {
                            item.ButtonItem.Visible = !item.ButtonItem.Visible;
                        }
                        else
                        {
                            item.ButtonItem.Visible = true;
                        }
                        item.ButtonItem.Text = "";
                    }
                    else
                    {
                        item.ButtonItem.Visible = false;
                    }
                }
                else
                {
                    if (item.status == item.NG && item.machineName.Contains("Region"))
                    {
                        if (item.ButtonItem.Tooltip == string.Empty)
                        {
                            item.ButtonItem.Visible = !item.ButtonItem.Visible;
                        }
                        else
                        {
                            item.ButtonItem.Visible = true;
                        }
                        item.ButtonItem.Text = "";
                    }
                    else if (item.status == item.Dis && item.machineName.Contains("Region"))
                    {
                        item.ButtonItem.Visible = true;
                    }
                    else if (item.status == item.OK && item.machineName.Contains("Region"))
                    {
                        item.ButtonItem.Visible = true;
                    }
                    else
                    {
                        item.ButtonItem.Visible = false;
                    }
                }
            }
        }

        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void regionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regionToolStripMenuItem.Checked = true;
            detailToolStripMenuItem.Checked = false;
            viewDetail = false;
            timer_blink.Enabled = true;

        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detailToolStripMenuItem.Checked = true;
            regionToolStripMenuItem.Checked = false;
            viewDetail = true;
            timer_blink.Enabled = true;
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PasswordForm passForm = new PasswordForm();
            passForm.CalledApplication = this;
            DialogResult dialogResult = passForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.WindowState = FormWindowState.Normal;
                if (viewDetail)
                {
                    foreach (var item in lsItems)
                    {
                        if (!item.machineName.Contains("Region"))
                        {
                            item.ButtonItem.Visible = true;
                        }
                        else
                        {
                            item.ButtonItem.Visible = false;
                        }
                    }
                    AddItems frmNew = new AddItems();
                    frmNew.CalledApplication = this;
                    frmNew.Show();
                }
                else
                {
                    foreach (var item in lsItems)
                    {
                        if (item.machineName.Contains("Region"))
                        {
                            item.ButtonItem.Visible = true;
                        }
                        else
                        {
                            item.ButtonItem.Visible = false;
                        }
                    }
                    AddRegion addRegion = new AddRegion();
                    addRegion.CalledApplication = this;
                    addRegion.Show();
                }
                timer_blink.Enabled = false;
            }
        }

        private void edToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordForm passForm = new PasswordForm();
            passForm.CalledApplication = this;
            DialogResult dialogResult = passForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.WindowState = FormWindowState.Normal;
                foreach (var item in lsItems)
                {
                    if (viewDetail)
                    {
                        if (!item.machineName.Contains("Region"))
                        {
                            Helper.ControlMover.Init(item.ButtonItem);
                            item.ButtonItem.Visible = true;
                            timer_blink.Enabled = false;
                        }
                        else
                        {
                            item.ButtonItem.Visible = false;
                        }
                    }
                    else
                    {
                        if (item.machineName.Contains("Region"))
                        {
                            Helper.ControlMover.Init(item.ButtonItem);
                            item.ButtonItem.Visible = true;
                            timer_blink.Enabled = false;
                        }
                        else
                        {
                            item.ButtonItem.Visible = false;
                        }
                    }
                }
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (var item in lsItems)
            {
                clientDb.add(item.machineid, item.addr, item.port, item.machineName, item.status, item.ButtonItem.Location.X, item.ButtonItem.Location.Y, item.region);
                item.xRatio = (float)(pb_lineLTE.Width) / (float)item.ButtonItem.Location.X;
                item.yRatio = (float)(pb_lineLTE.Height) / (float)item.ButtonItem.Location.Y;
                item.RatioWidth = (float)(pb_lineLTE.Width) / (float)item.ButtonItem.Width;
                item.RatioHeight = (float)(pb_lineLTE.Height) / (float)item.ButtonItem.Height;
                item.RatioImageWidth = (float)(pb_lineLTE.Width) / (float)item.ButtonItem.Image.Width;
                item.RatioImageHeight = (float)(pb_lineLTE.Height) / (float)item.ButtonItem.Image.Height;
            }
            MessageBox.Show("Done");
        }

        private void searchAndReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDb searchFrom = new SearchDb();
            searchFrom.CalledApplication = this;
            searchFrom.Show();
        }

        private void reportAllLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            VisualReporting report = new VisualReporting(ReportType.Data_AllLine);
            report.CalledMainDb = this;

            report.Show();
            Cursor.Current = Cursors.Default;
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNew addform = new AddNew();
            addform.CalledSearchDb_main = this;
            addform.Show();
        }

        private void reportEachLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            VisualReporting report = new VisualReporting(ReportType.Data_EachLine);
            report.CalledMainDb = this;
            report.Show();
            Cursor.Current = Cursors.Default;
        }

        private void mTBFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            VisualReporting report = new VisualReporting(ReportType.Data_MTTR);
            report.CalledMainDb = this;

            report.Show();
            Cursor.Current = Cursors.Default;
        }

        private void mTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            VisualReporting report = new VisualReporting(ReportType.Data_MTBF);
            report.CalledMainDb = this;
            report.Show();
            Cursor.Current = Cursors.Default;
        }

        private void timeNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigTimeNG configForm = new ConfigTimeNG();
            configForm.CalledSearchDb = this;
            configForm.Show();
        }

        private void ipAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ipAddress ipAddress = new ipAddress();
            ipAddress.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void resizeControl(ItemRF item)
        {
            int newX = (int)(pb_lineLTE.Width / item.xRatio);
            int newY = (int)(pb_lineLTE.Height / item.yRatio);
            int newWidth = (int)(pb_lineLTE.Width / item.RatioWidth);
            int newHeight = (int)(pb_lineLTE.Height / item.RatioHeight);

            int newImageWidth = (int)(pb_lineLTE.Width / item.RatioImageWidth);
            int newImageHeight = (int)(pb_lineLTE.Height / item.RatioImageHeight);

            item.ButtonItem.Width = newWidth;
            item.ButtonItem.Height = newHeight;
            item.ButtonItem.Location = new Point(newX, newY);
            if (item.status == "OK")
            {
                item.ButtonItem.Image = resizeImage(Properties.Resources.LedGreen32px, new Size(newImageWidth, newImageHeight));
            }
            else if (item.status == "NG")
            {
                item.ButtonItem.Image = resizeImage(Properties.Resources.LedRed32px, new Size(newImageWidth, newImageHeight));
            }
            else
            {
                item.ButtonItem.Image = resizeImage(Properties.Resources.Ledblack32px, new Size(newImageWidth, newImageHeight));
            }

        }
        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                foreach (var item in lsItems)
                {
                    resizeControl(item);
                }
            }
        }

        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string testConnect = "";
            if (RFMaster.connect())
            {
                testConnect = "Connected";
            }
            AboutBox aboutBox = new AboutBox(testConnect);
            aboutBox.Show();
        }

        private void sparePaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSparePart viewSparePart = new ViewSparePart();
            viewSparePart.CalledMainDb = this;
            viewSparePart.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void folderReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigFolderReport configFolderReport = new ConfigFolderReport();
            configFolderReport.CalledSearchDb = this;
            configFolderReport.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ShowLoginDlg())
            {
                ConfigUser configUserForm = new ConfigUser();
                configUserForm.CalledApplication = this;
                configUserForm.Show();
            }
        }
    }
}