using _4P_PROJECT.Control;
using GiamSat.model;
using GiamSat.viewDb;
using Org.BouncyCastle.Utilities.Collections;
using Syncfusion.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GiamSat.model.History;
using static GiamSat.model.HistoryNG;
using static GiamSat.model.Machine;

namespace GiamSat.View
{
    public partial class EditHistory : Form
    {
        private SearchDb mSearchDbInstance;
        private Machine g_machine;
        private History g_history;
        private HistoryNG g_historyNG;
        private ConfigSystem configSystem;
        private HistoryData g_historyData;
        private machineData g_machineData;

        private byte[] picture1;
        private byte[] picture2;
        private byte[] picture3;
        private byte[] picture4;
        private byte[] picture5;
        private byte[] picture6;


        private string g_writer = "";
        private string g_checked = "";
        private string g_approved = "";

        private string g_timeStart = "";
        private DateTime dateMachineNG;
        private DateTime dateMachineOK;
        /*Folder */
        private string directOpentPptx = "../example_pptx/Sample.pptx";
        private string directSavetPptx = "../report_pptx/";
        private string CurrentfileName;
        public SearchDb CalledEditDb
        {
            get
            {
                return mSearchDbInstance;
            }
            set
            {
                mSearchDbInstance = value;
                g_machine.database = mSearchDbInstance.mAppInstance.MainDatabase;
                g_history.database = mSearchDbInstance.mAppInstance.MainDatabase;
                g_historyNG.database = mSearchDbInstance.mAppInstance.MainDatabase;
                configSystem.database = mSearchDbInstance.mAppInstance.MainDatabase;
            }
        }
        public EditHistory()
        {
            InitializeComponent();
            g_machine = new Machine();
            g_history = new History();
            g_historyNG = new HistoryNG();
            configSystem = new ConfigSystem();
        }

        public void Set(HistoryData dataHistory)
        {
            Https http = new Https();
            btn_exportPPT.Enabled = true;

            g_historyData = dataHistory;
            if (g_historyData.ChildMachineID != 0) 
            {
                g_machineData = g_machine.get(g_historyData.ChildMachineID);
            }
            else
            {
                g_machineData = g_machine.get(g_historyData.machineID);
            }
            try
            {
                if (dataHistory.picture1 != string.Empty)
                {
                    string imageText1 = http.GetDataImage(dataHistory.picture1);
                    if (imageText1 != string.Empty)
                    {
                        picture1 = Convert.FromBase64String(imageText1);
                        Bitmap image;
                        using (MemoryStream stream = new MemoryStream(picture1))
                        {
                            image = new Bitmap(stream);
                        }
                        pb_1.Image = image;
                    }
                }

                if (dataHistory.picture2 != string.Empty)
                {
                    string imageText = http.GetDataImage(dataHistory.picture2);
                    if (imageText != string.Empty)
                    {
                        picture2 = Convert.FromBase64String(imageText);
                        Bitmap image;
                        using (MemoryStream stream = new MemoryStream(picture2))
                        {
                            image = new Bitmap(stream);
                        }
                        pb_2.Image = image;
                    }
                }

                if (dataHistory.picture3 != string.Empty)
                {
                    string imageText = http.GetDataImage(dataHistory.picture3);
                    if (imageText != string.Empty)
                    {
                        picture3 = Convert.FromBase64String(imageText);
                        Bitmap image;
                        using (MemoryStream stream = new MemoryStream(picture3))
                        {
                            image = new Bitmap(stream);
                        }
                        pb_3.Image = image;
                    }
                }

                if (dataHistory.picture4 != string.Empty)
                {
                    string imageText = http.GetDataImage(dataHistory.picture4);
                    if (imageText != string.Empty)
                    {
                        picture4 = Convert.FromBase64String(imageText);
                        Bitmap image;
                        using (MemoryStream stream = new MemoryStream(picture4))
                        {
                            image = new Bitmap(stream);
                        }
                        pb_4.Image = image;
                    }
                }
                if (dataHistory.picture5 != string.Empty)
                {
                    string imageText = http.GetDataImage(dataHistory.picture5);
                    if (imageText != string.Empty)
                    {
                        picture5 = Convert.FromBase64String(imageText);
                        Bitmap image;
                        using (MemoryStream stream = new MemoryStream(picture5))
                        {
                            image = new Bitmap(stream);
                        }
                        pb_5.Image = image;
                    }
                }
                if (dataHistory.picture6 != string.Empty)
                {
                    string imageText = http.GetDataImage(dataHistory.picture6);
                    if (imageText != string.Empty)
                    {
                        picture6 = Convert.FromBase64String(imageText);
                        Bitmap image;
                        using (MemoryStream stream = new MemoryStream(picture6))
                        {
                            image = new Bitmap(stream);
                        }
                        pb_6.Image = image;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }


            tb_deviceCode.Text = g_machineData.machineCode;
            tb_deviceName.Text = g_machineData.machineName;
            tb_line.Text = g_machineData.linePosition +"/"+ g_machineData.lane;
            tb_TroubleName.Text = g_historyData.troubleName;
            tb_note1.Text = g_historyData.note1;
            tb_note2.Text = g_historyData.note2;
            tb_note3.Text = g_historyData.note3;
            tb_note4.Text = g_historyData.note4;
            tb_note5.Text = g_historyData.note5;
            tb_note6.Text = g_historyData.note6;

            dateMachineNG = DateTime.ParseExact(g_historyData.time, "dd-MM-yyyy HH:mm", null);

            HistoryNGData historyDataOK = g_historyNG.searchStatusOKNearNG(g_historyData.historyID, g_historyData.machineID);

            if (historyDataOK != null)
            {
                dateMachineOK = DateTime.ParseExact(historyDataOK.time, "dd-MM-yyyy HH:mm", null);
                g_timeStart = dateMachineOK.Subtract(dateMachineNG).TotalMinutes.ToString("0");
            }

            // get folder save report
            var folder = configSystem.getFolderReport();
            if (folder != "")
            {
                directSavetPptx = folder + "/";
            }
        }

        private void saveDb()
        {
            bool status = false;
            if (tb_note1.Text == string.Empty && tb_note2.Text == string.Empty &&
                tb_note3.Text == string.Empty && tb_note6.Text == string.Empty)
            {
                MessageBox.Show("Empty content");
                return;
            }

            UInt64 historyID = g_history.getHistoryID(g_historyData.noTrouble);
            status = g_history.update(historyID, tb_TroubleName.Text.Replace('\"','\''), tb_note1.Text.Replace('\"', '\''), tb_note2.Text.Replace('\"', '\''), tb_note3.Text.Replace('\"', '\''), tb_note4.Text.Replace('\"', '\''), tb_note5.Text.Replace('\"', '\''), tb_note6.Text.Replace('\"', '\''));

            if (status)
            {
                MessageBox.Show("Save done");
                mSearchDbInstance.resumeUI();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error!!!");
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            saveDb();
        }

        private void AddNew_Load(object sender, EventArgs e)
        {

        }

        private void tb_line_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tb_lane_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_exportPPT_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            g_historyData.troubleName = tb_TroubleName.Text;
            g_historyData.note1 = tb_note1.Text;
            g_historyData.note2 = tb_note2.Text;
            g_historyData.note3 = tb_note3.Text;
            g_historyData.note4 = tb_note4.Text;
            g_historyData.note5 = tb_note5.Text;
            g_historyData.note6 = tb_note6.Text;
            try
            {
                //Loads the PowerPoint Presentation
                IPresentation pptxDoc = Presentation.Open(directOpentPptx);
                //Gets the slide from Presentation
                ISlide slide = pptxDoc.Slides[0];
                //Gets the shape in slide

                string noTrouble_str = string.Empty;
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    //Gets the shape in slide
                    IShape textboxShape = slide.Shapes[i] as IShape;
                    if (textboxShape.ShapeName == "tb_notrouble")
                    {
                        /*caculate noTrouble export*/
                        DateTime date = DateTime.Now;
                        var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                        var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddSeconds(-1);

                        List<HistoryNGData> lsHistorydataNG = g_historyNG.searchNgOnTime(firstDayOfMonth.ToString("yyyy-MM-dd"), lastDayOfMonth.ToString("yyyy-MM-dd"));

                        int count = 0;
                        for (int j = lsHistorydataNG.Count; j > 0; j--)
                        {
                            count++;
                            if (lsHistorydataNG[j - 1].historyID == g_historyData.historyID.ToString())
                            {
                                break;
                            }
                        }
                        noTrouble_str = string.Format("{0}_{1:0000}", g_historyData.noTrouble.Split('_')[0], count);
                        textboxShape.TextBody.Text = noTrouble_str;
                    }
                    else if (textboxShape.ShapeName == "tb_writer")
                    {
                        textboxShape.TextBody.Text = g_writer;
                    }
                    else if (textboxShape.ShapeName == "tb_checked")
                    {
                        textboxShape.TextBody.Text = g_checked;
                    }
                    else if (textboxShape.ShapeName == "tb_approved")
                    {
                        textboxShape.TextBody.Text = g_approved;
                    }
                    else if (textboxShape.ShapeName == "tb_machineName")
                    {
                        textboxShape.TextBody.Text = g_machineData.machineName;
                    }
                    else if (textboxShape.ShapeName == "tb_model")
                    {
                        textboxShape.TextBody.Text = g_machineData.Model;
                    }
                    else if (textboxShape.ShapeName == "tb_line")
                    {
                        textboxShape.TextBody.Text = g_machineData.linePosition + "." + g_machineData.lane+ "-" + g_machineData.TopBot;
                    }
                    else if (textboxShape.ShapeName == "tb_serial")
                    {
                        textboxShape.TextBody.Text = g_machineData.Serial;
                    }
                    else if (textboxShape.ShapeName == "tb_troubleName")
                    {
                        textboxShape.TextBody.Text = g_historyData.troubleName;
                    }
                    else if (textboxShape.ShapeName == "tb_dateNG")
                    {
                        textboxShape.TextBody.Text = dateMachineNG.ToString("dd.MM.yyyy");
                    }
                    else if (textboxShape.ShapeName == "tb_timeStop")
                    {
                        textboxShape.TextBody.Text = dateMachineNG.ToString("HH") + "h" + dateMachineNG.ToString("mm");
                    }
                    else if (textboxShape.ShapeName == "tb_timeStart")
                    {
                        textboxShape.TextBody.Text = dateMachineOK.ToString("HH") + "h" + dateMachineOK.ToString("mm");
                    }
                    else if (textboxShape.ShapeName == "tb_totalTime")
                    {
                        textboxShape.TextBody.Text = g_timeStart + " Min";
                    }
                    else if (textboxShape.ShapeName == "tb_note1")
                    {
                        textboxShape.TextBody.Text = g_historyData.note1;
                    }
                    else if (textboxShape.ShapeName == "tb_note2")
                    {
                        textboxShape.TextBody.Text = g_historyData.note2;
                    }
                    else if (textboxShape.ShapeName == "tb_note3")
                    {
                        textboxShape.TextBody.Text = g_historyData.note3;
                    }
                    else if (textboxShape.ShapeName == "tb_note4")
                    {
                        textboxShape.TextBody.Text = g_historyData.note4;
                    }
                    else if (textboxShape.ShapeName == "tb_note5")
                    {
                        textboxShape.TextBody.Text = g_historyData.note5;
                    }
                    else if (textboxShape.ShapeName == "tb_note6")
                    {
                        textboxShape.TextBody.Text = g_historyData.note6;
                    }
                }

                for (int i = 0; i < slide.Pictures.Count; i++)
                {
                    //Gets the shape in slide
                    IPicture ShapePicture = slide.Pictures[i] as IPicture;
                    if (ShapePicture.ShapeName == "picture_1")
                    {
                        if (picture1 != null)
                        {
                            ShapePicture.ImageData = picture1;
                        }
                    }
                    else if (ShapePicture.ShapeName == "picture_2")
                    {
                        if (picture2 != null)
                        {
                            ShapePicture.ImageData = picture2;
                        }
                    }
                    else if (ShapePicture.ShapeName == "picture_3")
                    {
                        if (picture3 != null)
                        {
                            ShapePicture.ImageData = picture3;
                        }
                    }
                    else if (ShapePicture.ShapeName == "picture_4")
                    {
                        if (picture4 != null)
                        {
                            ShapePicture.ImageData = picture4;
                        }
                    }
                    else if (ShapePicture.ShapeName == "picture_5")
                    {
                        if (picture5 != null)
                        {
                            ShapePicture.ImageData = picture5;
                        }
                    }
                    else if (ShapePicture.ShapeName == "picture_6")
                    {
                        if (picture6 != null)
                        {
                            ShapePicture.ImageData = picture6;
                        }
                    }
                }
                /* Save file*/
                CurrentfileName = string.Format("{0} - Line{1} - {2} - {3} - {4}.pptx", noTrouble_str, g_machineData.linePosition, g_machineData.TopBot != null ? g_machineData.TopBot.ToUpper():"", g_machineData.machineName, g_historyData.troubleName).Replace(":", string.Empty);
                pptxDoc.Save(directSavetPptx + CurrentfileName);
                pptxDoc.Close();
                Cursor.Current = Cursors.Default;

                MessageBox.Show("Done");
                btn_viewRp.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error. Please close file!!!");
            }
        }

        private void btn_viewRp_Click(object sender, EventArgs e)
        {
            if (File.Exists(directSavetPptx + CurrentfileName))
            {
                string path = Path.GetFullPath(directSavetPptx + CurrentfileName);
                Process.Start("explorer.exe", "/select, " + path);
            }
        }

        private void pb_1_MouseEnter(object sender, EventArgs e)
        {
            
        }
    }
}
